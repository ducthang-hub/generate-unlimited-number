using AlephonAssignment.Helpers;
using AlephonAssignment.Logger;

namespace AlephonAssignment.FileGenerator
{
    public class FileGenerator
    {
        private const string _binPath = @"D:\{0}.bin";
        private readonly FileIO fileIO = new();
        private readonly ISortHelper<double> sortHelper = new SortDouble();

        public bool GenerateFile(string fileName, int size, double min, double max)
        {
            const string funcName = $"{nameof(GenerateFile)}";
            try
            {
                var filePath = string.Format(_binPath, fileName);
                var result = fileIO.GenereateNumbersAndWriteToFile(filePath, size, min, max);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{funcName} has error: {ex.Message}");
                return false;
            }
        }

        public bool Showfile(string fileName)
        {
            const string funcName = $"{nameof(Showfile)}";

            try
            {
                var filePath = string.Format(_binPath, fileName);
                var result = fileIO.ShowDoubleNumbersFromFile(filePath);
                return result;
            }
            catch(Exception ex)
            {
                Console.WriteLine($"{funcName} has error: {ex.Message}");
                return false;
            }
        }

        public bool SortFile(string fileName)
        {
            const string funcName = $"{nameof(SortFile)}";

            try
            {
                var filePath = string.Format(_binPath, fileName);

                var numberList = fileIO.GetDoubleNumbersFromFile(filePath);
                if (!numberList.Any())
                {
                    return false;
                }

                sortHelper.HeapSort(numberList);

                var result = fileIO.WriteDoubleNumbersToFile(filePath, numberList);

                return result;
            }
            catch(Exception ex)
            {
                Console.WriteLine($"{funcName} has error: {ex.Message}");
                return false;
            }
        }

        public bool MergeFile(string fileA, string fileB, string resultFile)
        {
            const string funcName = $"{nameof(MergeFile)}";

            try
            {
                var fileAPath = string.Format(_binPath, fileA);
                var fileBPath = string.Format(_binPath, fileB);
                var resultFilePath = string.Format(_binPath, resultFile);

                var mergeResult = fileIO.MergeFile(fileAPath, fileBPath, resultFilePath);
                if (!mergeResult) return false;

                var numberList = fileIO.GetDoubleNumbersFromFile(resultFilePath);
                if(!numberList.Any()) return false;

                sortHelper.HeapSort(numberList);

                var result = fileIO.WriteDoubleNumbersToFile(resultFilePath, numberList);

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{funcName} has error: {ex.Message}");
                return false;
            }
        }
    }
}
