using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Form
{
    public class FormType
    {
        public int Id { get; set; }
        public string Type { get; set; }

        public string Value { get; set; }

        public string Data { get; set; }

        public string hasClass { get; set; }
    }
}
