using System;
using System.Collections.Generic;

namespace FYPeComm.Models
{
    public partial class ProdCat
    {
        public ProdCat()
        {
            ProdSubCat = new HashSet<ProdSubCat>();
        }

        public int ProdCatId { get; set; }
        public string ProdCatName { get; set; }

        public ICollection<ProdSubCat> ProdSubCat { get; set; }
    }
}
