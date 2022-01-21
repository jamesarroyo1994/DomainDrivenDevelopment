using System.Collections.Generic;
using Domain.Entities.ML;
using Domain.Interfaces;
using Microsoft.ML;

namespace Infrastructure.Services.ML
{
    public class LoadData : ILoadData
    {
        public IDataView Load(MLContext mlContext)
        {
            var dataView = mlContext.Data.LoadFromEnumerable(new List<SentimentData>());
            return dataView;
        }
    }
}
