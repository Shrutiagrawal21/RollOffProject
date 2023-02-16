using RollOffFormApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RollOffFormApi.Repository
{
   public interface IRollOffRepository
    {
        public Task<IEnumerable<MyDatum>> GetData();
        public Task<MyDatum> GetByGGIdAsync(double id);
        public Task<MyDatum> GetByEmailAsync(string Email);

        public Task<MyDatum> AddEmployeeAsync(MyDatum myDatum);

        public Task<MyDatum> UpdateEmployeeAsync(double id,MyDatum myDatum);

        public Task<MyDatum> DeleteEmployeeAsync(double id);
        
    }
}
