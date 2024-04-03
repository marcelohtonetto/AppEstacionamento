using AppEstacionamento.Model;
using AppEstacionamento.Utilitarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEstacionamento.Menu
{
    static class MenuRelatorio
    {

        public static void MenuImpressao()
        {
            ExibeOpcoes();
        }
        private static void ExibeOpcoes()
        {
            Console.WriteLine("Opção 1: Buscar por data de entrada. ");
            Console.WriteLine("Opção 2: Buscar por data de saída. ");
            Console.WriteLine("Opção 3: Buscar por placa do veículo. ");
            Console.WriteLine("Opção 4: Buscar por modelo do veículo. ");
            string opcaoSelecionada = Console.ReadLine();

            MenuImpressaoSelecionado(opcaoSelecionada);
        }
        private static void MenuImpressaoSelecionado(string opcao)
        {
            

            switch (opcao)
            {
                case "1":
                    BuscarDataEntrada();
                    break;
                case "2":
                    BuscarDataSaida();
                    break;
                case "3":
                    BuscarPlaca();
                    break;
                case "4":
                    BuscarModelo();
                    break;
                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }
        }

        private static void BuscarDataEntrada() 
        {
            string dataEntrada;
            do
            {
                Console.WriteLine("Digite a data de entrada:");
                dataEntrada = Console.ReadLine();

            } while (FuncoesDeValidacao.ValidaData(dataEntrada));

            DateTime dataEntradaConvertida = Convert.ToDateTime(dataEntrada);
            Relatorio relatorio = new Relatorio();
            relatorio.BuscarPorDataEntrada(dataEntradaConvertida);
        }

        private static void BuscarDataSaida()
        {
            string dataSaida;
            do
            {
                Console.WriteLine("Digite a data de saída:");
                dataSaida = Console.ReadLine();

            } while (FuncoesDeValidacao.ValidaData(dataSaida));

            DateTime dataSaidaConvertida = Convert.ToDateTime(dataSaida);
            Relatorio relatorio = new Relatorio();
            relatorio.BuscarPorDataSaida(dataSaidaConvertida);
        }
        private static void BuscarPlaca() 
        {
            string placa;
            do
            {
                Console.WriteLine("Digite a placa do veículo:");
                placa = Console.ReadLine();
            } while (FuncoesDeValidacao.ValidaPlaca(placa));

            Relatorio relatorio = new Relatorio();
            relatorio.BuscarPorPlaca(placa);
        }
        private static void BuscarModelo() 
        {
            string modelo;
            do
            {
                Console.WriteLine("Digite o modelo do veículo:");
                modelo = Console.ReadLine();
            } while (FuncoesDeValidacao.ValidaModelo(modelo));

            Relatorio relatorio = new Relatorio();
            relatorio.BuscarPorModelo(modelo);
        }

    }
}
