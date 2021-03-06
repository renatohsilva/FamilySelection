using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilySelection.Domain.Entities
{
    public class Family : BaseEntity
    {
        [Required]
        public int Code { get; set; }

        [Required]
        public string Description { get; set; }
        
        public List<Person> People { get; set; }
    }
}
