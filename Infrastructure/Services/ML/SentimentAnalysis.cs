using System.Collections.Generic;
using Domain.Entities.ML;
using Domain.Interfaces;
using Microsoft.ML;
using Microsoft.ML.Data;
using static Microsoft.ML.DataOperationsCatalog;

namespace Infrastructure.Services.ML
{

    public class SentimentAnalysis : ISentimentAnalysis
    {
        private readonly ILoadData _loadData;
        private readonly IModelBuilder _modelBuilder;
        private readonly IModelTrainer _modelTrainer;
        private readonly MLContext _mlContext;
        private readonly ISentimentDataReader _sentimentDataReader;

        public SentimentAnalysis(ILoadData loadData, IModelBuilder modelBuilder, IModelTrainer modelTrainer, ISentimentDataReader sentimentDataReader)
        {
            _loadData = loadData;
            _modelBuilder = modelBuilder;
            _modelTrainer = modelTrainer;
            _sentimentDataReader = sentimentDataReader;
            _mlContext = new MLContext();
        }

        public void Predict(MLContext mlContext, ITransformer model)
        {
            var dataView = _loadData.Load(mlContext);

            var estimatorChain = _modelBuilder.Build(mlContext);

            var transformerChain = _modelTrainer.Train(mlContext, dataView);

            var sentiments = _sentimentDataReader.Get();

            var batchComments = mlContext.Data.LoadFromEnumerable(sentiments);

            var predictions = model.Transform(batchComments);

            var predictedResults = mlContext.Data.CreateEnumerable<SentimentPrediction>(predictions, false);
        }
    }
}
