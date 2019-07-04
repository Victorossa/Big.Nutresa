using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Big.Nutresa.Imagix.UI.Common.Models
{
    public class UserPointsData
    {
        public UserPointsData()
        {
            this.transacciones = new List<UserDataDetail>();
        }
        public List<UserDataDetail> transacciones { get; set; }
        public string error { get; set; }
    }

    public class UserDataDetail
    {
        public string puntosDisponibles { get; set; }
        public string puntosRedimidos { get; set; }
        public string url { get; set; }
        public string id { get; set; }
        public string puntosVencidos { get; set; }
        public string consecutivo { get; set; }
        public string idProgama { get; set; }
        public string nit { get; set; }
        public string puntosObtenidos { get; set; }
        public string nombreIdea { get; set; }
        public string puntosCompania { get; set; }
        public string nombrePrograma { get; set; }
        public string fechaAprobacion { get; set; }
        public string fechaVencimiento { get; set; }
        public string compania { get; set; }

    }
}
