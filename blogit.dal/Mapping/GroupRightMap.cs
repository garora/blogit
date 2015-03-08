using BlogIT.Dal.Entities;
using FluentNHibernate.Mapping;

namespace BlogIT.Dal.Mapping
{
    public class GroupRightMap : ClassMap<GroupRight>
    {
        public GroupRightMap()
        {
            Id(x => x.Id).GeneratedBy.Identity().Column("Id");
            
            Map(x => x.GroupId).Column("GroupId").Not.Nullable();
            Map(x => x.SectionRights).Column("section_rights").Not.Nullable().Length(250);
            Map(x => x.AccessRights).Column("access_rights").Not.Nullable().Length(450);

            References(x => x.Group).Column("Id");

            Table("bl_GroupRights");
        }
    }
}