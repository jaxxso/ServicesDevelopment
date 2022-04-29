using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.Common;
using Infrastructure.Context;

namespace Infrastructure.Repositories
{
    public class ReminderRepository : Repository<Reminder>, IReminderRepository
    {
        public ReminderRepository(AppDbContext appDbContext) : base(appDbContext)
        {
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
