using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Milyoner.Models
{
    public class AddQuestionModel
    {
        [Required]
        [StringLength(2000)]
        public string QuestionHeader { get; set; }
        [Required]
        [StringLength(300)]
        public string AnswerA { get; set; }
        [Required]
        [StringLength(300)]
        public string AnswerB { get; set; }
        [Required]
        [StringLength(300)]
        public string AnswerC { get; set; }
        [Required]
        [StringLength(300)]
        public string AnswerD { get; set; }
        [Required]
        public byte TrueAnswer { get; set; }
    }
}
