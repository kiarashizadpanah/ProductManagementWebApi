using ProductManagement.Domain.Enums;
using System;
using System.Collections.Generic;

namespace ProductManagementWebApi.Models
{
    public partial class Product
    {
        public Product()
        {
            ProductAttributeDetails = new HashSet<ProductAttributeDetail>();
            RelatedProductBaseProducts = new HashSet<RelatedProduct>();
            RelatedProductRelatedProductNavigations = new HashSet<RelatedProduct>();
        }

        public int Id { get; set; }
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public int UnitStock { get; set; }
        public int CategoryId { get; set; }
        public int Classification { get; set; }
        public bool? IsActive { get; set; }
        public string? Description { get; set; }
        public DateTime CreateDate { get; set; }
        public int BaseUnitPrice { get; set; }

        public virtual Category Category { get; set; } = null!;
        public virtual ICollection<ProductAttributeDetail> ProductAttributeDetails { get; set; }
        public virtual ICollection<RelatedProduct> RelatedProductBaseProducts { get; set; }
        public virtual ICollection<RelatedProduct> RelatedProductRelatedProductNavigations { get; set; }

    }
}
