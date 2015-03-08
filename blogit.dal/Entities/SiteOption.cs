namespace BlogIT.Dal.Entities
{
    public class SiteOption
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Value { get; set; }
        public virtual bool IsAutoLoad { get; set; }
    }
}