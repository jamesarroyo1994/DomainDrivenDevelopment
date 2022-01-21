using Microsoft.ML;
using Microsoft.ML.Calibrators;
using Microsoft.ML.Data;
using Microsoft.ML.Trainers;

namespace Domain.Interfaces
{
    public interface IModelTrainer
    {
        TransformerChain<BinaryPredictionTransformer<CalibratedModelParametersBase<LinearBinaryModelParameters, PlattCalibrator>>> Train(MLContext mlContext, IDataView splitTrainSet);
    }
}
