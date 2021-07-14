using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Milyoner.Models
{
    public class Question
    {
        public int Id { get; set; }
        [Required]
        [StringLength(2000)]
        public string QuestionHeader { get; set; }
        [Required]
        public byte TrueAnswerIndex { get; set; }

        public bool IsChecked { get; set; } = false;

    }
}
