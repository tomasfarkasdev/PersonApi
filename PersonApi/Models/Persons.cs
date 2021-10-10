using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonApi.Models
{
    [Table("Persons")]
    public class Persons
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(255)]
        public string LastName { get; set; }

        [Required]
        [StringLength(20)]
        public string PersonCode { get; set; }      
        
        /// <summary>
        /// Navigation Properties
        /// </summary>
        public ICollection<TimeOffs> TimeOff { get; set; }

        public Persons Manager { get; set; }
        //public virtual Persons Manager { get; set; }

        //public ICollection<Persons> Person { get; set; }


    }
}
