using _4Create.Domain.Entities;
using _4Create.Domain.Interfaces;
namespace _4Create.Infrastructure.Repositories
{
    internal class SystemLogRepository : ISystemLogRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public SystemLogRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Add(SystemLog logEntry)
        {
            if (_dbContext.SystemLogs == null)
                throw new ArgumentNullException(nameof(_dbContext.SystemLogs));
            _dbContext.SystemLogs.Add(logEntry);
        }

        public SystemLog? GetById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
