using ExtensionMethods.ExtensionMethods;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExtensionMethods
{
    public class DataContext : DbContext
    {
        public  DbSet<Agenda> Agendamento { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            const string strConnection = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ExtensionMethods; Integrated Security=True;pooling=true";
            optionsBuilder
                //.UseSqlServer(strConnection,p=>p.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)) // evitar explosao cartesiana
                .UseSqlServer(strConnection)
                .EnableSensitiveDataLogging()
                .LogTo(Console.WriteLine, LogLevel.Information);
        }
    }
}
