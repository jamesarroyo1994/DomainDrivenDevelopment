using System.Collections.Generic;
using Domain.Entities.ML;

namespace Domain.Interfaces
{
    public interface ISentimentDataReader
    {
        IEnumerable<SentimentData> Get();
    }
}
