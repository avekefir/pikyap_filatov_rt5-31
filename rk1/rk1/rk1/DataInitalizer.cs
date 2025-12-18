using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rk1
{
    public static class DataInitializer
    {
        public static DataService CreateSampleDataService()
        {
            var suppliers = new List<Supplier>
            {
                new(1, "Основной отдел поставщиков"),
                new(2, "Вспомогательный отдел комплектующих"),
                new(3, "Склад запчастей болты и гайки"),
                new(4, "Другой отдел поставщиков"),
                new(5, "отдел перекупа деталей"),
                new(6, "Поставщик про100деталь")
            };

            var details = new List<Detail>
            {
                new(1, "Болт М8", 15.50m, 1),
                new(2, "Гайка М10", 8.75m, 2),
                new(3, "Шайба А4", 3.20m, 3),
                new(4, "Винт М6", 12.80m, 3),
                new(5, "Подшипник 6205", 45.90m, 3)
            };

            var detailSuppliers = new List<DetailSupplier>
            {
                new(1, 1),
                new(2, 2),
                new(3, 3),
                new(4, 3),
                new(5, 3),
                new(1, 4),
                new(2, 5),
                new(3, 6),
                new(4, 6),
                new(5, 6)
            };

            return new DataService(suppliers, details, detailSuppliers);
        }
    }
}
