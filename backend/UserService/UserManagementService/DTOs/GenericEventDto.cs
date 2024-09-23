namespace UserManagementService.DTOs
{
    public class GenericEventDto
    {
        public string Event { get; set; }
        public string Entity { get; set; }
        public string EntityId { get; set; }
        public string EntityName { get; set; }
        public string EntityDescription { get; set; }
        public string EntityStatus { get; set; }
        public string EntityData { get; set; }
    }
}