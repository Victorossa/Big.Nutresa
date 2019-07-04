
using System.ComponentModel.DataAnnotations;

namespace Big.Nutresa.Imagix.UI.Models
{
    public class CartModel
    {
        
        public string ProductGuid { get; set; }
        public string CustomerId { get; set; }
        public string ProductReference { get; set; }        
        [Range(1, short.MaxValue, ErrorMessageResourceType = typeof(Idioms.Resource),ErrorMessageResourceName = "DataAnnotations_Quantity_BeNumeric")]
        public int Quantity{ get; set; }
        public string SelectedPaymentRule { get; set; }
    }
}