using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Repositories;
public interface IPlayRepositories
{
    public void Save( Play play );
    public IReadOnlyList<Play> GetByPeriod( DateTime startTime, DateTime endTime );
}
