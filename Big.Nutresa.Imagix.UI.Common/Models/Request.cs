using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Big.Nutresa.Imagix.UI.Common.Models
{
    public class Request<T>
    {
        public string token { get; set; }
        public T ObjectRequest { get; set; }
    }
}
