namespace Quiz.Models
{

  public class Ask
  {
    public long id { get; set; }
    public long quizId { get; set; }

    public Quiz? quiz { get; set; }
    public string? content { get; set; }

    public Alternative[]? alternatives { get; set; }
  }
}
