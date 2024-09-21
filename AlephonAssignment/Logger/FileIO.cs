namespace AlephonAssignment.Logger
{
    public class FileIO
    {
        public bool GenereateNumbersAndWriteToFile(string filePath, int size, double min, double max)
        {
            const string funcName = $"{nameof(GenereateNumbersAndWriteToFile)}";
            try
            {
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                using (var writer = new BinaryWriter(fileStream))
                {
                    Random random = new Random();
                    for (var i = 0; i < size; i++)
                    {
                        var randomValue = Math.Round(random.NextDouble() * (max - min) + min, 2);
                        writer.Write(randomValue);
                    }
                }
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine($"{funcName} has error: {ex.Message}");
                return false;
            }
        }

        public bool WriteDoubleNumbersToFile(string filePath, double[] items)
        {
            const string funcName = $"{nameof(WriteDoubleNumbersToFile)}";

            try
            {
                if (items.Length == 0) return false;

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                using (var writer = new BinaryWriter(fileStream))
                {
                    foreach(var item in items)
                    {
                        writer.Write(item);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{funcName} has error: {ex.Message}");
                return false;
            }
        }

        public bool ShowDoubleNumbersFromFile(string filePath)
        {
            const string funcName = $"{nameof(ShowDoubleNumbersFromFile)}";

            try
            {
                using (var fileStream = new FileStream(filePath, FileMode.Open))
                using (var reader = new BinaryReader(fileStream))
                {
                    while (fileStream.Position < fileStream.Length)
                    {
                        double randomValue = reader.ReadDouble();
                        Console.WriteLine(randomValue);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{funcName} has error: {ex.Message}");
                return false;
            }
        }

        public double[] GetDoubleNumbersFromFile(string filePath)
        {
            const string funcName = $"{nameof(GetDoubleNumbersFromFile)}";

            try
            {
                var numberList = new List<double>();
                using (var fileStream = new FileStream(filePath, FileMode.Open))
                using (var reader = new BinaryReader(fileStream))
                {
                    while (fileStream.Position < fileStream.Length)
                    {
                        double number = reader.ReadDouble();
                        numberList.Add(number);
                    }
                }

                using(var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                using(var writer = new BinaryWriter(fileStream))
                {

                }
                return numberList.ToArray();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{funcName} has error: {ex.Message}");
                return Array.Empty<double>();
            }
        }

        public bool MergeFile(string fileA, string fileB, string resultFile)
        {
            const string funcName = $"{nameof(MergeFile)}";

            try
            {
                using (var sourceStream1 = new FileStream(fileA, FileMode.Open, FileAccess.Read))
                using (var sourceStream2 = new FileStream(fileB, FileMode.Open, FileAccess.Read))
                using (var destinationStream = new FileStream(resultFile, FileMode.Create, FileAccess.Write))
                {
                    sourceStream1.CopyTo(destinationStream);

                    sourceStream2.CopyTo(destinationStream);
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{funcName} has error: {ex.Message}");
                return false;
            }
        }
    }
}
