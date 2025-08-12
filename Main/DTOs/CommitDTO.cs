namespace Main.DTOs
{
    public class CommitDTO
    {
        public string Sha { get; set; }
        public AuthorDTO Author { get; set; }
        public string Message { get; set; }
        public bool Distinct { get; set; }
        public string Url { get; set; }
    }

    public class AuthorDTO
    {
        public string Email { get; set; }
        public string Name { get; set; }
    }
}
