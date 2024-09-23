namespace UserManagementService.DTOs
{
public class UserProfileDto
{
    public string Username { get; set; }
    public string Name { get; set; }
    public string Gender { get; set; }
    public string Bio { get; set; }
    public int Age { get; set; }
    public List<string> Skills { get; set; }
    public List<string> TopicsOfInterest { get; set; }
    public string ImageUrl { get; set; }
    public List<string> Followers { get; set; }
    public List<string> Following { get; set;}
}
}

