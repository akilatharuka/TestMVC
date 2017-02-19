using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Domain;
using Domain.Entities;
using Domain.Repository;
using MvcProject.SessionHelpers;

namespace MvcProject.Controllers
{
    public class ArticleController : Controller
    {
        //private readonly IRepository repository;

        /*private readonly IRepository<Article> repository;

        public ArticleController(IRepository<Article> repo)
        {
            repository = repo;
        }*/

        private IRepository<Article> _repository = null;

        public ArticleController()
        {
            this._repository = new Repository<Article>();
        }

        public ViewResult List()
        {
            return View(_repository.GetAll());
        }

        public ActionResult Edit()
        {
            //ViewBag.Name = SessionStateHelper.Get(SessionStateKeys.NAME);

            Article article = (Article)SessionStateHelper.Get(SessionStateKeys.NAME);

            return View(article);
        }

    }
}