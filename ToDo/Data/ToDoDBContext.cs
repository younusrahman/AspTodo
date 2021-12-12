using Microsoft.EntityFrameworkCore;
using ToDo.Models;

namespace ToDo.Data
{
    public class ToDoDBContext : DbContext
    {
        public ToDoDBContext(DbContextOptions<ToDoDBContext> options) : base(options)
        {

                
        }

       public DbSet<ToDoTasks> ToDoTasks { get; set; }

    }
}
