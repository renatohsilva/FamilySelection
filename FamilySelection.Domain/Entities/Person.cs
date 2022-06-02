using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilySelection.Domain.Entities
{
    public class Person : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        public int FamilyId { get; set; }

        public Family Family { get; set; }
    }
}
