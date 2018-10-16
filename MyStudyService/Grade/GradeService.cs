using MyStudyService.Grade.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStudyService.Grade
{
    public class GradeService
    {
        public static List<GradeViewModel> list = new List<GradeViewModel>()
        {
            new GradeViewModel () {GradeId =1,GradeName ="三（4）" },
            new GradeViewModel () {GradeId =2,GradeName ="五（3）" },
            new GradeViewModel () {GradeId =3,GradeName ="六（4）" }
        };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static List<GradeViewModel> Query(QueryGradeViewModel model)
        {
            var result = new List<GradeViewModel>() { };
            result = list;
            if (!string.IsNullOrEmpty(model.KeyWords))
            {
                result = list.Where(e => e.GradeName.Contains(model.KeyWords)).ToList();
            }
            return result;
        }

        public static GradeViewModel Get(int? id)
        {
            if(!id.HasValue)
            {
                return null;
            }
            var result = list.Where(e => e.GradeId == id).FirstOrDefault();
            return result;
        }


        public static List<GradeViewModel > Create(GradeViewModel model)
        {
            if (string.IsNullOrEmpty (model.GradeName))
            {
                return null;
            }
            list.Add(model);
            return list;
        }

        public static List<GradeViewModel> Update(GradeViewModel model)
        {
            if (string.IsNullOrEmpty(model.GradeName))
            {
                return null;
            }
            var result = list.Where(e => e.GradeId == model.GradeId).FirstOrDefault();           
            var index = list.IndexOf(result);
            result.GradeName = model.GradeName;
            list[index] = result;
            return list;
        }

        public static List<GradeViewModel> Delete(int? id)
        {
            if (!id.HasValue)
            {
                return null;
            }
            var result = list.Where(e => e.GradeId == id).FirstOrDefault();
            list.Remove(result);
            return list;
        }

    }
}
