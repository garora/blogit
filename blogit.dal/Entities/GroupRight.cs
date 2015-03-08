namespace BlogIT.Dal.Entities
{
    public class GroupRight
    {
        public virtual int Id { get; set; }
        public virtual Group Group { get; set; }
        public virtual int GroupId { get; set; }
        public virtual string SectionRights { get; set; }
        public virtual string AccessRights { get; set; }
    }
}