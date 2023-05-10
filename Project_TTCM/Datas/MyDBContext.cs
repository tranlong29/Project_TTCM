using Microsoft.EntityFrameworkCore;

namespace Project_TTCM.Datas
{
    public class MyDBContext : DbContext
    {
        public MyDBContext(DbContextOptions options):base(options) { }

        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<tblProduct> Products { get; set; }
        public DbSet<Configuration> Configurations { get; set; }
        public DbSet<Product_Config> product_Configs { get; set; }
        public DbSet<Product_Image> Product_Images { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Orders_Detail> Orders_Details { get; set; }


    }
}
