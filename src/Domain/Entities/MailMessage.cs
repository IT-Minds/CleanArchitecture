namespace MorgenBooster.Domain.Entities
{
	public class MailMessage
	{
		public List<string> Receipients { get; set; } = new List<string>();
		public List<string> Cc { get; set; } = new List<string>();
		public string Subject { get; set; } = string.Empty;
		public string Message { get; set; } = string.Empty;
	}
}
