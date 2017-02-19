using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Domain;
using Domain.Entities;

namespace MvcProject
{
    public partial class TestWebForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Article article = new Article() { Title = "Git" , Created= DateTime.Now, Modified = DateTime.Now };

            using (var ctx = new ItWorkExperienceDbContext())
            {
                

                ctx.Articles.Add(article);

                ctx.SaveChanges();
            }

        }

    }
}