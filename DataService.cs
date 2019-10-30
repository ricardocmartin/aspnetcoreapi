using Banco.Services.Models;
using Banco.Services.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Banco.Services
{
    public partial class Startup
    {
        class DataService : IDataService
        {
            private readonly ApplicationContext context;
            public DataService(ApplicationContext _context)
            {
                this.context = _context;
            }

            public void InitDB()
            {
                this.context.Database.Migrate();

            }
        }


    }
}
