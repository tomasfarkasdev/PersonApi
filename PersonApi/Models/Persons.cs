using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonApi.Models
{
   
    public class Persons
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PersonCode { get; set; }

        public virtual Persons Manager { get; set; }


    }
}
