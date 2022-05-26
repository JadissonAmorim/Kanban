using Microsoft.EntityFrameworkCore;

namespace KanbanProject.Models
{
    public class ToDoContexto : DbContext
    {
        public ToDoContexto(DbContextOptions<ToDoContexto> options) : base(options)
        {

        }
        public DbSet<ToDo> ToDos { get; set; }
    }
}
