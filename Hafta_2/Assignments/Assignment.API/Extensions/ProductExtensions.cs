using Assignment.API.Controllers;
using Assignment.API.Models;
using AssignmentHafta2.API.QueryParameters;
using System;

namespace AssignmentHafta2.API.Extensions
{
    public static class ProductExtensions
    {
        public static void SortWithParametersExtension(this List<Product> list, SortParameters parameters)
        {

           switch (parameters.Name.ToLower())
           {
               case nameof(Product.Name):
                    list = parameters.Order == Ordering.Asc
                       ? list.OrderBy(p => p.Name).ToList()
                       : list.OrderByDescending(p => p.Name).ToList();
                   break;
               case nameof(Product.Id):
                    list = parameters.Order == Ordering.Asc
                       ? list.OrderBy(p => p.Id).ToList()
                       : list.OrderByDescending(p => p.Id).ToList();
                   break;

               case nameof(Product.Price):
                    list = parameters.Order == Ordering.Asc
                       ? list.OrderBy(p => p.Price).ToList()
                       : list.OrderByDescending(p => p.Id).ToList();
                   break;

               default:

                   throw new ArgumentException($"Invalid sorting parameters{parameters.Name}");
           }
            
        }
    }
}
