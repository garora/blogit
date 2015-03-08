using BlogIT.Dal.Entities;
using FluentNHibernate.Mapping;

namespace BlogIT.Dal.Mapping
{
    public class ContentMap : ClassMap<Content>
    {
        public ContentMap()
        {
            Id(x => x.Id).GeneratedBy.Identity().Column("Id");
            
            Map(x => x.CategoryId).Column("CategoryId").Not.Nullable();
            Map(x => x.Title).Column("Title").Not.Nullable().Length(100);
            Map(x => x.Alias).Column("alias").Not.Nullable().Length(100);
            Map(x => x.AuthorId).Column("AuthorId").Not.Nullable().Length(10);
            Map(x => x.CreatedOn).Column("CreatedOn");
            Map(x => x.LastUpdated).Column("LastUpdated");
            Map(x => x.Excerpt).Column("Excerpt").Not.Nullable().Length(450);
            Map(x => x.Body).Column("Body").Not.Nullable().Length(4001); //This will handle NVARCHAR(Max)
            Map(x => x.IsPrivate).Column("IsPrivate").Not.Nullable();
            Map(x => x.Pass).Column("Pass").Length(256);
            Map(x => x.IsEnable).Column("IsEnable").Not.Nullable();
            Map(x => x.IsApprove).Column("IsApprove").Not.Nullable();
            Map(x => x.IsPublish).Column("IsPublish").Not.Nullable();
            
            HasMany(x => x.Comments).KeyColumn("Id");

            References(x => x.Category).Column("Id");

            Table("bl_Contents");
        }
    }
}