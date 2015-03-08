namespace BlogIT.Dal.Entities
{
    internal class Author
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual Article AuthorArticle { get; set; }
    }
}