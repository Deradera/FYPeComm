using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace FYPeComm.Models
{
    public class ProductModel
    {
        [Required]
        public int id;

        [Required]
        [DataType(DataType.Text)]
        public string prodName;

        [Required]
        [DataType(DataType.Currency)]
        public float price;
    }
}
