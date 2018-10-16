using MyStudy.Models;
using MyStudyService.Student.DTO;
using MyStudyService.Teacher;
using MyStudyService.Teacher.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyStudy.Controllers
{
    public class TeacherController : Controller
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
        public ActionResult Index(QueryTeacherViewModel model)
        {
            var result = TeacherService.Query(model);
            //var result = new List<TeacherViewModel>();

            //result = teacherlist;

            //if (!string.IsNullOrEmpty(model.KeyWords))
            //{
            //    result = result.Where(e => e.Name.Contains(model.KeyWords)).ToList();
            //}
            //if (model.GradeIdCheck.HasValue)
            //{
            //    result = result.Where(e => e.GradeId == model.GradeIdCheck).ToList();

            //}
            return View(result);
        }

        
        /// <summary>
        /// 查询教师详情
        /// </summary>
        /// <param name="id">教师Id</param>
        /// <returns>单个学生详情</returns>
        // GET: Teacher/Details/5
        public ActionResult Details(int id)
        {
            var result = TeacherService.Get(id);
            //var result = teacherlist.Where(e => e.Id == id).FirstOrDefault();
            if (result == null)
            {
                return RedirectToAction("Index", new { ErrorMsg = "用户不存在" });
            }
            return View(result);
        }
        #endregion


        // GET: Teacher/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Teacher/Create
        [HttpPost]
        public ActionResult Create(TeacherViewModel model)
        {
            try
            {
                // TODO: Add insert logic here
                TeacherService.Create(model);
                //teacherlist.Add(model);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Teacher/Edit/5
        public ActionResult Edit(int id)
        {
            var result = TeacherService.Get(id);
            //var result = teacherlist.Where(e => e.Id == id).FirstOrDefault();
            if (result == null)
            {
                return RedirectToAction("Index", new { ErrorMsg = "用户不存在" });
            }
            return View(result);
        }

        // POST: Teacher/Edit/5
        [HttpPost]
        public ActionResult Edit(TeacherViewModel model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.Name))
                {
                    return View();
                }
                // TODO: Add update logic here
                var result = TeacherService.Update(model);
                //var result = teacherlist.Where(e => e.Id == model.Id).FirstOrDefault();
                if (result == null)
                {
                    return RedirectToAction("Index", new { ErrorMsg = "用户不存在" });
                }
                //var index = teacherlist.IndexOf(result);
                //result.Name = model.Name;
                //result.GradeId = model.GradeId;
                //result.Subject = model.Subject;
                //teacherlist[index] = result;
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Teacher/Delete/5
        public ActionResult Delete(int id)
        {
            var result = TeacherService.Get(id);
            //var result = teacherlist.Where(e => e.Id == id).FirstOrDefault();
            if (result == null)
            {
                return RedirectToAction("Index", new { ErrorMsg = "用户不存在" });
            }
            return View(result);
        }

        // POST: Teacher/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var result = TeacherService.Delete(id);
                //var result = teacherlist.Where(e => e.Id == id).FirstOrDefault();
                if (result == null)
                {
                    return RedirectToAction("Index", new { ErrorMsg = "用户不存在" });
                }
                //teacherlist.Remove(result);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
