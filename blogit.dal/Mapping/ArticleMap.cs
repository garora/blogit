using BlogIT.Dal.Entities;
using FluentNHibernate.Mapping;

namespace BlogIT.Dal.Mapping
{
    internal class ArticleMap : ClassMap<Article>
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