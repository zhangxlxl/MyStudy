using MyStudyService.Student.DTO;
using MyStudyService.Teacher.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStudyService.Teacher
{
    public class TeacherService
    {
        public static List<StudentViewModel> studentlist = new List<StudentViewModel>()
        {
            new StudentViewModel () { Id =1,Name="张三",Score=90,GradeId =1},
            new StudentViewModel () { Id =2,Name="李四",Score=97,GradeId =1},
            new StudentViewModel () { Id =3,Name="王五",Score=90,GradeId =2},
            new StudentViewModel () { Id =4,Name="赵六",Score=55,GradeId =2},
            new StudentViewModel () { Id =5,Name="孙七",Score=23,GradeId =2}
        };
        public static List<TeacherViewModel> teacherlist = new List<TeacherViewModel>()
        {
            new TeacherViewModel () {Id =1,Name ="张老师",GradeId =1,Subject ="语文" ,StudentCount=StudentCountOfGrade(1)},
            new TeacherViewModel () {Id =2,Name ="李老师",GradeId =2,Subject ="数学" ,StudentCount=StudentCountOfGrade(2)},
            new TeacherViewModel () {Id =3,Name ="王老师",GradeId =3,Subject ="英语" ,StudentCount=StudentCountOfGrade(3)},
            new TeacherViewModel () {Id =4,Name ="赵老师",GradeId =1,Subject ="化学" ,StudentCount=StudentCountOfGrade(1)}
        };

        /// <summary>
        /// 计算每个班学生数量
        /// </summary>
        /// <param name="gradeId">班级Id</param>
        /// <returns></returns>
        public static int StudentCountOfGrade(int gradeId)
        {
            var result = 0;
            result = studentlist.Count(e => e.GradeId == gradeId);
            var listGradeStudentCounts = studentlist.GroupBy(e => e.GradeId).Select(e => new { GradeId = e.Key, GradeStudentCount = e.Count() }).ToList();
            return result;
        }
        #region 查
        /// <summary>
        /// 查询学生列表
        /// </summary>
        /// <param name="model">请求模型</param>
        /// <returns>返回列表</returns>
        public static List<TeacherViewModel> Query(QueryTeacherViewModel model)
        {
            var result = teacherlist;

            //result = teacherlist;

            if (!string.IsNullOrEmpty(model.KeyWords))
            {
                result = result.Where(e => e.Name.Contains(model.KeyWords)).ToList();
            }
            if (model.GradeIdCheck.HasValue)
            {
                result = result.Where(e => e.GradeId == model.GradeIdCheck).ToList();

            }
            return result;
        }
        #endregion
        
        

        /// <summary>
        /// 详情
        /// </summary>
        /// <param name="id">教师Id</param>
        /// <returns></returns>
        public static TeacherViewModel Get(int? id)
        {
            if (!id.HasValue )
            {
                return null;
            }
            var result = teacherlist.Where(e => e.Id == id).FirstOrDefault();
            return result;
        }

        public static List<TeacherViewModel> Create(TeacherViewModel model)
        {
            teacherlist.Add(model);
            return teacherlist;
        }


        public static List<TeacherViewModel> Update(TeacherViewModel model)
        {
            if (string.IsNullOrEmpty(model.Name))
            {
                return null;
            }
            var result = teacherlist.Where(e => e.Id == model.Id).FirstOrDefault();
            var index = teacherlist.IndexOf(result);
            result.Name = model.Name;
            result.GradeId = model.GradeId;
            result.Subject = model.Subject;
            teacherlist[index] = result;
            return teacherlist;
        }

        public static List<TeacherViewModel> Delete(int? id)
        {
            var result= teacherlist.Where(e => e.Id == id).FirstOrDefault();
            teacherlist.Remove(result);
            return teacherlist;
        }

    }
}
