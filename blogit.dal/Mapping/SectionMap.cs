using BlogIT.Dal.Entities;
using FluentNHibernate.Mapping;

namespace BlogIT.Dal.Mapping
{
    public class SectionMap : ClassMap<Section>
    {
        public SectionMap()
        {
            Id(x => x.Id).GeneratedBy.Identity().Column("Id");
            
            Map(x => x.Name).Column("Name").Not.Nullable().Length(300);
            Map(x => x.Description).Column("Description");
            Map(x => x.CreatedOn).Column("CreatedOn").Not.Nullable();
            Map(x => x.CreatedBy).Column("CreatedBy").Not.Nullable();
            Map(x => x.UpdatedOn).Column("UpdatedOn").Not.Nullable();
            Map(x => x.UpdatedBy).Column("UpdatedBy").Not.Nullable();
            
            HasMany(x => x.Categories).KeyColumn("Id");

            Table("bl_Sections");
        }
    }
}