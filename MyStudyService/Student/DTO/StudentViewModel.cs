using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStudyService.Student.DTO
{
    /// <summary>
    /// 学生视图模型
    /// </summary>
    public class StudentViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        /// <summary>
        /// 分数
        /// </summary>
        public int Score { get; set; }
        /// <summary>
        /// 班级Id
        /// </summary>
        public int GradeId { get; set; }
    }
}
