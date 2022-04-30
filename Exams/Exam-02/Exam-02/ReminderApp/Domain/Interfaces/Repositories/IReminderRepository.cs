using Domain.Common;
using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
   public interface IReminderRepository : IRepository<Reminder>
   {
        public Task DeleteAllByCategoryId(int id);
        public Task<List<Reminder>>GetAllBycategoryId(int id);
   }
}
