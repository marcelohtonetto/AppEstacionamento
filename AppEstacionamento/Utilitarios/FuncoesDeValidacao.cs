using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEstacionamento.Utilitarios
{
    static class FuncoesDeValidacao
    {
        public static bool ValidaPlaca(string placa)
        {
            bool placaInvalida = false;
            if (placa.Length != 7)
            {
                Console.WriteLine("Placa inválida!");
                placaInvalida = true;
            }
            return placaInvalida;
        }

        public static bool ValidaModelo(string modelo)
        {
            bool placaModelo = false;
            if (modelo.Length == 0)
            {
                Console.WriteLine("O modelo do veículo nao pode ser vazio!");
                placaModelo = true;
            }
            return placaModelo;
        }

        public static bool ValidaMoeda(string moeda)
        {
            bool moedaInvalida = false;
            bool valorValido;

            valorValido = double.TryParse(moeda, out double valorMoeda);

            if (moeda.Length == 0)
            {
                Console.WriteLine("Digite o novo valor da hora!");
                return moedaInvalida = true;
            }

            if (!valorValido)
            {
                Console.WriteLine($"Valor {moeda} inválido! ");
                return moedaInvalida = true;
            }


            return moedaInvalida;
        }

        public static bool ValidaData(string data)
        {
            bool dataValida = !DateTime.TryParse(data, out DateTime dataHora);

            if (dataValida)
            {
                Console.WriteLine("Data inválida");
            }

            return dataValida;
        }
    }
}
