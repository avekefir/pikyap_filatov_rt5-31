using rk1;

namespace RK1Test
{
    public class Tests
    {
        [Test]
        public void GetDepartmentSuppliersWithDetails_ShouldHandleSupplierWithoutDetails()
        {
            var suppliers = new List<Supplier>
            {
                new(1, "Отдел без деталей")
            };

            var details = new List<Detail>();

            var detailSuppliers = new List<DetailSupplier>(); 

            var dataService = new DataService(suppliers, details, detailSuppliers);

            var result = dataService.GetDepartmentSuppliersWithDetails().ToList();

            Assert.That(result, Is.Empty, "Поставщик без деталей не должен попасть в результат");
        }
        [Test]
        public void GetSuppliersWithAveragePrice_ShouldCalculateCorrectlyWithSingleDetail()
        {
            var suppliers = new List<Supplier>
            {
                new(1, "Поставщик с одной деталью")
            };

            var details = new List<Detail>
            {
                new(1, "Деталь", 7.89m, 1)
            };

            var detailSuppliers = new List<DetailSupplier>
            {
                new(1, 1)
            };

            var dataService = new DataService(suppliers, details, detailSuppliers);

            var result = dataService.GetSuppliersWithAveragePrice().ToList();

            Assert.That(result, Has.Count.EqualTo(1));
            Assert.That(result[0].AveragePrice, Is.EqualTo(7.89m));
            Assert.That(result[0].DetailsCount, Is.EqualTo(1));
        }

        [Test]
        public void DataService_Constructor_ShouldHandleNullParameters()
        {
            var dataService = new DataService(null, null, null);

            Assert.That(dataService.Suppliers, Is.Not.Null);
            Assert.That(dataService.Details, Is.Not.Null);
            Assert.That(dataService.DetailSuppliers, Is.Not.Null);
            Assert.That(dataService.Suppliers, Is.Empty);
            Assert.That(dataService.Details, Is.Empty);
            Assert.That(dataService.DetailSuppliers, Is.Empty);

            Assert.DoesNotThrow(() => dataService.GetDepartmentSuppliersWithDetails().ToList());
            Assert.DoesNotThrow(() => dataService.GetSuppliersWithAveragePrice().ToList());
            Assert.DoesNotThrow(() => dataService.GetDetailsStartingWithB().ToList());
        }
    }
}