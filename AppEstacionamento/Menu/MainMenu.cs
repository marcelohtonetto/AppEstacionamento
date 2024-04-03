using AppEstacionamento.Model;
using AppEstacionamento.Utilitarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEstacionamento.Menu;

static class MainMenu
{
    public static void ExibeMenu()
    {
        Console.Clear();
        Console.WriteLine("Menu");
        Console.WriteLine("opção 1: Entrada de Veículo");
        Console.WriteLine("Opção 2: Saída de veículo");
        Console.WriteLine("Opção 3: Atualizar o valor da hora");
        Console.WriteLine("Opção 4: Relátorio");
        Console.WriteLine("Opção 5: Sair");
        string iOpcao = Console.ReadLine();

        MenuSelecionado(iOpcao);

    }
    static void MenuSelecionado(string opcao)
    {
        switch (opcao)
        {
            case "1":
                EntradaVeiculo();
                break;
            case "2":
                SaidaVeiculo();
                break;
            case "3":
                AtualizarPrecos();
                break;
            case "4":
                Relatorio();
                break;
            case "5":
                Console.WriteLine("Tchau Tchau!");
                break;
            default:
                Console.WriteLine("Opção inválida");
                Console.ReadKey();
                ExibeMenu();
                break;
        }
    }
    static void EntradaVeiculo()
    {
        Console.Clear();
        string Placa;
        string ModeloVeiculo;

        do
        {
            Console.WriteLine("Digite a placa do veiculo:");
            Placa = Console.ReadLine();
        } while (FuncoesDeValidacao.ValidaPlaca(Placa));

        do
        {
            Console.WriteLine("Digite o modelo do veiculo:");
            ModeloVeiculo = Console.ReadLine();

        } while (FuncoesDeValidacao.ValidaModelo(ModeloVeiculo));

        var Veiculo = new Veiculo(Placa, ModeloVeiculo);
        Veiculo.EntradaVeiculo();

        ExibeMenu();
    }
    static void SaidaVeiculo()
    {
        Console.Clear();
        string Placa;

        do
        {
            Console.WriteLine("Digite uma placa valída:");
            Placa = Console.ReadLine();
        } while (FuncoesDeValidacao.ValidaPlaca(Placa));

        var Veiculo = new Veiculo(Placa);
        Veiculo.SaidaVeiculo();

        ExibeMenu();
    }
    static void AtualizarPrecos()
    {
        Console.Clear();
        string valortexto;

        do
        {
            Console.WriteLine("Novo valor do preço por hora:");
            valortexto = Console.ReadLine();
        } while (FuncoesDeValidacao.ValidaMoeda(valortexto));

        PrecoHora ph = new PrecoHora(Convert.ToDecimal(valortexto));
        ph.GravarValorHora();
        ExibeMenu();
    }
    static void Relatorio()
    {
        Console.Clear();
        MenuRelatorio.MenuImpressao();
        ExibeMenu();
    }
}
