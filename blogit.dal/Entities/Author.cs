using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blogit.dal.Entities
{
    class Author
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual Article AuthorArticle { get; set; }
    }
}
