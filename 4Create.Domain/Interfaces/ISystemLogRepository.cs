using _4Create.Domain.Entities;

namespace _4Create.Domain.Interfaces;
public interface ISystemLogRepository
{
    SystemLog? GetById(Guid id);

    void Add(SystemLog logEntry);
}
