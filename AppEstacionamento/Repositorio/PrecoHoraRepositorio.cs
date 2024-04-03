using AppEstacionamento.Model;
using Dapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AppEstacionamento.Repositorio;

public class PrecoHoraRepositorio
{
    public PrecoHoraRepositorio()
    {
            
    }
    public PrecoHoraRepositorio(PrecoHora precohora)
    {
        PrecoHora = precohora; 
    }
    public PrecoHora PrecoHora { get; set; }

    public void GravaPrecoHora() 
    {
        using (SqlConnection connection = new SqlConnection(DbConfig.GetConnectionString()))
        {
            try
            {
                var insertPrecoHora = string.Format(CultureInfo.InvariantCulture, " insert into PrecoHora (Preco) values ({0}) ", PrecoHora.ValorHora);
                
                connection.Execute(insertPrecoHora);

                Console.WriteLine($"Valor da hora atualizado para {PrecoHora.ValorHora}");
                Console.ReadKey();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }   
        }      
    }
}
