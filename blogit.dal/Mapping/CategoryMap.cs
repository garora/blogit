using BlogIT.Dal.Entities;
using FluentNHibernate.Mapping;

namespace BlogIT.Dal.Mapping
{
    public class CategoryMap : ClassMap<Category>
    {
        public CategoryMap()
        {
            Id(x => x.Id).GeneratedBy.Identity().Column("Id");
                        
            Map(x => x.Name).Column("Name").Not.Nullable().Length(100);
            Map(x => x.DisplayName).Column("DisplayName").Not.Nullable().Length(100);
            Map(x => x.Description).Column("Description").Length(100);
            Map(x => x.AutoApprove).Column("AutoApprove").Not.Nullable();
            Map(x => x.SectionId).Column("SectionId").Not.Nullable();
            Map(x => x.CreatedOn).Column("CreatedOn").Not.Nullable();
            Map(x => x.CreatedBy).Column("CreatedBy").Not.Nullable();
            Map(x => x.UpdatedOn).Column("UpdatedOn").Not.Nullable();
            Map(x => x.UpdatedBy).Column("UpdatedBy").Not.Nullable();

            References(x => x.Section).Column("Id");

            HasMany(x => x.Contents).KeyColumn("Id");

            Table("bl_Category");
        }
    }
}