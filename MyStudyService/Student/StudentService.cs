using MyStudyService.Student.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStudyService.Student
{
    public class StudentService
    {
        public static List<StudentViewModel> list = new List<StudentViewModel>()
        {
            new StudentViewModel () { Id =1,Name="张三",Score=90,GradeId =1},
            new StudentViewModel () { Id =2,Name="李四",Score=97,GradeId =1},
            new StudentViewModel () { Id =3,Name="王五",Score=90,GradeId =2},
            new StudentViewModel () { Id =4,Name="赵六",Score=55,GradeId =2},
            new StudentViewModel () { Id =5,Name="孙七",Score=23,GradeId =3}
        };



        public static List<StudentViewModel> Query(QueryViewModel model)
        {
            var result = new List<StudentViewModel>() { };
            result = list;
            if (!string.IsNullOrEmpty(model.KeyWords))
            {
                result = result.Where(e => e.Name.Contains(model.KeyWords)).ToList();
            }
            if (model.GradeId.HasValue)
            {
                result = result.Where(e => e.GradeId == model.GradeId).ToList();
            }
            return result;
        }

        public static StudentViewModel Get(int? id)
        {
            if (!id.HasValue )
            {
                return null;
            }
            var result = list.Where(e => e.Id == id).FirstOrDefault();
            return result;
        }

        public static List<StudentViewModel> Create(StudentViewModel model)
        {
            if(string.IsNullOrEmpty(model.Name ))
            {
                return null;
            }
            list.Add(model);
            return list;
        }

        public static List<StudentViewModel> Update(StudentViewModel model)
        {
            if (string.IsNullOrEmpty(model.Name))
            {
                return null;
            }
            var result = list.Where(e => e.Id == model.Id).FirstOrDefault();
            var index = list.IndexOf(result);
            result.Name = model.Name;
            result.Score = model.Score;
            list[index] = result;
            return list;
        }

        public static List<StudentViewModel> Delete(int? id)
        {
            if (!id.HasValue)
            {
                return null;
            }
            var result = list.Where(e => e.Id == id).FirstOrDefault();
            list.Remove(result);
            return list;
        }




    }
}
