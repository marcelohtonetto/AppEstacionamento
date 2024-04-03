using AppEstacionamento.Model;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace AppEstacionamento.Repositorio;

public class SaidaVeiculoRepositorio
{
    public SaidaVeiculoRepositorio(Veiculo veiculo)
    {
        Veiculo = veiculo;
    }
    public Veiculo Veiculo { get; set; }

    private double RetornaTempoPermanencia(string placa)
    {
        using (SqlConnection connection = new SqlConnection(DbConfig.GetConnectionString()))
        {
            try
            {
                object horaEntradaDB = 0;

                var selectValorPrecoHora = $" select DataEntrada from entradaVeiculo where placaveiculo = '{placa.ToUpper()}' and  PagamentoEfetuado = 0";
                DateTime dataentrada =  connection.QueryFirstOrDefault<DateTime>(selectValorPrecoHora);

                if (dataentrada == DateTime.MinValue)
                {
                    Console.WriteLine("O veículo nao tem saída pendente");
                    Console.ReadKey();
                    return 0;
                }

                DateTime horaSaida = DateTime.Now;

                TimeSpan diferencaTempo = horaSaida - dataentrada;
                Console.WriteLine($"Tempo do veiculo parado :{diferencaTempo}");

                return Convert.ToDouble(diferencaTempo.TotalHours);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }
    }
    private decimal RetornaValorHora()
    {
        using (SqlConnection connection = new SqlConnection(DbConfig.GetConnectionString()))
        {
            try
            {
                object precohoraAtual = 0;

                var selectValorPrecoHora = string.Format(CultureInfo.InvariantCulture, " select top 1 preco from PrecoHora order by id desc");

                decimal precohora = connection.QueryFirstOrDefault<decimal>(selectValorPrecoHora);

                if (precohora == 0)
                {
                    Console.WriteLine("Sem valor da hora cadastrado");
                    return 0;
                }

                return precohora;
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }
    }
    public void GravarSaida() 
    {
        using (SqlConnection connection = new SqlConnection(DbConfig.GetConnectionString()))
        {
            try
            {
                string updateSaidaVeiculo = string.Format(CultureInfo.InvariantCulture, " update EntradaVeiculo set ValorPago = {0}, PagamentoEfetuado = 1, ", Veiculo.ValorPago) +
                                            $" DataSaida = '{DateTime.Now}'where  PlacaVeiculo = '{Veiculo.PlacaVeiculo}' and PagamentoEfetuado = 0";

                connection.Execute(updateSaidaVeiculo);

                Console.WriteLine($"Saida do veículo com a placa '{Veiculo.PlacaVeiculo}' liberada");
                Console.ReadKey();
            }
            catch (Exception ex) 
            { 
                Console.WriteLine( ex.Message); 
            }
        }
    }
    private decimal TempoPermanencia() => Math.Round(RetornaValorHora() * (decimal)RetornaTempoPermanencia(Veiculo.PlacaVeiculo), 2);
    public decimal RetornaValorAPagar() => (Veiculo.ValorPago = TempoPermanencia());
}
