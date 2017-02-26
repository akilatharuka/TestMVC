﻿using Domain;
using Domain.Entities;
using Domain.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProject.Controllers
{
    public class AdminArticleListController : Controller
    {
        private IRepository<ArticleList> _repository = null;

        private IRepository<Article> _articleRepository = null;

        private UnitOfWork unitOfWork = new UnitOfWork();

        public AdminArticleListController()
        {
            this._repository = new Repository<ArticleList>();
            this._articleRepository = new Repository<Article>();
        }

        // GET: AdminArticleList
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddArticleList(ArticleList articleList)
        {
            articleList.Created = DateTime.Now;
            articleList.Modified = DateTime.Now;

            try
            {
                ArticleList articleListWithId = _repository.Insert(articleList);
                _repository.Save();

                //SessionStateHelper.Set(SessionStateKeys.NAME, articleWithId);
                return RedirectToAction("EditArticleList", "AdminArticleList", new { id = articleListWithId.Id });
            }
            catch (Exception exe)
            {
                return View();
            }

        }

        public ActionResult AddArticleList()
        {

                return View();


        }

        public ActionResult EditArticleList(int id)
        {

            ArticleList articleList = _repository.GetById(id);

            return View(articleList);
        }

        [HttpPost]
        public ActionResult EditArticleList(ArticleList articleList, string articleId)
        {

            articleList.Modified = DateTime.Now;
            articleList.Created = DateTime.Now;

            Article article = unitOfWork.ArticleRepository.GetById(Int32.Parse(articleId));
            article.ArticleLists.Add(articleList);
            articleList.Articles.Add(article);

            unitOfWork.ArticleRepository.Update(article);
            unitOfWork.ArticleListRepository.Update(articleList);

            //unitOfWork.ArticleRepository.Save();
            unitOfWork.Save();

            return View();
        }


        [HttpPost]
        public JsonResult GetSearchedArticles(string Prefix)
        {
            //Note : you can bind same list from database  
            List<Article> articlesList = _articleRepository.GetAll().ToList();

            //Searching records from list using LINQ query  
            var CityName = (from N in articlesList
                            where N.Title.StartsWith(Prefix)
                            select new { N.Title, N.Id });
            return Json(CityName, JsonRequestBehavior.AllowGet);
        }

    }
}