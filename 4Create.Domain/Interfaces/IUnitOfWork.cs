﻿using System.Threading;
using System.Threading.Tasks;

namespace _4Create.Domain.Interfaces;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
