using AppEstacionamento.Model;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AppEstacionamento.Repositorio
{
    public  class EntradaVeiculoRepositorio
    {
        public EntradaVeiculoRepositorio(Veiculo veiculo)
        {
            Veiculo = veiculo;
        }
        public Veiculo Veiculo { get; set; }

        public void InserirEntrada()
        {
            using (SqlConnection connection = new SqlConnection(DbConfig.GetConnectionString()))
            {
                try
                {
                    string insertEntradaVeiculo = " insert into EntradaVeiculo(id, PlacaVeiculo, Modelo, DataEntrada, ValorPago)" +
                                                   $" Values('{Veiculo.Id}','{Veiculo.PlacaVeiculo.ToUpper()}','{Veiculo.Modelo.ToUpper()}','{Veiculo.DataEntrada} ', {Veiculo.ValorPago} )";

                    connection.Execute(insertEntradaVeiculo);

                    Console.WriteLine($"Veículo modelo '{Veiculo.Modelo}' com a placa '{Veiculo.PlacaVeiculo}' cadastrado!");
                    Console.ReadKey();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }
    }
}
