using System;
using System.Collections.Generic;
using Microsoft.ML;
using Microsoft.ML.Data;

public class ProductModelBuilder
{
    private readonly MLContext _mlContext;
    private ITransformer _model;

    public ProductModelBuilder()
    {
        _mlContext = new MLContext(seed: 0);
    }

    public void BuildAndTrain(IEnumerable<ProductData> trainingData)
    {
        var data = _mlContext.Data.LoadFromEnumerable(trainingData);

        // Xây dựng pipeline
        var pipeline = _mlContext.Transforms.Conversion.ConvertType("Quantity", outputKind: DataKind.Single)
            .Append(_mlContext.Transforms.Categorical.OneHotEncoding("ProductName"))
            .Append(_mlContext.Transforms.Conversion.ConvertType("Month", outputKind: DataKind.Single))
            .Append(_mlContext.Transforms.Concatenate("Features", "Month", "ProductName"))
            .Append(_mlContext.Regression.Trainers.Sdca(labelColumnName: "Quantity", maximumNumberOfIterations: 1000));

        _model = pipeline.Fit(data);
    }

    public int Predict(int year, int month, string productName)
    {
        var predictionFunction = _mlContext.Model.CreatePredictionEngine<ProductData, ProductPrediction>(_model);

        var input = new ProductData
        {
            Month = month,
            ProductName = productName
        };

        var result = predictionFunction.Predict(input);

        // Làm tròn kết quả
        return (int)Math.Round(result.Quantity);
    }
}

public class ProductData
{
    [LoadColumn(0)]
    public string ProductName;

    [LoadColumn(1)]
    public int Month;

    [LoadColumn(2)]
    public int Quantity;
}

public class ProductPrediction
{
    [ColumnName("Score")]
    public float Quantity;
}
