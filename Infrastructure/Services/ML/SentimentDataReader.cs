using System;
using System.Collections.Generic;
using Domain.Entities.ML;
using Domain.Interfaces;

namespace Infrastructure.Services.ML
{
    public class SentimentDataReader : ISentimentDataReader
    {
        public IEnumerable<SentimentData> Get()
        {
            throw new NotImplementedException();
        }
    }
}
