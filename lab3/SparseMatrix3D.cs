using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    public class SparseMatrix3D<T> where T : class
    {
        private Dictionary<Tuple<int, int, int>, T> matrix = new();
        public T this[int x, int y, int z]
        {
            get
            {
                var key = Tuple.Create(x, y, z);
                return matrix.ContainsKey(key) ? matrix[key] : null;
            }
            set
            {
                var key = Tuple.Create(x, y, z);
                if (value == null)
                    matrix.Remove(key);
                else
                    matrix[key] = value;
            }
        }
        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendLine("Трехмерная разреженная матрица:");

            var sortedKeys = matrix.Keys.OrderBy(k => k.Item1)
                .ThenBy(k => k.Item2)
                .ThenBy(k => k.Item3);
        }
    }
}
