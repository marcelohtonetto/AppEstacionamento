using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace AppEstacionamento.Repositorio;

public static class DbConfig
{
    public static string GetConnectionString() => "Data Source = .\\SQLEXPRESS; Initial Catalog = Estacionamento; " +
                                                  "Persist Security Info = True; User ID = itprovider;" +
                                                  " Password = ***********;" +
                                                  " Encrypt = True;" +
                                                  " Trusted_Connection = true; " +
                                                  " TrustServerCertificate=True";
    
}



