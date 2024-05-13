namespace Blog.Entities
{
    public class PostEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string? Image { get; set; } //imagem em base64
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
        public int UserId { get; set; }

        public bool Validate()
        {
            if (string.IsNullOrEmpty(Title))
                return false;

            if (string.IsNullOrEmpty(Content))
                return false;

            return true;
        }

        public void SetUpdate(PostEntity post)
        {
            Title = post.Title;
            Content = post.Content;
            Image = post.Image;
            UpdatedAt = DateTime.Now;
        }
    }
}
