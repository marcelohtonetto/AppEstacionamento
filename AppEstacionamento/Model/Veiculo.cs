using AppEstacionamento.Model.Interface;
using AppEstacionamento.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace AppEstacionamento.Model;

public class Veiculo : IVeiculo
{

    public Veiculo() { }
    public Veiculo(string placa, string modelo)
    {
        Id = Guid.NewGuid();
        Placa = placa;
        Modelo = modelo;
        DataEntrada = DateTime.Now;
        ValorPago = 0;
    }
    public Veiculo(string placa)
    {
        Placa = placa; 
    }

    public Guid Id { get; set; }
    public string? Placa { get; set; }
    public string? Modelo { get; set; }
    public DateTime DataEntrada { get; set; }
    public DateTime DataSaida { get; set; }
    public decimal ValorPago { get; set; }
    public void EntradaVeiculo()
    {
        EntradaVeiculoRepositorio evr = new EntradaVeiculoRepositorio(this);
        evr.InserirEntrada();
        Console.ReadKey();
    }
    public void SaidaVeiculo()
    {
        SaidaVeiculoRepositorio svr = new SaidaVeiculoRepositorio(this);
        decimal valoraPagar = svr.RetornaValorAPagar();
        if (valoraPagar > 0)
        {
            Console.WriteLine($"Valor a ser pago: {valoraPagar}");
            svr.GravarSaida();
            Console.ReadKey();
        }   
    }
}
