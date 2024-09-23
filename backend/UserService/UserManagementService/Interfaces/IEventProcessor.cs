namespace UserManagementService.Interfaces
{
    public interface IEventProcessor
    {
        public void ProcessEvent(string message);
        public void RegisterUser(string userRegistrationMessage);
        public string DetermineEvent(string notificationMessage);
    }
    
}