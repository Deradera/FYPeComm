using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        [DataType(DataType.Currency)]
        public double ProdPrice { get; set; }
        public string ProdImg { get; set; }
        public int SubCatId { get; set; }
        [Range(0, Int32.MaxValue, ErrorMessage = "Stock cannot be negative.")]
        public int Stock { get; set; }

        public ProdSubCat SubCat { get; set; }
        public ICollection<ProdSizeColourLink> ProdSizeColourLink { get; set; }
        public ICollection<Colour> Colour { get; set; }
        public ICollection<Size> Size { get; set; }
    }
}
