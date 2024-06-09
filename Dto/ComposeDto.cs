namespace TextPlus_BE.Dto
{
    public class ComposeDto
    {
        public List<string> To { get; set; } = new List<string>();
        public string? Body { get; set; }
        public string? From { get; set; }
        public string? UserId { get; set; }

    }

}

