using BlogIT.Dal.Entities;
using FluentNHibernate.Mapping;

namespace BlogIT.Dal.Mapping
{
    public class CommentMap : ClassMap<Comment>
    {
        public CommentMap()
        {
            Id(x => x.Id).GeneratedBy.Identity().Column("Id");
            
            Map(x => x.ContentId).Column("ContentId");
            Map(x => x.CommentAuthor).Column("CommentAuthor").Not.Nullable().Length(200);
            Map(x => x.CommentAuthorEmail).Column("CommentAuthorEmail").Not.Nullable().Length(200);
            Map(x => x.CommentAuthorUrl).Column("CommentAuthorURL").Not.Nullable().Length(200);
            Map(x => x.CommentAuthorIp).Column("CommentAuthorIP").Not.Nullable().Length(200);
            Map(x => x.CommentDesc).Column("CommentDesc").Not.Nullable().Length(500);
            Map(x => x.CommentDate).Column("CommentDate").Not.Nullable();
            Map(x => x.IsApprove).Column("IsApprove").Not.Nullable();
            Map(x => x.ApprovedBy).Column("ApprovedBy");
            Map(x => x.ApprovedOn).Column("ApprovedOn").Not.Nullable();

            References(x => x.Content).Column("Id");

            Table("bl_Comments");
        }
    }
}