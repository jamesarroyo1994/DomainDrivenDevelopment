using Microsoft.ML;
using static Microsoft.ML.DataOperationsCatalog;

namespace Domain.Interfaces
{
    public interface ILoadData
    {
        IDataView Load(MLContext mlContext);
    }
}
