namespace WebApi.Domain
{
    public class Message
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string FromName { get; set; }

        public string Body { get; set; }

        public string Date { get; set; }

        public bool Read { get; set; }
    }
}