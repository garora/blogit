using System;
using System.Collections.Generic;

namespace BlogIT.Dal.Entities
{
    public class Content
    {
        public Content()
        {
            Comments = new List<Comment>();
        }

        public virtual int Id { get; set; }
        public virtual Category Category { get; set; }
        public virtual IList<Comment> Comments { get; set; }
        public virtual int CategoryId { get; set; }
        public virtual string Title { get; set; }
        public virtual string Alias { get; set; }
        public virtual string AuthorId { get; set; }
        public virtual DateTime? CreatedOn { get; set; }
        public virtual DateTime? LastUpdated { get; set; }
        public virtual string Excerpt { get; set; }
        public virtual string Body { get; set; }
        public virtual bool IsPrivate { get; set; }
        public virtual string Pass { get; set; }
        public virtual bool IsEnable { get; set; }
        public virtual bool IsApprove { get; set; }
        public virtual bool IsPublish { get; set; }
    }
}