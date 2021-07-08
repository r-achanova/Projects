using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
   public class Store
    {
        public Store()
        {
            this.ProductsStores = new HashSet<ProductStore>();
        }
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        [MinLength(3)]
        public string Name { get; set; }
        public string Town { get; set; }
        public string Address  { get; set; }
        public string Phone  { get; set; }
        public ICollection<ProductStore> ProductsStores
        { get; set; }
    }
}
