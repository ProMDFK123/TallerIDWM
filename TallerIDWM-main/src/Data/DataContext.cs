using api.src.Models;
using Microsoft.EntityFrameworkCore;

namespace api.src.Data{
    public class DataContext(DbContextOptions<DataContext> options) : DbContext(options){
        public DbSet<Store> Stores {get; set;} 
        public DbSet<Product> Products {get; set;}
    }
}