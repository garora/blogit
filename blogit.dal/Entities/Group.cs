using System.Collections.Generic;

namespace BlogIT.Dal.Entities
{
    public class Group
    {
        public Group()
        {
            GroupRights = new List<GroupRight>();
            Users = new List<User>();
        }

        public virtual int Id { get; set; }
        public virtual IList<GroupRight> GroupRights { get; set; }
        public virtual IList<User> Users { get; set; }
        public virtual string Name { get; set; }
        public virtual bool IsActive { get; set; }
    }
}