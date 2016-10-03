using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HoursPMO.Models
{
    /// <summary>
    /// Class that holds Project properties and connections to User and Client classes
    /// </summary>
    public class Project : BaseClass
    {
        /// <summary>
        /// ID for Project
        /// </summary>
        public int ProjectID { get; set; }
        /// <summary>
        /// Property for Project name, type of string
        /// </summary>
        public string ProjectName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ForeignKey("ResponsiblePerson")]
        public int ResponsiblePersonID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual User ResponsiblePerson { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int ClientID { get; set; }
        /// <summary>
        /// Navigation property
        /// </summary>
        public virtual Client Client { get; set; }

        /// <summary>
        /// Navigation property
        /// </summary>
        public virtual ICollection<WeekPerUserPerProject> WeekPerUserPerProjects { get; set; }
    }
}