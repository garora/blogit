using BlogIT.Dal.Entities;
using FluentNHibernate.Mapping;

namespace BlogIT.Dal.Mapping
{
    public class SiteOptionMap : ClassMap<SiteOption>
    {
        public SiteOptionMap()
        {
            Id(x => x.Id).GeneratedBy.Identity().Column("Id");
            
            Map(x => x.Name).Column("Name").Not.Nullable().Length(500);
            Map(x => x.Value).Column("Value").Not.Nullable();
            Map(x => x.IsAutoLoad).Column("IsAutoLoad").Not.Nullable();

            Table("bl_Site_Options");
        }
    }
}