using EmployeeTaxCalculator.Entities;
using System.Collections.Generic;

namespace EmployeeTaxCalculator.Interfaces
{
    public interface ITaxBracketRepository
    {
        public IDictionary<int, IEnumerable<TaxBracket>> FindAll();
    }
}
