using Alfateam.DB.Helpers;
using Alfateam.DB.StaticTextsDBs;
using Alfateam.Services.CurrencyRates.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.DB.ServicesDBs
{
    public class CurrencyRatesDbContext : DbContext
    {
        public CurrencyRatesDbContext()
        {
            Database.EnsureCreated();
        }
        public CurrencyRatesDbContext(DbContextOptions<CurrencyRatesDbContext> options) : this()
        {
            Database.EnsureCreated();
        }


        public DbSet<Rate> Rates { get; set; }


        public double GetRate(string from, string to)
        {
            var rate = Rates.Where(o => o.From == from && o.To == to).AsEnumerable().LastOrDefault();
            if(rate != null)
            {
                return rate.Value;
            }

            //Конвертация 
            rate = Rates.Where(o => o.From == "EUR" && o.To == to).AsEnumerable().LastOrDefault();
            var conversionRate = Rates.Where(o => o.From == "EUR" && o.To == from).AsEnumerable().LastOrDefault();

            if (conversionRate != null && rate != null)
            {
                return rate.Value * conversionRate.Value;
            }

            return 0;
        }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(ConnectionStrings.CurrencyRates, new MySqlServerVersion(new Version(8, 0, 11)));
        }
    }

}
