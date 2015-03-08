using BlogIT.Dal.Entities;
using FluentNHibernate.Mapping;

namespace BlogIT.Dal.Mapping
{
    public class UserDetailMap : ClassMap<UserDetail>
    {
        public UserDetailMap()
        {
            Id(x => x.Id).GeneratedBy.Identity().Column("Id");
            
            Map(x => x.UserId).Column("UserId").Not.Nullable();
            Map(x => x.FirstName).Column("FirstName").Length(200);
            Map(x => x.LastName).Column("LastName").Length(200);
            Map(x => x.EmailId).Column("EmailId").Not.Nullable().Length(100);
            Map(x => x.Url).Column("Url").Not.Nullable().Length(256);

            References(x => x.User).Column("Id");

            Table("bl_User_Details");
        }
    }
}