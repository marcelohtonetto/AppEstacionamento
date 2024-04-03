using AppEstacionamento.Model;
using AppEstacionamento.Repositorio.RepositorioInterface;
using Dapper;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Numerics;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace AppEstacionamento.Repositorio
{
    public class RelatorioRepositorio<T> : IRelatorioRepositorio
    {
        public RelatorioRepositorio(T valor)
        {
            Valor = valor;  
        }
        public T Valor { get; set; }

        public ICollection<Veiculo> BuscarPorDataEntrada()
        {
            DateTime DataEntradaConvertida = Convert.ToDateTime(Valor);
            DateTime dataLimite = DataEntradaConvertida.AddHours(23);

            ICollection<Veiculo> lista = new List<Veiculo>();

            using (SqlConnection connection = new SqlConnection(DbConfig.GetConnectionString()))
            {
                try
                {
                    string selectRelatorio = $" select PlacaVeiculo, Modelo, DataEntrada, ValorPago, DataSaida from EntradaVeiculo where DataEntrada >= '{DataEntradaConvertida}' and DataEntrada <= '{dataLimite}'";

                    lista = (ICollection<Veiculo>)connection.Query<Veiculo>(selectRelatorio);                
                }
                
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                return lista;
            }         
        }

        public ICollection<Veiculo> BuscarPorDataSaida()
        {
            string connectionString = DbConfig.GetConnectionString();

            DateTime DataSaidaConvertida = Convert.ToDateTime(Valor);
            DateTime dataLimite = DataSaidaConvertida.AddHours(23);

            ICollection<Veiculo> lista = new List<Veiculo>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    string selectRelatorio = $" select PlacaVeiculo, Modelo, DataEntrada, ValorPago, DataSaida from EntradaVeiculo where DataSaida >= '{DataSaidaConvertida}' and DataSaida <= '{dataLimite}'";
                    lista = (ICollection<Veiculo>)connection.Query<Veiculo>(selectRelatorio);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                return lista;
            }
        }

        public ICollection<Veiculo> BuscarPorPlaca()
        {
            ICollection<Veiculo> lista = new List<Veiculo>();

            using (SqlConnection connection = new SqlConnection(DbConfig.GetConnectionString()))
            {
                try
                {
                    string selectRelatorio = $" select PlacaVeiculo, Modelo, DataEntrada, ValorPago, DataSaida from EntradaVeiculo where PlacaVeiculo = '{Valor}'";
                    lista = (ICollection<Veiculo>)connection.Query<Veiculo>(selectRelatorio);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                return lista;
            }
        }
        public ICollection<Veiculo> BuscarPorModelo()
        {
            ICollection<Veiculo> lista = new List<Veiculo>();

            using (SqlConnection connection = new SqlConnection(DbConfig.GetConnectionString()))
            {
                try
                {
                    string selectRelatorio = $" select PlacaVeiculo, Modelo, DataEntrada, ValorPago, DataSaida from EntradaVeiculo where Modelo = '{Valor}'";
                    lista = (ICollection<Veiculo>)connection.Query<Veiculo>(selectRelatorio);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                return lista;
            }
        }

        public void ExportaRelatorio(ICollection<Veiculo> listaveiculo)
        {
            try
            {
                using (StreamWriter sw = File.CreateText("relatorio.txt"))
                {
                    sw.WriteLine("Relátorio dos veículos");
                    foreach (var veiculo in listaveiculo)
                    {
                        sw.WriteLine($" Placa do veículo :{veiculo.PlacaVeiculo}," +
                                     $" modelo do veículo: {veiculo.Modelo}," +
                                     $" data da entrada : {veiculo.DataEntrada}," +
                                     $" valor pago: {veiculo.ValorPago}," +
                                     $" data da saída: {veiculo.DataSaida}"); 
                    }
                }
                Console.WriteLine("Relátorio exportado, nome do arquivo: relatorio.txt");
            }
            catch (Exception ex)
            {
                Console.WriteLine (ex.ToString());  
            }
        }
    }
}
