using CarvedRock.Api.Data.Entities;
using GraphQL.Types;

namespace CarvedRock.Api.GraphQL.Types
{
    public class SellerType: ObjectGraphType<Seller>
    {
        public SellerType()
        {
            Field(t => t.Id);
            Field(t => t.Name);
        }
    }
}
