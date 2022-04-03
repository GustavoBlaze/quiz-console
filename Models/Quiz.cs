namespace Quiz.Models
{

  public class Quiz
  {
    public long id { get; set; }
    public string? name { get; set; }

    public string? userId { get; set; }

    public User? user { get; set; }

    public CategoryQuiz[]? categoryQuizzes { get; set; }

    public QuizResponse[]? quizzesResponses { get; set; }
  }
}
