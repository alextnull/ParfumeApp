//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ParfumeApp
{
    using System;
    using System.Collections.Generic;
    
    public partial class Products
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Products()
        {
            this.ProductsOrders = new HashSet<ProductsOrders>();
        }
    
        public int ID { get; set; }
        public string Article { get; set; }
        public string NameProducts { get; set; }
        public int UnitMetricID { get; set; }
        public decimal Price { get; set; }
        public int SaleMax { get; set; }
        public int ManufacturerID { get; set; }
        public int ProviderID { get; set; }
        public int CategoryProductID { get; set; }
        public int ActiveSale { get; set; }
        public int Count { get; set; }
        public string Description { get; set; }
        public string PathImage { get; set; }
        public string ActualPathImage
        {
            get
            {
                if (string.IsNullOrWhiteSpace(PathImage))
                    return null;
                return System.IO.Path.Combine("/Resources", PathImage);
            }
        }
    
        public virtual CategoryProducts CategoryProducts { get; set; }
        public virtual Manufactures Manufactures { get; set; }
        public virtual Providers Providers { get; set; }
        public virtual UnitMetric UnitMetric { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductsOrders> ProductsOrders { get; set; }
    }
}
