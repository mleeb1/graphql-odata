# graphql and oData

This repository contains a sample GraphQL .NET project for ASP.NET Core and also a sample for using oData with RESTful endpoints

## See

graphql - https://app.pluralsight.com/library/courses/building-graphql-apis-aspdotnet-core/table-of-contents
oData - https://www.youtube.com/watch?v=ZCDWUBOJ5FU

## Setup

To setup the Database, go to: (in VS, Menu) Toools --> NuGet Package Manager --> Package Manager Console
Then run: Update-Database (select "A" for All if prompted). This will run the DB migrations and setup the local SQL DB.

## graphql - Debugging / Running the sample GraphQL query

Hit F5 to run and go to https://localhost:5001/ui/playground. Then enter the query (JSON) below and hit the run / play icon in UI Playground:

{
  products {
    description
    name
    rating
    reviews {
      title
    }
  }
}

# oData - Running some sample POSTMan queries

Hit F5 to run and then from POSTMan:

Get All Products - https://localhost:5001/api/products
Get All Products (with Select, Filter, OrderBy, Expand) - https://localhost:5001/api/products?$Select=Name,Description,Price,Type&$OrderBy=Name&$Filter=Price gt 300&$Expand=Sellers($select=Name)
Get All Sellers (with Expand) - https://localhost:5001/api/sellers?$Expand=Product($select=Name,Price,Rating)