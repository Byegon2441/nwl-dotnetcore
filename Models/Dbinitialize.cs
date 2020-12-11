// using Microsoft.EntityFrameworkCore;
// using Microsoft.Extensions.DependencyInjection;
// using System;
// using System.Linq;
// using System.Collections.Generic;

// namespace nwl_dotnetcore.Models
// {
//     public static class Dbinitialize
//     {
//         public static void INIT(IServiceProvider serviceProvider)
//         {
//             var context = new DBContext( serviceProvider.GetRequiredService<DbContextOptions<DBContext>>());
//             context.Database.EnsureCreated();
//         }
//     }
// }