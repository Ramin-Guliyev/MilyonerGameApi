using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Milyoner.Models
{
    public class Answer
    {
        
        public int Id { get; set; }
        [Required]
        [StringLength(300)]
        public string AnsverA { get; set; }
        [Required]
        [StringLength(300)]
        public string AnsverB { get; set; }
        [Required]
        [StringLength(300)]
        public string AnsverC { get; set; }
        [Required]
        [StringLength(300)]
        public string AnsverD { get; set; }

    }
}
