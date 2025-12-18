using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rk1
{
    public class DataService
    {
        public List<Supplier> Suppliers { get; }
        public List<Detail> Details { get; }
        public List<DetailSupplier> DetailSuppliers { get; }

        public DataService(
            List<Supplier> suppliers,
            List<Detail> details,
            List<DetailSupplier> detailSuppliers)
        {
            Suppliers = suppliers ?? new List<Supplier>();
            Details = details ?? new List<Detail>();
            DetailSuppliers = detailSuppliers ?? new List<DetailSupplier>();
        }

        // Задание E1: Поставщики с "отдел" и их детали
        public IEnumerable<SupplierDetailsResult> GetDepartmentSuppliersWithDetails()
        {
            var manyToManyTemp = from supplier in Suppliers
                                 join ds in DetailSuppliers on supplier.Id equals ds.SupplierId
                                 select new { SupplierName = supplier.Name, ds.SupplierId, ds.DetailId };

            var result = from supplier in Suppliers
                         where supplier.Name.Contains("отдел", StringComparison.OrdinalIgnoreCase)
                         join ds in DetailSuppliers on supplier.Id equals ds.SupplierId into supplierDetails
                         from sd in supplierDetails
                         join detail in Details on sd.DetailId equals detail.Id
                         group detail by supplier into supplierGroup
                         select new SupplierDetailsResult
                         {
                             SupplierName = supplierGroup.Key.Name,
                             Details = supplierGroup.Select(d => new DetailInfo
                             {
                                 Name = d.Name,
                                 Price = d.Price
                             }).ToList()
                         };

            return result;
        }

        // Задание E2: Средняя цена деталей по поставщикам
        public IEnumerable<SupplierAveragePriceResult> GetSuppliersWithAveragePrice()
        {
            var result = from supplier in Suppliers
                         join ds in DetailSuppliers on supplier.Id equals ds.SupplierId
                         join detail in Details on ds.DetailId equals detail.Id
                         group detail by supplier into supplierGroup
                         let avgPrice = Math.Round(supplierGroup.Average(d => d.Price), 2)
                         select new SupplierAveragePriceResult
                         {
                             SupplierName = supplierGroup.Key.Name,
                             AveragePrice = avgPrice,
                             DetailsCount = supplierGroup.Count()
                         };

            return result.OrderBy(x => x.AveragePrice);
        }

        // Задание E3: Детали на букву "Б" и их поставщики
        public IEnumerable<DetailWithSupplierResult> GetDetailsStartingWithB()
        {
            var manyToManyTemp = from supplier in Suppliers
                                 join ds in DetailSuppliers on supplier.Id equals ds.SupplierId
                                 select new { SupplierName = supplier.Name, ds.SupplierId, ds.DetailId };

            var result = from detail in Details
                         where detail.Name.StartsWith("Б", StringComparison.OrdinalIgnoreCase)
                         join temp in manyToManyTemp on detail.Id equals temp.DetailId into detailSuppliersTemp
                         from dst in detailSuppliersTemp
                         join supplier in Suppliers on dst.SupplierId equals supplier.Id
                         select new DetailWithSupplierResult
                         {
                             DetailName = detail.Name,
                             DetailPrice = detail.Price,
                             SupplierName = supplier.Name
                         };

            return result;
        }
    }

    public class SupplierDetailsResult
    {
        public string SupplierName { get; set; } = string.Empty;
        public List<DetailInfo> Details { get; set; } = new();
    }

    public class DetailInfo
    {
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }

    public class SupplierAveragePriceResult
    {
        public string SupplierName { get; set; } = string.Empty;
        public decimal AveragePrice { get; set; }
        public int DetailsCount { get; set; }
    }

    public class DetailWithSupplierResult
    {
        public string DetailName { get; set; } = string.Empty;
        public decimal DetailPrice { get; set; }
        public string SupplierName { get; set; } = string.Empty;
    }
}
