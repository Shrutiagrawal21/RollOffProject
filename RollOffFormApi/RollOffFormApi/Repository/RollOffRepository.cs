using Microsoft.EntityFrameworkCore;
using RollOffFormApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RollOffFormApi.Repository
{
    public class RollOffRepository : IRollOffRepository
    {
        private readonly OurExcelDataContext context;

        public RollOffRepository(OurExcelDataContext context)
        {
            this.context = context;
        }

        
        public async Task<MyDatum> GetByGGIdAsync(double id)
        {
           var emp=await context.MyData.FirstOrDefaultAsync(x => x.GlobalGroupId == id);
            return emp;
        }


        public async Task<MyDatum> GetByEmailAsync(string Email)
        {
            var e = await context.MyData.FirstOrDefaultAsync(y => y.Email == Email);
            return e;
        }
        public async Task<MyDatum> AddEmployeeAsync(MyDatum myDatum)
        {
          await context.AddAsync(myDatum);
           await context.SaveChangesAsync();
            return myDatum;
                
        }

        public async Task<MyDatum> UpdateEmployeeAsync(double id,MyDatum myDatum)
        {
            var existingEmployee = await context.MyData.FirstOrDefaultAsync(z => z.GlobalGroupId == id);
            if(existingEmployee==null)
            {
                return null;
            }

            existingEmployee.Country = myDatum.Country;
            existingEmployee.Email = myDatum.Email;
            existingEmployee.EmployeeNo = myDatum.EmployeeNo;
            existingEmployee.JoiningDate = myDatum.JoiningDate;
            existingEmployee.Name = myDatum.Name;
            existingEmployee.LocalGrade =myDatum.LocalGrade;
            existingEmployee.ProjectCode = myDatum.ProjectCode;
            existingEmployee.ProjectName = myDatum.ProjectName;
          existingEmployee.ProjectStartDate = myDatum.ProjectStartDate;
            existingEmployee.ProjectEndDate = myDatum.ProjectEndDate;
            existingEmployee.PeopleManagerPerformanceReviewer = myDatum.PeopleManagerPerformanceReviewer;
           existingEmployee.Practice = myDatum.Practice;
            existingEmployee.PspName = myDatum.PspName;
            existingEmployee.NewGlobalPractice = myDatum.NewGlobalPractice;
            existingEmployee.OfficeCity = myDatum.OfficeCity;

           await context.SaveChangesAsync();
            return existingEmployee;
        }

        public async Task<MyDatum> DeleteEmployeeAsync(double id)
        {
            var emp = await context.MyData.FirstOrDefaultAsync(x=>x.GlobalGroupId==id);
            context.Remove(emp);
           await context.SaveChangesAsync();
            return emp;
        }

        public async Task<IEnumerable<MyDatum>> GetData()
        {
            return await context.MyData.ToListAsync();
        }

        /*public IEnumerable<MyDatum> GetData()
        {
            
        }*/


    }
}
