using Microsoft.EntityFrameworkCore;
using Todo.Core.Entities;

namespace Todo.Infrastructure.Data
{
    public class TodoDbContext : DbContext
    {
        public DbSet<TodoItem> Todo { get; set; }
        public DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options) => 
            options.UseSqlite(@"Data Source=C:\todo.db");
    }
}
