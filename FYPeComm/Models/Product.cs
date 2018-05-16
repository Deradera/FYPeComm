using System;
using System.Collections.Generic;

namespace FYPeComm.Models
{
    public partial class Product
    {
        public Product()
        {
            ProdSizeColourLink = new HashSet<ProdSizeColourLink>();
        }

        public Guid ProdId { get; set; }
        public string ProdName { get; set; }
        public string ProdDesc { get; set; }
        public double ProdPrice { get; set; }
        public string ProdImg { get; set; }
        public int SubCatId { get; set; }

        public ProdSubCat SubCat { get; set; }
        public ICollection<ProdSizeColourLink> ProdSizeColourLink { get; set; }
    }
}
