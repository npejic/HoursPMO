using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HoursPMO.Models;
using System.Data.Entity;

namespace HoursPMO.DAL
{
    public class HoursContext : DbContext
    {
        public HoursContext() : base("HoursContext") { }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Project> Projects { get; set; }
        public System.Data.Entity.DbSet<HoursPMO.Models.User> Users { get; set; }
        public System.Data.Entity.DbSet<HoursPMO.Models.WeekPerUserPerProject> WeekPerUserPerProjects { get; set; }
    }
}