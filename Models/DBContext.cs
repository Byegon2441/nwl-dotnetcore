// using System;
// using Microsoft.EntityFrameworkCore;
// namespace nwl_dotnetcore.Models
// {
//     public class DBContext : DbContext //DbContext เป็น class ติดต่อกับตัว database 
//     {
//         public DBContext(DbContextOptions<DBContext> options) : base(options)
//         {

//         }

//         public DbSet<Product> Products {get; set;}
//         public DbSet<Category> Categories {get;set;}
//     }
// }