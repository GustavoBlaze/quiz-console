using Microsoft.EntityFrameworkCore;

namespace Quiz.Models
{

  public class QuizContext : DbContext
  {
    public QuizContext(DbContextOptions<QuizContext> options) : base(options) { }
    public DbSet<User>? users { get; set; }
    public DbSet<Quiz>? quizzes { get; set; }
    public DbSet<Category>? categories { get; set; }
    public DbSet<CategoryQuiz>? categoryQuizzes { get; set; }

    public DbSet<Ask>? asks { get; set; }

    public DbSet<Alternative>? alternatives { get; set; }
  }
}
