using AppEstacionamento.Model.Interface;
using AppEstacionamento.Repositorio;
using AppEstacionamento.Utilitarios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AppEstacionamento.Model;

public class Relatorio 
{
    public void BuscarPorDataEntrada(DateTime dataentradaconvertida)
    {

        RelatorioRepositorio<DateTime> rr = new RelatorioRepositorio<DateTime>(dataentradaconvertida);
        ICollection<Veiculo> lista = rr.BuscarPorDataEntrada();

        if (lista.Any()) 
        {
            var listaVeiculoOrdenada = lista.OrderByDescending(x => x.DataEntrada);

            ExibirRegistros(listaVeiculoOrdenada);

            if (ExibeOpcoesExportar())
            {
                rr.ExportaRelatorio(lista);
            }
        }
        else 
        {
            Console.WriteLine("Nenhum registro encontrado!");
        }
        Console.ReadKey();

    }
    public void BuscarPorDataSaida(DateTime datasaidaconvertida)
    {

        RelatorioRepositorio<DateTime> rr = new RelatorioRepositorio<DateTime>(datasaidaconvertida);
        ICollection<Veiculo> lista = rr.BuscarPorDataSaida();

        if (lista.Any())
        {
            var listaVeiculoOrdenada = lista.OrderByDescending(x => x.DataSaida);

            ExibirRegistros(listaVeiculoOrdenada);

            if (ExibeOpcoesExportar())
            {
                rr.ExportaRelatorio(lista);
            }
        }
        else
        {
            Console.WriteLine("Nenhum registro encontrado!");
        }
        Console.ReadKey();

    }
    public void BuscarPorPlaca(string placa)
    {
        RelatorioRepositorio<string> rr = new RelatorioRepositorio<string>(placa.ToUpper());
        ICollection<Veiculo> lista = rr.BuscarPorPlaca();
        if (lista.Any()) 
        { 
            var listaVeiculoOrdenada = lista.OrderByDescending(x => x.DataEntrada);

            ExibirRegistros(listaVeiculoOrdenada);
            if (ExibeOpcoesExportar())
            {
                rr.ExportaRelatorio(lista);
            }
        }
        else 
        {
            Console.WriteLine("Nenhum registro encontrado!");
        }
        Console.ReadKey();
    }

    public void BuscarPorModelo(string modelo) 
    { 
        RelatorioRepositorio<string> rr = new RelatorioRepositorio<string>(modelo.ToUpper());
        ICollection<Veiculo> lista =  rr.BuscarPorModelo();
        if (lista.Any())
        {
            var listaVeiculoOrdenada = lista.OrderByDescending(x => x.DataEntrada);

            ExibirRegistros(listaVeiculoOrdenada);
            if (ExibeOpcoesExportar())
            {
                rr.ExportaRelatorio(lista);
            }
        }
        else
        {
            Console.WriteLine("Nenhum registro encontrado!");
        }
        Console.ReadKey();
    }
    private bool ExibeOpcoesExportar()
    {
        Console.WriteLine("");
        Console.WriteLine("Deseja exportar o relátorio para arquivo .txt? Digite 'S' ou 'N' ");
        string opcaoSelecionada = Console.ReadLine();
        return Exportar(opcaoSelecionada.ToUpper());
    }
    private bool Exportar(string opcao)
    {
        switch (opcao)
        {
            case "S": return true;
            default: return false;
        }
    }

    private void ExibirRegistros(IOrderedEnumerable<Veiculo> listaVeiculo) 
    {
        foreach (var veiculo in listaVeiculo) 
        {
            Console.WriteLine($" Placa do veículo :{veiculo.Placa}," +
                              $" modelo do veículo: {veiculo.Modelo}," +
                              $" data da entrada : {veiculo.DataEntrada}," +
                              $" data da saída: {veiculo.DataSaida}," +
                              $" valor pago: {veiculo.ValorPago}");
        }
    }
}
