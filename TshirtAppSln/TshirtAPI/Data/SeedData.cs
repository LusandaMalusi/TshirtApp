using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TshirtAPI.Models;

namespace TshirtAPI.Data
{
    public static class SeedData
    {
        public static void Initialize(ProductsContext context)
        {
            if (!context.Productss.Any())
            {
                context.Productss.AddRange(
                    new Products
                    {
                        Name = "Squeaky Bone",
                        Gender = "Male",
                        Tshirtcolor = "red",
                        Tshirtsize = "M",
                    },
                    new Products
                    {
                        Name = "Knotted Rope",
                        Gender = "Female",
                        Tshirtcolor = "green",
                        Tshirtsize = "S",
                    }
                );
                context.SaveChanges();
            }
        }
    }
}