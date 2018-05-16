using System;
using System.Collections.Generic;

namespace FYPeComm.Models
{
    public partial class Size
    {
        public Size()
        {
            ProdSizeColourLink = new HashSet<ProdSizeColourLink>();
        }

        public int SizeId { get; set; }
        public string SizeName { get; set; }

        public ICollection<ProdSizeColourLink> ProdSizeColourLink { get; set; }
    }
}
