using System.Collections.Generic;

namespace Big.Nutresa.Imagix.UI.Common.Models
{
    public class MyRedemptionRequest
    {
        public string CustomerId { get; set; }
        public int ProgramId { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
    }
    public class MyRedemptionResponse
    {
        public List<dynamic> Data { get; set; }
        public int TotalRecord { get; set; }
    }
}
