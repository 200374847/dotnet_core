using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIandDOTNETCore.Models
{
    public class GroceryStoreModel : DbContext
    {
        public GroceryStoreModel(DbContextOptions<GroceryStoreModel> options) : base(options)
        {
 }
        //reference the Department model for crud
        public DbSet<Department> Departments { get; set; }

        public DbSet<Orderss> Ordersses { get; set; }
    }
}
