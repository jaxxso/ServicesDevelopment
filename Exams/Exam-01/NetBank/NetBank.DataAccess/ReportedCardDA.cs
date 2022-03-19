using System;

namespace NetBank.DataAccess
{
    public class ReportedCardDA
    {
        private readonly AppDbContext _appDbContext;

        public ReportedCardDA(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
    }
}
