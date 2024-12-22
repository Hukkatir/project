namespace projectAPI.Contracts.User
{
    public class CreateUserRequest
    {
        public int RoleId { get; set; }
        public string Username { get; set; } = null!;
        public string UserPassword { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }


    }
}
