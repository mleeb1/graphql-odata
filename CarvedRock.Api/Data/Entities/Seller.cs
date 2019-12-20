using System.ComponentModel.DataAnnotations;

namespace CarvedRock.Api.Data.Entities
{
    public class Seller
    {
        public int Id { get; set; }
        
        [StringLength(50), Required]
        public string Name { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }
    }
}
