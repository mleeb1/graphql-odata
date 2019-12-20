using System.Collections.Generic;
using CarvedRock.Api.Data;
using CarvedRock.Api.Data.Entities;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;

namespace CarvedRock.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellersController : ControllerBase
    {
        private readonly CarvedRockDbContext _dbContext;

        public SellersController(CarvedRockDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// Sample request:
        ///     GET api/sellers
        [HttpGet]
        [EnableQuery]
        public IEnumerable<Seller> GetSellers()
        {
            // NOTE: If you run on an IQueryable DataSet in EF then it runs on the database
            return _dbContext.Sellers;
        }
    }
}
