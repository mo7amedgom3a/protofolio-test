using System;
using System.Text.Json;
using AutoMapper;
using PostService.Interfaces;
using PostService.Repositories;
using PostService.DTOs;

using Microsoft.Extensions.DependencyInjection;

namespace PostService.EventProcessing
{
    public class EventProcessor : IEventProcessor
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly IMapper _mapper;

        public EventProcessor(IServiceScopeFactory scopeFactory, IMapper mapper)
        {
            _scopeFactory = scopeFactory;
            _mapper = mapper;
        }

        public void ProcessEvent(string message)
        {
            var eventType = DetermineEvent(message);

            switch (eventType)
            {
                case EventType.UserUpdated:
                    UpdateUserDetailsInPosts(message);
                    break;
                default:
                    break;
            }
        }

        private EventType DetermineEvent(string notificationMessage)
        {
            Console.WriteLine("--> Determining Event");

            var eventType = JsonSerializer.Deserialize<UserUpdatedEvent>(notificationMessage);

            switch (eventType.Event)
            {
                case "UserUpdated":
                    Console.WriteLine("--> User Updated Event Detected");
                    return EventType.UserUpdated;
                default:
                    Console.WriteLine("--> Could not determine the event type");
                    return EventType.Undetermined;
            }
        }

        private async void UpdateUserDetailsInPosts(string message)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var postRepository = scope.ServiceProvider.GetRequiredService<IPostRepository>();
                var commandRepository = scope.ServiceProvider.GetRequiredService<ICommentRepository>();
                var savedPostRepository = scope.ServiceProvider.GetRequiredService<ISavedPostRepository>();
                Console.WriteLine($"--> User Updated Event Processing: {message}");

                var userUpdateDto = JsonSerializer.Deserialize<UserUpdatedEvent>(message);

                try
                {
                    postRepository.UpdateUserInformationInPostsAsync(userUpdateDto);
                    commandRepository.UpdateUserInformationInCommentsAsync(userUpdateDto);
                    savedPostRepository.UpdateUserInformationInSavedPostsAsync(userUpdateDto);
                    Console.WriteLine("--> User Details Updated in Posts");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"--> Could not update user details in posts: {ex.Message}");
                }
            }
        }
    }

    enum EventType
    {
        UserUpdated,
        Undetermined
    }
}
