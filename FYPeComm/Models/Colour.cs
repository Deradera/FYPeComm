using System;
using System.Collections.Generic;

namespace FYPeComm.Models
{
    public partial class Colour
    {
        public Colour()
        {
            ProdSizeColourLink = new HashSet<ProdSizeColourLink>();
        }

        public int ColourId { get; set; }
        public string ColourName { get; set; }

        public ICollection<ProdSizeColourLink> ProdSizeColourLink { get; set; }
    }
}
