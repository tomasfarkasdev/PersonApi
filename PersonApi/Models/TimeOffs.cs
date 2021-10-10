using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonApi.Models
{

    [Table("TimeOffs")]
    public class TimeOffs
    {
        [Key]
        public int Id { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        /// <summary>
        /// Navigation Properties
        /// </summary>
        //public virtual Persons Person { get; set; }
        public Persons Person { get; set; }
    }
}
