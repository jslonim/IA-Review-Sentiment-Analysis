using ConsoleApp1ML.Model.DataModels;
using Microsoft.ML;
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsumeModel();
        }

        public static void ConsumeModel()
        {
            // Load the model
            MLContext mlContext = new MLContext();

            ITransformer mlModel = mlContext.Model.Load("MLModel.zip", out var modelInputSchema);

            var predEngine = mlContext.Model.CreatePredictionEngine<ModelInput, ModelOutput>(mlModel);

            // Use the code below to add input data
            var input = new ModelInput();
            Console.Write("Insert a review: ");
            input.Review = System.Console.ReadLine(); 
            

            // Try model on sample data
            // True is Positive, false is Negative 
            ModelOutput result = predEngine.Predict(input);

            Console.WriteLine($"Text: {input.Review} | Prediction: {(Convert.ToBoolean(result.Prediction) ? "Positive" : "Negative")} Sentiment");
        }
    }
}
