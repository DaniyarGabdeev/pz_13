using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pz_13
{
    internal class LaptopItem
    {
        [Key]
        public int CodeID { get; set; }
        public string model { get; set; }
        public int speed { get; set; }
        public int ram { get; set; }
        public int hd { get; set; }
        public int price { get; set; }
        public int screen { get; set; }
        public LaptopItem() { }
    }
}
