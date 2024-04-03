using AppEstacionamento.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEstacionamento.Model;

public class PrecoHora
{
    public PrecoHora()
    {
            
    }
    public PrecoHora(decimal valor)
    {
        ValorHora = valor;
        DataValorCadastrado = DateTime.Now;
    }
    public decimal ValorHora { get; set; }
    public DateTime DataValorCadastrado { get; set; }

    public void GravarValorHora() 
    {
        PrecoHoraRepositorio pHR = new PrecoHoraRepositorio(this);
        pHR.GravaPrecoHora();
        Console.ReadKey();
    }
}
