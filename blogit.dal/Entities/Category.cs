using System;
using System.Collections.Generic;

namespace BlogIT.Dal.Entities
{
    public class Category
    {
        public Category()
        {
            Contents = new List<Content>();
        }

        public virtual int Id { get; set; }
        public virtual Section Section { get; set; }
        public virtual IList<Content> Contents { get; set; }
        public virtual string Name { get; set; }
        public virtual string DisplayName { get; set; }
        public virtual string Description { get; set; }
        public virtual bool AutoApprove { get; set; }
        public virtual int SectionId { get; set; }
        public virtual DateTime CreatedOn { get; set; }
        public virtual int CreatedBy { get; set; }
        public virtual DateTime UpdatedOn { get; set; }
        public virtual int UpdatedBy { get; set; }
    }
}