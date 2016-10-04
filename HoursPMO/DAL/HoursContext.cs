using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HoursPMO.Models;
using System.Data.Entity;

namespace HoursPMO.DAL
{
    /// <summary>
    /// Class that is used to connect to base
    /// </summary>
    public class HoursContext : DbContext
    {
        /// <summary>
        /// 
        /// </summary>
        public HoursContext() : base("HoursContext") { }

        /// <summary>
        /// Connection to Clients table
        /// </summary>
        public DbSet<Client> Clients { get; set; }
        /// <summary>
        /// Connection to Projects table
        /// </summary>
        public DbSet<Project> Projects { get; set; }
        /// <summary>
        /// Connection to Users table
        /// </summary>
        public DbSet<User> Users { get; set; }
        /// <summary>
        /// Connection to WeekPerUserPerProject table
        /// </summary>
        public DbSet<WeekPerUserPerProject> WeekPerUserPerProjects { get; set; }
    }
}