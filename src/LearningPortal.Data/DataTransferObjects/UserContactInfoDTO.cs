namespace LearningPortal.Data.DataTransferObjects
{
    public class UserContactInfoDTO
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string? PreferredName { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Email { get; set; } = null!;
    }
}
