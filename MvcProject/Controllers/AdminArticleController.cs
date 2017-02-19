using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Entities;
using Domain.Repository;
using MvcProject.SessionHelpers;

namespace MvcProject.Controllers
{
    public class AdminArticleController : Controller
    {
        private IRepository<Article> _repository = null;

        public AdminArticleController()
        {
            this._repository = new Repository<Article>();
        }



        // An action to display your TinyMCE editor
        public ActionResult Index()
        {
            return View();
        }

        // An action that will accept your Html Content
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Index(Article article)
        {
            article.Title = "Test Title";
            article.Created = DateTime.Now;
            article.Modified = DateTime.Now;

            try
            {
                Article articleWithId = _repository.Insert(article);
                _repository.Save();

                SessionStateHelper.Set(SessionStateKeys.NAME, articleWithId);
                return RedirectToAction("Edit", "AdminArticle");
            }
            catch(Exception exe)
            {
                return View();
            }
            
        }

        public ActionResult About(Article article)
        {
            return View();
            //return HttpNotFound();
            //return Content("Test String no view");
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Article article)
        {
            //article.Title = "Test Title";
            //article.Created = DateTime.Now;
            article.Modified = DateTime.Now;

            _repository.Update(article);
            _repository.Save();

            return View();
        }

        /*public ActionResult Edit()
        {
            //ViewBag.Name = SessionStateHelper.Get(SessionStateKeys.NAME);

            Article article = (Article)SessionStateHelper.Get(SessionStateKeys.NAME);

            return View(article);
        }*/

        public ActionResult ViewAll()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            //ViewBag.Name = SessionStateHelper.Get(SessionStateKeys.NAME);

            Article article = _repository.GetById(id);

            return View(article);
        }

    }
}