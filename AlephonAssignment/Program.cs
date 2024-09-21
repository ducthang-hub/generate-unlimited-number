using AlephonAssignment.FileGenerator;

namespace Program;
class Program
{
    static public void Test(string fileName, int size, double min, double max)
    {
        var generator = new FileGenerator();
        generator.GenerateFile(fileName, size, min, max);
        generator.SortFile(fileName);
        generator.Showfile(fileName);
    }

    static public void TestMerge(string fileA, string fileB, string fileName)
    {
        var generator = new FileGenerator();
        generator.MergeFile(fileA, fileB, fileName);
        generator.Showfile(fileName);
    }

    static void Main(string[] args)
    {
        //test with 1000 numbers
        Test("test1000", 1000, 40.0d, 50.0d);

        //test with 10000 numbers
        Test("test10000", 10000, 40.0d, 50.0d);

        //test with 100000 numbers
        Test("test100000", 100000, 40.0d, 50.0d);

        // test merge 2 files
        //TestMerge("test10000", "test10000", "mergedFile");
    }
}
