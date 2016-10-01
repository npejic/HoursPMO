using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HoursPMO.Models
{
    /// <summary>
    /// Class from which will all classes in Model inherit creation date
    /// </summary>
    public class BaseClass
    {
        public BaseClass()
        {
            this.Created = DateTime.Now;
        }
        public DateTime Created { get; set; }
    }
}