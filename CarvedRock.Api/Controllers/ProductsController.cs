using System;
using System.Collections.Generic;
using System.Linq;
using CarvedRock.Api.Data;
using CarvedRock.Api.Data.Entities;
using CarvedRock.Api.DTO;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;

namespace CarvedRock.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly CarvedRockDbContext _dbContext;

        public ProductsController(CarvedRockDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// Sample request:
        ///     GET api/products
        [HttpGet]
        [EnableQuery]
        public IEnumerable<Product> GetProducts()
        {
            // NOTE: If you run on an IQueryable DataSet in EF then it runs on the database
            return _dbContext.Products;
        }

//       // If you want to convert it to a DTO before returning ...
//
//        [HttpGet]
//        [EnableQuery]
//        public IEnumerable<ProductDTO> GetProducts()
//        {
//            // NOTE: If you materialize your data coming from EF as a list then it runs in memory,
//            // and in this example it will run a SELECT * FROM Products first, then filter in memory here!
//            var queriedProducts = _dbContext.Products;
//            return queriedProducts.Select(product => ConvertToProductDTO(product));
//        }
//
//        private static ProductDTO ConvertToProductDTO(Product product)
//        {
//            return new ProductDTO
//            {
//                DateRetrieved = DateTime.Now,
//                Description = product.Description,
//                Name = product.Name,
//                Price = product.Price,
//                Rating = product.Rating,
//                Type = product.Type.ToString()
//            };
//        }
    }
}
