namespace Quiz.Models
{
  public class QuizResponse
  {

    public long id { get; set; }

    public string? guestId { get; set; }

    public User? guest { get; set; }

    public Answer[]? answers { get; set; }
  }
}
