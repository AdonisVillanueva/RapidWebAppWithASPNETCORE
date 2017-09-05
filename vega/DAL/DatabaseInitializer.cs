// ======================================
// Author: Adonis Villanueva
// Email:  thedynamiclight@gmail.com
// Copyright (c) 2017 www.alwayswanderlust.com
// 
// ==> Inquiries: thedynamiclight@gmail.com
// ======================================

using DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Core;
using DAL.Core.Interfaces;

namespace DAL
{
    public interface IDatabaseInitializer
    {
        Task SeedAsync();
    }




    public class DatabaseInitializer : IDatabaseInitializer
    {
        private readonly ApplicationDbContext _context;
        private readonly IAccountManager _accountManager;
        private readonly ILogger _logger;

        public DatabaseInitializer(ApplicationDbContext context, IAccountManager accountManager, ILogger<DatabaseInitializer> logger)
        {
            _accountManager = accountManager;
            _context = context;
            _logger = logger;
        }

        public async Task SeedAsync()
        {
            await _context.Database.MigrateAsync().ConfigureAwait(false);

            if (!await _context.Users.AnyAsync())
            {
                const string adminRoleName = "administrator";
                const string userRoleName = "user";

                await ensureRoleAsync(adminRoleName, "Default administrator", ApplicationPermissions.GetAllPermissionValues());
                await ensureRoleAsync(userRoleName, "Default user", new string[] { });

                await createUserAsync("admin", "tempP@ss123", "Inbuilt Administrator", "thedynamiclight@gmail.com", "+1 (916) 678-1504", new string[] { adminRoleName });
                await createUserAsync("user", "tempP@ss123", "Inbuilt Standard User", "adonis_abril@yahoo.com", "+1 (916) 678-1504", new string[] { userRoleName });
            }



            if (!await _context.Customers.AnyAsync() && !await _context.Models.AnyAsync())
            {
                Customer cust_1 = new Customer
                {
                    Name = "Adonis Villanueva",
                    Email = "thedynamiclight@gmail.com",
                    Gender = Gender.Male,
                    DateCreated = DateTime.UtcNow,
                    DateModified = DateTime.UtcNow
                };

                Customer cust_2 = new Customer
                {
                    Name = "Itachi Uchiha",
                    Email = "uchiha@narutoverse.com",
                    PhoneNumber = "+81123456789",
                    Address = "Some fictional Address, Street 123, Konoha",
                    City = "Konoha",
                    Gender = Gender.Male,
                    DateCreated = DateTime.UtcNow,
                    DateModified = DateTime.UtcNow
                };

                Customer cust_3 = new Customer
                {
                    Name = "John Doe",
                    Email = "johndoe@anonymous.com",
                    PhoneNumber = "+18585858",
                    Address = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio.
                    Praesent libero. Sed cursus ante dapibus diam. Sed nisi. Nulla quis sem at nibh elementum imperdiet",
                    City = "Lorem Ipsum",
                    Gender = Gender.Male,
                    DateCreated = DateTime.UtcNow,
                    DateModified = DateTime.UtcNow
                };

                Customer cust_4 = new Customer
                {
                    Name = "Jane Doe",
                    Email = "Janedoe@anonymous.com",
                    PhoneNumber = "+18585858",
                    Address = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio.
                    Praesent libero. Sed cursus ante dapibus diam. Sed nisi. Nulla quis sem at nibh elementum imperdiet",
                    City = "Lorem Ipsum",
                    Gender = Gender.Male,
                    DateCreated = DateTime.UtcNow,
                    DateModified = DateTime.UtcNow
                };



                Make ford = new Make
                {
                    Name = "Ford Motors",
                    Description = "Ford Motors. First car maker in the world.",
                    DateCreated = DateTime.UtcNow,
                    DateModified = DateTime.UtcNow
                };

                Make mercedes = new Make
                {
                    Name = "Mercedes-Benz",
                    Description = "A global automobile manufacturer and a division of the German company Daimler AG.",
                    DateCreated = DateTime.UtcNow,
                    DateModified = DateTime.UtcNow
                };

                Make bmw = new Make
                {
                    Name = "BMW Motors",
                    Description = "Bayerische Motoren Werke AG (BMW) is a luxury car maker.",
                    DateCreated = DateTime.UtcNow,
                    DateModified = DateTime.UtcNow
                };


                Model f150 = new Model
                {
                    Name = "F 150",
                    Description = "Mid Sized Truck with a V6 Engine",
                    BuyingPrice = 109775,
                    SellingPrice = 114234,
                    UnitsInStock = 12,
                    IsActive = true,
                    Make = ford,
                    DateCreated = DateTime.UtcNow,
                    DateModified = DateTime.UtcNow
                };

                Model mustang = new Model
                {
                    Name = "Mustang 64",
                    Description = "Classic American Muscle Car",
                    BuyingPrice = 78990,
                    SellingPrice = 86990,
                    UnitsInStock = 4,
                    IsActive = true,
                    Make = ford,
                    DateCreated = DateTime.UtcNow,
                    DateModified = DateTime.UtcNow
                };

                
                Model z4 = new Model
                {
                    Name = "Z4 (E89)",
                    Description = "Sports Roadster",
                    BuyingPrice = 309775,
                    SellingPrice = 114234,
                    UnitsInStock = 12,
                    IsActive = true,
                    Make = bmw,
                    DateCreated = DateTime.UtcNow,
                    DateModified = DateTime.UtcNow
                };

                Model GranTurismo = new Model
                {
                    Name = "5 Series Gran Turismo",
                    Description = "Progressive Activity Sedan",
                    BuyingPrice = 78990,
                    SellingPrice = 86990,
                    UnitsInStock = 4,
                    IsActive = true,
                    Make = bmw,
                    DateCreated = DateTime.UtcNow,
                    DateModified = DateTime.UtcNow
                };

               

                Model AMG = new Model
                {
                    Name = "AMG GT",
                    Description = "The Mercedes-AMG GT (C190 / R190) is a 2-door, 2-seater fastback coupé and roadster.",
                    BuyingPrice = 309775,
                    SellingPrice = 114234,
                    UnitsInStock = 12,
                    IsActive = true,
                    Make = mercedes,
                    DateCreated = DateTime.UtcNow,
                    DateModified = DateTime.UtcNow
                };

                Model cla = new Model
                {
                    Name = "CLA-Class",
                    Description = "The Mercedes-Benz CLA-Class is a compact car developed and manufactured by Mercedes-Benz.",
                    BuyingPrice = 78990,
                    SellingPrice = 86990,
                    UnitsInStock = 4,
                    IsActive = true,
                    Make = mercedes,
                    DateCreated = DateTime.UtcNow,
                    DateModified = DateTime.UtcNow
                };


                Order ordr_1 = new Order
                {
                    Discount = 500,
                    Cashier = await _context.Users.FirstAsync(),
                    Customer = cust_1,
                    DateCreated = DateTime.UtcNow,
                    DateModified = DateTime.UtcNow,
                    OrderDetails = new List<OrderDetail>()
                    {
                        new OrderDetail() {UnitPrice = f150.SellingPrice, Quantity=1, Model = f150 },
                        new OrderDetail() {UnitPrice = GranTurismo.SellingPrice, Quantity=1, Model = GranTurismo },
                    }
                };

                Order ordr_2 = new Order
                {
                    Cashier = await _context.Users.FirstAsync(),
                    Customer = cust_2,
                    DateCreated = DateTime.UtcNow,
                    DateModified = DateTime.UtcNow,
                    OrderDetails = new List<OrderDetail>()
                    {
                        new OrderDetail() {UnitPrice = mustang.SellingPrice, Quantity=1, Model = mustang },
                    }
                };


                _context.Customers.Add(cust_1);
                _context.Customers.Add(cust_2);
                _context.Customers.Add(cust_3);
                _context.Customers.Add(cust_4);

                _context.Models.Add(mustang);
                _context.Models.Add(f150);

                _context.Orders.Add(ordr_1);
                _context.Orders.Add(ordr_2);

                await _context.SaveChangesAsync();
            }
        }



        private async Task ensureRoleAsync(string roleName, string description, string[] claims)
        {
            if ((await _accountManager.GetRoleByNameAsync(roleName)) == null)
            {
                ApplicationRole applicationRole = new ApplicationRole(roleName, description);

                var result = await this._accountManager.CreateRoleAsync(applicationRole, claims);

                if (!result.Item1)
                    throw new Exception($"Seeding \"{description}\" role failed. Errors: {string.Join(Environment.NewLine, result.Item2)}");
            }
        }

        private async Task<ApplicationUser> createUserAsync(string userName, string password, string fullName, string email, string phoneNumber, string[] roles)
        {
            ApplicationUser applicationUser = new ApplicationUser
            {
                UserName = userName,
                FullName = fullName,
                Email = email,
                PhoneNumber = phoneNumber,
                EmailConfirmed = true,
                IsEnabled = true
            };

            var result = await _accountManager.CreateUserAsync(applicationUser, roles, password);

            if (!result.Item1)
                throw new Exception($"Seeding \"{userName}\" user failed. Errors: {string.Join(Environment.NewLine, result.Item2)}");


            return applicationUser;
        }
    }
}
