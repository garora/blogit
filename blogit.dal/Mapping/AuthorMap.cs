using BlogIT.Dal.Entities;
using FluentNHibernate.Mapping;

namespace BlogIT.Dal.Mapping
{
    internal class AuthorMap : ClassMap<Author>
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