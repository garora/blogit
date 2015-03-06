using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using blogit.dal.Entities;

namespace blogit.dal.Mapping
{
    class ArticleMap : ClassMap<Article>
    {
        public ArticleMap()
        {
            Id(x => x.Id);

            Map(x => x.Name);
            
            Map(x => x.Body);

            Table("Article");
        }
    }
}
