namespace PostService.DTOs
{
    public class UserUpdatedEvent
    {
        public string Event { get; set; } = "UserUpdated";
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }
        public string ImageUrl { get; set; }
    }
}