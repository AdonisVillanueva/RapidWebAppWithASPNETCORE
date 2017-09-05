// ======================================
// Author: Adonis Villanueva
// Email:  thedynamiclight@gmail.com
// Copyright (c) 2017 www.alwayswanderlust.com
// 
// ==> Inquiries: thedynamiclight@gmail.com
// ======================================
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using DAL.Models;
using DAL;
using Microsoft.EntityFrameworkCore;

namespace vega.Controllers
{
    [Route("api/[controller]")]
    public class MakesController : Controller
    {
        private readonly ApplicationDbContext context;

        public MakesController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet("/api/makes")]
        public async Task<IEnumerable<Make>> GetMakes()
        {
            return await context.Makes.Include(m => m.Models).ToListAsync();
        }

        public IActionResult Error()
        {
            return View();
        }

    }
}
