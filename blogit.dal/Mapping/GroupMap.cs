using BlogIT.Dal.Entities;
using FluentNHibernate.Mapping;

namespace BlogIT.Dal.Mapping
{
    public class GroupMap : ClassMap<Group>
    {
        public GroupMap()
        {

            Id(x => x.Id).GeneratedBy.Identity().Column("Id");
            
            Map(x => x.Name).Column("Name").Not.Nullable().Length(100);
            Map(x => x.IsActive).Column("IsActive").Not.Nullable();
            
            HasMany(x => x.GroupRights).KeyColumn("Id");
            
            HasMany(x => x.Users).KeyColumn("Id");
            
            Table("bl_Groups");
        }
    }
}