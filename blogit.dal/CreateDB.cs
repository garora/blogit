using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using blogit.dal.Entities;

namespace blogit.dal
{
   public class CreateDB
    {
        public void Database()
        {

            using (var session = blogit.dal.NHibernatecfg.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var ArticleObj = new Article { Name = "BlogIT" };
                    session.Save(ArticleObj);
                    transaction.Commit();
                    //Console.WriteLine("Article was inserted : " + ArticleObj.Name);
                }

            } 
    
        }
    }
}
