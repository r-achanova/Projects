using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Data.Models
{
  public  class Category
    {
        public Category()
        {
            this.Products = new HashSet<Product>();
        }
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        [MinLength(3)]
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
