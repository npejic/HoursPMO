using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HoursPMO.Models
{
    /// <summary>
    /// Class for User data
    /// </summary>
    public class User : BaseClass
    {
        /// <summary>
        /// ID for User
        /// </summary>
        public int UserID { get; set; }
        //[StringLength(9, ErrorMessage = "First name cannot be longer than 9 characters.")]
        /// <summary>
        /// String for user name
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// Boolean property that defines if user is also responsible person
        /// </summary>
        public bool IsResponsiblePerson { get; set; }

        /// <summary>
        /// Navigation property for WeekPerUserPerProject class (or table?)
        /// </summary>
        public virtual ICollection<WeekPerUserPerProject> WeekPerUserPerProjects { get; set; }
    }
}