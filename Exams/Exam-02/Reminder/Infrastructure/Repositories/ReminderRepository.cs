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
         var categoria = _appDbContext.Reminders.Where(x => x.CategoryId == id).ToList();
         _appDbContext.RemoveRange(categoria);
         await _appDbContext.SaveChangesAsync();
        }
        public Task<List<Reminder>> GetAllBycategoryId(int id)
        {
            return Task.FromResult(_appDbContext.Reminders.Where(x => x.CategoryId == id).ToList());
        }
    }
}
