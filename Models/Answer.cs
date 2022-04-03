namespace Quiz.Models
{

  public class Answer
  {

    public long id { get; set; }

    public long quizResponseId { get; set; }
    public long askId { get; set; }

    public long alternativeId { get; set; }
    public Ask? ask { get; set; }

    public Alternative? alternative { get; set; }

    public QuizResponse? quizResponse { get; set; }
  }


}
