using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rk1
{
    public class ReportGenerator
    {
        private readonly DataService _dataService;

        public ReportGenerator(DataService dataService)
        {
            _dataService = dataService;
        }

        public void GenerateAllReports()
        {
            GenerateDepartmentSuppliersReport();
            GenerateAveragePriceReport();
            GenerateDetailsStartingWithBReport();
        }

        public void GenerateDepartmentSuppliersReport()
        {
            Console.WriteLine("Задание E1");
            Console.WriteLine("Список всех поставщиков, у которых в названии присутствует слово \"отдел\", и список их деталей:");

            var results = _dataService.GetDepartmentSuppliersWithDetails();

            foreach (var item in results)
            {
                Console.WriteLine($"\nПоставщик: {item.SupplierName}");
                foreach (var detail in item.Details)
                {
                    Console.WriteLine($"  Деталь: {detail.Name}, Цена: {detail.Price} руб.");
                }
            }
        }

        public void GenerateAveragePriceReport()
        {
            Console.WriteLine("\nЗадание E2");
            Console.WriteLine("Список поставщиков со средней ценой деталей в каждом отделе, отсортированный по средней цене:");

            var results = _dataService.GetSuppliersWithAveragePrice();

            foreach (var item in results)
            {
                Console.WriteLine($"Поставщик: {item.SupplierName}, Средняя цена: {item.AveragePrice} руб. (детали: {item.DetailsCount})");
            }
        }

        public void GenerateDetailsStartingWithBReport()
        {
            Console.WriteLine("\nЗадание E3");
            Console.WriteLine("Список всех деталей, у которых название начинается с буквы \"Б\", и названия их поставщиков:");

            var results = _dataService.GetDetailsStartingWithB();

            foreach (var item in results)
            {
                Console.WriteLine($"Деталь: {item.DetailName}, Цена: {item.DetailPrice} руб. -> Поставщик: {item.SupplierName}");
            }
        }
    }
}