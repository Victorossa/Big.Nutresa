

using System.Collections.Generic;

namespace Big.Nutresa.Imagix.UI.Common.Models
{
    public class CatalogFilter
    {
        public int ProgramId { get; set; }
        public string SearchQuery { get; set; }
        public int? CategoryId { get; set; }
        public string ProductCode { get; set; }
        public string ProductGuid { get; set; }
        public int? SegmentId { get; set; }
        public int? BrandId { get; set; }
        public decimal? MinValueMoney { get; set; }
        public decimal? MaxValueMoney { get; set; }
        public int? MinValuePoint { get; set; }
        public int? MaxValuePoint { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public bool Recommended { get; set; }
        public int TotalRecords { get; set; }
        public string ReferenceId { get; set; }
        public bool ShowProductsWithInventory { get; set; }
    }
    public class CatalogFilterListResponse
    {
        public List<dynamic> Data { get; set; }
        public int TotalRecord { get; set; }
    }

    public class CategoryResquest
    {
        public int ProgramId { get; set; }
        public int ParentCategory { get; set; }
    }

    public class CategoryResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public int ParentCategory { get; set; }
        public int? Order { get; set; }
        public bool Active { get; set; }
        public int? ProgramId { get; set; }
    }
}
