using AppEstacionamento.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEstacionamento.Repositorio.RepositorioInterface
{
    public interface IRelatorioRepositorio
    {
        ICollection<Veiculo> BuscarPorDataEntrada();

        ICollection<Veiculo> BuscarPorDataSaida();

        ICollection<Veiculo> BuscarPorPlaca();

        ICollection<Veiculo> BuscarPorModelo();

        void ExportaRelatorio(ICollection<Veiculo> Lista);
    }
}
