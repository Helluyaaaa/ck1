using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test;
namespace ConsoleApp1
{
    
    class Program
    {
        public static string connectionString = "Data Source=.;Server=(Local);Integrated Security=true;";
        static void Main(string[] args)
        {
            using(SqlConnection connection=new SqlConnection(connectionString))
            {
                connection.Open();
            }

        }
    }
}
