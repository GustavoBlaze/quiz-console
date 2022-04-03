namespace Quiz.Models
{

  public class Alternative
  {
    public long id { get; set; }
    public long askId { get; set; }

    public Ask? ask { get; set; }

    public string? content { get; set; }

    public bool isCorrect { get; set; }
  }
}