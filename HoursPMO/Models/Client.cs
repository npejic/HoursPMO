using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HoursPMO.Models
{
    /// <summary>
    /// This class represents all the clients
    /// </summary>
    public class Client : BaseClass
    {
        /// <summary>
        /// ID number of client 
        /// </summary>
        public int ClientID { get; set; }
        /// <summary>
        /// String that represents client name
        /// </summary>
        public string ClientName { get; set; }

        /// <summary>
        /// Navigation property for Project class
        /// </summary>
        public virtual ICollection<Project> Projects { get; set; }
    }
}