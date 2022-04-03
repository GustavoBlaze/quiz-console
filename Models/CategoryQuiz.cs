namespace Quiz.Models
{

  public class CategoryQuiz
  {

    public long id { get; set; }
    public long categoryId { get; set; }
    public long quizId { get; set; }

    public Category? category { get; set; }
    public Quiz? quiz { get; set; }
  }
}
