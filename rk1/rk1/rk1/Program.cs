namespace rk1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dataService = DataInitializer.CreateSampleDataService();

            var reportGenerator = new ReportGenerator(dataService);
            reportGenerator.GenerateAllReports();
        }
    }
}