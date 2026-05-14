using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Quizify2
{
        public static class Koneksi
        {
        public static string ConnectionString = "Data Source=subha\\SQLEXPRESS;Initial Catalog=DESKTOP_XX;Integrated Security=True";
        }


    public static class GlobalSession
    {
        public static string Username;
        public static bool isLogin;
    }
}

