using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStudyService.Grade.DTO
{
    public class GradeViewModel
    {
        public int GradeId { get; set; }
        [DisplayName("班级名字")]
        public string GradeName { get; set; } 

    }
}
