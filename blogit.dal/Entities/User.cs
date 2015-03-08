using System;
using System.Collections.Generic;

namespace BlogIT.Dal.Entities
{
    public class User
    {
        public User()
        {
            UserDetails = new List<UserDetail>();
        }

        public int Id { get; set; }
        public Group Group { get; set; }
        public IList<UserDetail> UserDetails { get; set; }
        public string LoginId { get; set; }
        public string Pass { get; set; }
        public bool IsActive { get; set; }
        public bool IsAdmin { get; set; }
        public DateTime LastLogin { get; set; }
        public DateTime RegisterOn { get; set; }
        public string ActivationKey { get; set; }
        public int GroupId { get; set; }
    }
}