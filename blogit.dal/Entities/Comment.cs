using System;

namespace BlogIT.Dal.Entities
{
    public class Comment
    {
        public virtual int Id { get; set; }
        public virtual Content Content { get; set; }
        public virtual int? ContentId { get; set; }
        public virtual string CommentAuthor { get; set; }
        public virtual string CommentAuthorEmail { get; set; }
        public virtual string CommentAuthorUrl { get; set; }
        public virtual string CommentAuthorIp { get; set; }
        public virtual string CommentDesc { get; set; }
        public virtual DateTime CommentDate { get; set; }
        public virtual bool IsApprove { get; set; }
        public virtual int? ApprovedBy { get; set; }
        public virtual DateTime ApprovedOn { get; set; }
    }
}