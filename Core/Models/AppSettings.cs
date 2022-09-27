using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class AppSettings
    {

        private static string _FormConnectionString;


        public static string FormConnectionString
        {
            get
            {
                return _FormConnectionString;
            }
            set
            {
                _FormConnectionString = value;
            }
        }
       
    }
}
