using System;

namespace CarvedRock.Api.DTO
{
    public class ProductDTO
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Rating { get; set; }
        public DateTime DateRetrieved { get; set; }
    }
}
