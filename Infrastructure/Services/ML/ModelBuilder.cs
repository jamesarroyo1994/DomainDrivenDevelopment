using Domain.Entities.ML;
using Domain.Interfaces;
using Microsoft.ML;
using Microsoft.ML.Calibrators;
using Microsoft.ML.Data;
using Microsoft.ML.Trainers;

namespace Infrastructure.Services.ML
{
    public class ModelBuilder : IModelBuilder
    {
        public EstimatorChain<BinaryPredictionTransformer<CalibratedModelParametersBase<LinearBinaryModelParameters, PlattCalibrator>>> Build(MLContext mlContext) 
        {
            return mlContext.Transforms.Text.FeaturizeText(outputColumnName: "Features", nameof(SentimentData.SentimentText))
                .Append(mlContext.BinaryClassification.Trainers.SdcaLogisticRegression("Label", "Features"));
        }
    }
}
