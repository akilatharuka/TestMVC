using Domain.Entities;
using Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class UnitOfWork : IDisposable
    {
        private ItWorkExperienceDbContext context = new ItWorkExperienceDbContext();
        private Repository<Article> articleRepository;
        private Repository<ArticleList> articleListRepository;

        public Repository<Article> ArticleRepository
        {
            get
            {

                if (this.articleRepository == null)
                {
                    this.articleRepository = new Repository<Article>(context);
                }
                return articleRepository;
            }
        }

        public Repository<ArticleList> ArticleListRepository
        {
            get
            {

                if (this.articleListRepository == null)
                {
                    this.articleListRepository = new Repository<ArticleList>(context);
                }
                return articleListRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
