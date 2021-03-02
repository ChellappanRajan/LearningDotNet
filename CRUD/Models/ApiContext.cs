using Microsoft.EntityFrameworkCore;

namespace Todo.API.Models{

    public class ApiContext: DbContext
    {
            //Define Db Sets -- kind of table it will hold list of items
             public ApiContext(DbContextOptions<ApiContext> options) : base(options) { }

             public DbSet<Todo> Todos{ get; set; }
    }
}