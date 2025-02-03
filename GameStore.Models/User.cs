namespace GameStore.Models
{
	public class User
	{
		public Guid Id { get; set; } = Guid.NewGuid();
		public required string Username { get; set; }
		public required string Email { get; set; }
	}
}
