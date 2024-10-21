using UserManagementService.DTOs;

namespace UserManagementService.Interfaces
{
    public interface IMessageBusClient
    {
        void PublishUserUpdatedEvent(UserUpdatedEvent userUpdateDto);
    }
}