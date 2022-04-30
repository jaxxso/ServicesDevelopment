using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.Common;
using Infrastructure.Context;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ReminderRepository : Repository<Reminder>, IReminderRepository
    {
        private readonly AppDbContext _appDbContext;
        public ReminderRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task  DeleteAllByCategoryId(int id)
        {
         var categories = _appDbContext.Reminders.Where(aux => aux.CategoryId == id).ToList();
         foreach (var item in categories)
         {
            _appDbContext.Remove(item);
            await _appDbContext.SaveChangesAsync();
         }
        }
        public Task<List<Reminder>> GetAllBycategoryId(int id)
        {
            return Task.FromResult(_appDbContext.Reminders.Where(aux => aux.CategoryId == id).ToList());
        }
    }
}
