using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStudyService.Teacher.DTO
{
    public class TeacherViewModel
    {
        /// <summary>
        /// 教师Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 教师名字
        /// </summary>
        [DisplayName("名字")]
        public string Name { get; set; }
        /// <summary>
        /// 班级
        /// </summary>
        public int GradeId { get; set; }
        /// <summary>
        /// 课程
        /// </summary>
        public string Subject { get; set; }
        public int StudentCount { get; set; }
    }
}
