using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using blogit.dal.Entities;

namespace blogit.dal.Mapping
{
    class AuthorMap: ClassMap<Author>
    {
        //Constructor
        public AuthorMap()
        {
            Id(x => x.Id);

            Map(x => x.Name);

            References(x => x.AuthorArticle).Column("ArticleId");

            Table("Author");
        }
    }
}
