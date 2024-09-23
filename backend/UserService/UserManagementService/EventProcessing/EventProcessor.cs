using System.Text.Json;
using UserManagementService.Services;
using UserManagementService.DTOs;
using UserManagementService.Interfaces;
using AutoMapper;
using UserManagementService.Models;

public class EventProcessor : IEventProcessor
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public EventProcessor(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }

    public void ProcessEvent(string message)
    {
        var eventType = DetermineEvent(message);

        switch (eventType)
        {
            case "UserRegistered":
                RegisterUser(message);
                break;
            default:
                break;
        }
    }

    public string DetermineEvent(string notificationMessage)
    {
        var eventType = JsonSerializer.Deserialize<GenericEventDto>(notificationMessage);
        return eventType.Event;
    }

    public void RegisterUser(string userRegistrationMessage)
    {
        var userDto = JsonSerializer.Deserialize<UserRegistrationDto>(userRegistrationMessage);
        var user = _mapper.Map<User>(userDto);
        
        try {
            _userService.CreateUserAsync(user);
        } catch (Exception ex) {
            Console.WriteLine($"Could not register user: {ex.Message}");
        }
    }
}
