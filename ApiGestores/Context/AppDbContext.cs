﻿using ApiGestores.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiGestores.Context
{
    public class AppDbContext :DbContext
    {
        public AppDbContext( DbContextOptions<AppDbContext>options): base(options)
        {
            
        }
        public DbSet<Gestores_bd> gestores_bd { get; set; }
    }
}
