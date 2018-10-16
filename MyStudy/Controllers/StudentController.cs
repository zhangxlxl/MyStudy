using MyStudy.Models;
using MyStudyService.Student;
using MyStudyService.Student.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyStudy.Controllers
{
    public class StudentController : Controller
    {


        //public static List<StudentViewModel> list = new List<StudentViewModel>()
        //{
        //    new StudentViewModel () { Id =1,Name="张三",Score=90,GradeId =1},
        //    new StudentViewModel () { Id =2,Name="李四",Score=97,GradeId =1},
        //    new StudentViewModel () { Id =3,Name="王五",Score=90,GradeId =2},
        //    new StudentViewModel () { Id =4,Name="赵六",Score=55,GradeId =2},
        //    new StudentViewModel () { Id =5,Name="孙七",Score=23,GradeId =3}
        //};


        //public ActionResult Test(string name,int id)
        //{
        //    ViewBag.name = name;
        //    ViewBag.id = id;
        //    return View("~/Views/Shared/IncludePart.cshtml");
        //}

        #region 查
        /// <summary>
        /// 查询学生列表
        /// </summary>
        /// <param name="model">请求模型</param>
        /// <returns>学生列表</returns>
        public ActionResult Index(QueryViewModel model)
        {
             

            var result=StudentService.Query(model);
             //result = list;

            //if (!string.IsNullOrEmpty(model.KeyWords))
            //{
            //    result = result.Where(e => e.Name.Contains(model.KeyWords)).ToList();
            //}
            //if (model.GradeId.HasValue)
            //{
            //    result = result.Where(e => e.GradeId == model.GradeId).ToList();
            //}

            return View(result);
        }
        /// <summary>
        /// 查询学生详情
        /// </summary>
        /// <param name="id">学生Id</param>
        /// <returns>单个学生详情</returns>
        public ActionResult Details(int id)
        {
            var result = StudentService.Get(id);

            //var result = list.Where(e => e.Id == id).FirstOrDefault();
            if (result == null)
            {
                return RedirectToAction("Index", new { ErrorMsg = "用户不存在" });
            }

            return View(result);
        }
        #endregion

        #region 增加
        /// <summary>
        ///创建学生
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// 创建学生(带视图)
        /// </summary>
        /// <param name="model">学生视图模型</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(StudentViewModel model)
        {
            try
            {
                // TODO: Add insert logic here
                var result=StudentService.Create(model);
                //list.Add(model);
                //return View(result);
                return RedirectToAction("Index");
                
            }
            catch
            {
                return View();
            }
        }

        #endregion


        #region 编辑

        /// <summary>
        /// 编辑学生模型
        /// </summary>
        /// <param name="id">学生的主键Id</param>
        /// <returns>学生模型</returns>
        public ActionResult Edit(int id)
        {
            var result = StudentService.Get(id );
            //var result = list.Where(e => e.Id == id).FirstOrDefault();
            if (result == null)
            {
                return RedirectToAction("Index", new { ErrorMsg = "用户不存在" });
            }

            return View(result);
        }

        /// <summary>
        /// 编辑学生模型(带视图)
        /// </summary>
        /// <param name="model">学生视图模型</param>
        /// <returns>跳转到列表</returns>
        [HttpPost]
        public ActionResult Edit(StudentViewModel model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.Name))
                {
                    return View();
                }
                // TODO: Add update logic here
                //var result = list.Where(e => e.Id == model.Id).FirstOrDefault();
                var result=StudentService.Update(model);
                if (result == null)
                {
                    return RedirectToAction("Index", new { ErrorMsg = "用户不存在" });
                }
                
                //var index = list.IndexOf(result);
                //result.Name = model.Name;
                //result.Score = model.Score;
                //list[index] = result;

                return RedirectToAction("Index", new { ErrorMsg = "编辑成功" });
            }
            catch
            {
                return View();
            }
        }
        #endregion


        #region 删除

        /// <summary>
        /// 删除学生模型
        /// </summary>
        /// <param name="id">学生的主键Id</param>
        /// <returns></returns>
        public ActionResult Delete(int id)
        {
            var result = StudentService.Get(id);
            //var result = list.Where(e => e.Id == id).FirstOrDefault();
            if (result == null)
            {
                return RedirectToAction("Index", new { ErrorMsg = "用户不存在" });
            }

            return View(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="collection"></param>
        /// <returns>学生列表</returns>
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                //var result = list.Where(e => e.Id == id).FirstOrDefault();
                var result=StudentService.Delete(id);
                if (result == null)
                {
                    return RedirectToAction("Index", new { ErrorMsg = "用户不存在" });
                }
                
                //list.Remove(result);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        #endregion





    }
}
