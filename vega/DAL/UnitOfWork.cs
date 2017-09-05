// ======================================
// Author: Adonis Villanueva
// Email:  thedynamiclight@gmail.com
// Copyright (c) 2017 www.alwayswanderlust.com
// 
// ==> Inquiries: thedynamiclight@gmail.com
// ======================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repositories;
using DAL.Repositories.Interfaces;

namespace DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly ApplicationDbContext _context;

        ICustomerRepository _customers;
        IMakeRepository _Makes;
        IOrdersRepository _orders;
        IModelRepository _Models;



        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }



        public ICustomerRepository Customers
        {
            get
            {
                if (_customers == null)
                    _customers = new CustomerRepository(_context);

                return _customers;
            }
        }
        

        public IMakeRepository Makes
        {
            get
            {
                if (_Makes == null)
                    _Makes = new MakeRepository(_context);

                return _Makes;
            }
        }

        public IModelRepository Models
        {
            get
            {
                if (_Models == null)
                    _Models = new ModelRepository(_context);

                return _Models;
            }
        }


        public IOrdersRepository Orders
        {
            get
            {
                if (_orders == null)
                    _orders = new OrdersRepository(_context);

                return _orders;
            }
        }
        

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}
