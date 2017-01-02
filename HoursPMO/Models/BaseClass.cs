using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HoursPMO.Models
{
    /// <summary>
    /// Class from which will all classes in Model inherit creation date
    /// </summary>
    abstract public class BaseClass
    {
        /// <summary>
        /// Constructor that gives value to Created property (current date and time)
        /// </summary>
        public BaseClass()
        {
            this.Created = DateTime.Now;
        }
        /// <summary>
        /// Property that stores current date and time of creation
        /// </summary>
        public DateTime Created { get; set; }
    }
}