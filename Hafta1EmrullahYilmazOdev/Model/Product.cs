using System.ComponentModel.DataAnnotations;

namespace Hafta1EmrullahYilmazOdev.Model
{
    public class Product
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Price { get; set; }
        public Product(int Id, string Name, int Price)
        {
            this.Id = Id;
            this.Name = Name;
            this.Price = Price;

        }
    }
}
