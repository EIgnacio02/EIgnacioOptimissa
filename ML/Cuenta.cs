using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Cuenta
    {
        public string account { get; set; }
        public int balance { get; set; }
        public string Owners { get; set; }
        public DateTime Fecha { get; set; }
        public List<object> CuentaList { get; set; }
    }
}
