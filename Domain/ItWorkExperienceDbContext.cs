using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ItWorkExperienceDbContext : DbContext
    {
        public ItWorkExperienceDbContext() : base("myconnection")
        {
        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<ArticleList> ArticleLists { get; set; }

    }
}
