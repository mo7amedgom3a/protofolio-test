namespace PostService.Interfaces
{
    public interface IEventProcessor
    {
        void ProcessEvent(string message);
    }
}