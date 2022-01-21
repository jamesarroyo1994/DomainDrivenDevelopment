using Domain.Interfaces;
using Microsoft.ML;
using Microsoft.ML.Calibrators;
using Microsoft.ML.Data;
using Microsoft.ML.Trainers;

namespace Infrastructure.Services.ML
{
    public class ModelTrainer
    {
        private readonly IModelBuilder _modelBuilder;

        public ModelTrainer(IModelBuilder modelBuilder)
        {
            _modelBuilder = modelBuilder;
        }

        public TransformerChain<BinaryPredictionTransformer<CalibratedModelParametersBase<LinearBinaryModelParameters, PlattCalibrator>>> Train(MLContext mlContext, IDataView dataView)
        {
            var splitDataView = mlContext.Data.TrainTestSplit(dataView, 0.2);
            var estimator = _modelBuilder.Build(mlContext);
            return estimator.Fit(splitDataView);
        }
    }
}
