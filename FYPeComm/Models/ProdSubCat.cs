using System;
using System.Collections.Generic;

namespace FYPeComm.Models
{
    public partial class ProdSubCat
    {
        public ProdSubCat()
        {
            Product = new HashSet<Product>();
        }

        public int ProdSubCatId { get; set; }
        public string ProdSubCatName { get; set; }
        public int ProdParentCatId { get; set; }

        public ProdCat ProdParentCat { get; set; }
        public ICollection<Product> Product { get; set; }
    }
}
