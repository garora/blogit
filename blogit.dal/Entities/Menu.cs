namespace BlogIT.Dal.Entities
{
    public class Menu
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Desc { get; set; }
        public virtual int ParentMenuId { get; set; }
        public virtual int DisplayOrder { get; set; }
        public virtual string Url { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual int? ContentId { get; set; }
    }
}