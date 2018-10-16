using MyStudy.Models;
using MyStudyService.Grade;
using MyStudyService.Grade.DTO;
using MyStudyService.Student.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyStudy.Controllers
{
    public class GradeController : Controller
    {

        public static List<GradeViewModel> list = new List<GradeViewModel>()
        {
            new GradeViewModel () {GradeId =1,GradeName ="三（4）" },
            new GradeViewModel () {GradeId =2,GradeName ="五（3）" },
            new GradeViewModel () {GradeId =3,GradeName ="六（4）" }
        };

        
        // GET: Grade
        public ActionResult Index(QueryGradeViewModel model)
        {

            var result = GradeService.Query(model);
            
            //result = list;
            //if (!string.IsNullOrEmpty(model.KeyWords))
            //{
            //    result = list.Where(e => e.GradeName.Contains(model.KeyWords)).ToList();
            //}
            return View(result);
        }

        // GET: Grade/Details/5
        public ActionResult Details(int? id)
        {
            var result = GradeService.Get(id);
            //var result = list.Where(e => e.GradeId == id).FirstOrDefault();
            if (result == null)
            {
                return RedirectToAction("Index", new { ErrorMsg = "班级不存在" });
            }
            return View(result);
        }

        // GET: Grade/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Grade/Create
        [HttpPost]
        public ActionResult Create(GradeViewModel model)
        {
            try
            {
                // TODO: Add insert logic here
                GradeService.Create(model);
                //list.Add(model);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Grade/Edit/5
        public ActionResult Edit(int id)
        {
            var result = GradeService.Get(id);
            //var result = list.Where(e => e.GradeId == id).FirstOrDefault();
            if (result == null)
            {
                return RedirectToAction("Index", new { ErrorMsg = "班级不存在" });
            }
            return View(result);
        }

        // POST: Grade/Edit/5
        [HttpPost]
        public ActionResult Edit(GradeViewModel model)
        {
            try
            {
                // TODO: Add update logic here
                if (string.IsNullOrEmpty(model.GradeName))
                {
                    return View();
                }
                var result = GradeService.Update(model);
                //var result = list.Where(e => e.GradeId == model.GradeId).FirstOrDefault();
                if (result == null)
                {
                    return RedirectToAction("Index", new { ErrorMsg = "班级不存在" });
                }
                //var index = list.IndexOf(result);
                //result.GradeName = model.GradeName;
                //list[index] = result;

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Grade/Delete/5
        public ActionResult Delete(int id)
        {
            var result = GradeService.Get(id);
            //var result = list.Where(e => e.GradeId == id).FirstOrDefault();
            if (result == null)
            {
                return RedirectToAction("Index", new { ErrorMsg = "班级不存在" });
            }
            return View(result);
        }

        // POST: Grade/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var result = GradeService.Delete(id);
                //var result = list.Where(e => e.GradeId == id).FirstOrDefault();
                if (result == null)
                {
                    return RedirectToAction("Index", new { ErrorMsg = "班级不存在" });
                }
                //list.Remove(result);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
