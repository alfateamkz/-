﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.DB.StaticTextsDBs
{
    public class StaticEDMDbContext : DbContext
    {
        public StaticEDMDbContext()
        {
            Database.EnsureCreated();
        }
        public StaticEDMDbContext(DbContextOptions<StaticEDMDbContext> options) : this()
        {
            Database.EnsureCreated();
        }
    }
}
