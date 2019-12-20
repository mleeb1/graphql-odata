using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarvedRock.Api.Data;
using CarvedRock.Api.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarvedRock.Api.Repositories
{
    public class SellerRepository
    {
        private readonly CarvedRockDbContext _dbContext;

        public SellerRepository(CarvedRockDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Seller>> GetForProduct(int productId)
        {
            return await _dbContext.Sellers.Where(pr => pr.ProductId == productId).ToListAsync();
        }

        public async Task<ILookup<int, Seller>> GetForProducts(IEnumerable<int> productIds)
        {
            var reviews = await _dbContext.Sellers.Where(pr => productIds.Contains(pr.ProductId)).ToListAsync();
            return reviews.ToLookup(r => r.ProductId);
        }
    }
}
