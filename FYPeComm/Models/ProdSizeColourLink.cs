using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FYPeComm.Models
{
    public partial class ProdSizeColourLink
    {
        public Guid ProdId { get; set; }
        public int SizeId { get; set; }
        public int ColourId { get; set; }
        public int Id { get; set; }

        public Colour Colour { get; set; }
        public Product Prod { get; set; }
        public Size Size { get; set; }
    }
}
