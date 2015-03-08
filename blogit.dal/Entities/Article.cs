namespace BlogIT.Dal.Entities
{
    internal class Article
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Body { get; set; }
    }
}