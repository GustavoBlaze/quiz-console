namespace Quiz.Models
{

  public class User
  {
    public User(string id, string name)
    {
      this.id = id;
      this.name = name;
    }
    public string id { get; set; }
    public string name { get; set; }

    public Quiz[]? quizzes { get; set; }

    public QuizResponse[]? quizzesResponses { get; set; }
  }
}
