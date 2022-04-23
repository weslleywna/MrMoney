using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MrMoney.Util.Global
{
    public static class DbConnectionConfiguration
    {
        public static string? ConnectionString { get; set; }
        public static string? DatabaseName { get; set; }
        public static bool IsSSL { get; set; }

    }
}
