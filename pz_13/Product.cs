using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pz_13
{
    internal class ProductItem
    {
        [Key]
        public string model { get; set; }
        public string maker { get; set; }
        public string type { get; set; }
        public ProductItem() { }
    }
}
