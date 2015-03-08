namespace BlogIT.Dal.Entities
{
    public class UserDetail
    {
        public virtual int Id { get; set; }
        public virtual User User { get; set; }
        public virtual int UserId { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string EmailId { get; set; }
        public virtual string Url { get; set; }
    }
}