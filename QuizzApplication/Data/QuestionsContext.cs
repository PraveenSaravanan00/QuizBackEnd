using Microsoft.EntityFrameworkCore;
using QuizzApplication.Model;
namespace QuizzApplication.Data
{
    public class QuestionsContext: DbContext
    {
        public QuestionsContext(DbContextOptions<QuestionsContext>options):base(options) { }

        public DbSet<Questions> Questions { get; set; }
        public DbSet<particularQuestion> particularQuestion { get; set; }
    }
}
