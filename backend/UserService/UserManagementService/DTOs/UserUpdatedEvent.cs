namespace UserManagementService.DTOs
{
    public class UserUpdatedEvent
    {
        public string Event = "UserUpdated";
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }
        public string ImageUrl { get; set; }
    }
}