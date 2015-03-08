using System;
using System.Collections.Generic;

namespace BlogIT.Dal.Entities
{
    public class Section
    {
        public Section()
        {
            Categories = new List<Category>();
        }

        public virtual int Id { get; set; }
        public virtual IList<Category> Categories { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual DateTime CreatedOn { get; set; }
        public virtual int CreatedBy { get; set; }
        public virtual DateTime UpdatedOn { get; set; }
        public virtual int UpdatedBy { get; set; }
    }
}