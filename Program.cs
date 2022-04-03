using Microsoft.EntityFrameworkCore.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Quiz.Models;
public class Program
{
  public static void Main(string[] args)
  {
    var host = CreateHostBuilder(args).Build();
  }


  public static IHostBuilder CreateHostBuilder(string[] args)
  {
    return Host
      .CreateDefaultBuilder(args)
      .ConfigureServices((hostContext, services) =>
      {
        services.AddDbContext<QuizContext>(options =>
        {
          options.UseSqlite("Data Source=quiz.db");
        });
      });
  }
}
