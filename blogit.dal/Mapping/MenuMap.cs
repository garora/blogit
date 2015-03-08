using BlogIT.Dal.Entities;
using FluentNHibernate.Mapping;

namespace BlogIT.Dal.Mapping
{
    public class MenuMap : ClassMap<Menu>
    {
        public MenuMap()
        {
            Id(x => x.Id).GeneratedBy.Identity().Column("Id");
            
            Map(x => x.Name).Column("Name").Not.Nullable().Length(500);
            Map(x => x.Desc).Column("Desc").Not.Nullable().Length(1000);
            Map(x => x.ParentMenuId).Column("ParentMenuId").Not.Nullable();
            Map(x => x.DisplayOrder).Column("DisplayOrder").Not.Nullable();
            Map(x => x.Url).Column("Url").Length(500);
            Map(x => x.IsActive).Column("IsActive").Not.Nullable();
            Map(x => x.ContentId).Column("ContentId");

            Table("bl_Menus");
        }
    }
}