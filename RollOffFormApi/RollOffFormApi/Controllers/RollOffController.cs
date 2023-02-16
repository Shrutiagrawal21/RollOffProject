
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RollOffFormApi.DTO;
using RollOffFormApi.Models;
using RollOffFormApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RollOffFormApi.Controllers
{
    
    [ApiController]
    [Route("RollOff")]
    public class RollOffController : ControllerBase
    {
        private readonly IRollOffRepository rollOffRepository;
        private readonly IMapper mapper;

        public RollOffController(IRollOffRepository rollOffRepository,IMapper mapper)
        {
            this.rollOffRepository = rollOffRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDetails()
        {
            var emps =await rollOffRepository.GetData();
            //return DTO
             /*var rollOffDetailsDTO = new List<MyDatum>();
            rollOffDetails.ToList().ForEach(rollOff =>
             {
                 var rollOffDetailDTO = new MyDatum()
                 {
                     Country=rollOff.Country,
                     GlobalGroupId=rollOff.GlobalGroupId,
                     EmployeeNo=rollOff.EmployeeNo,
                     Email=rollOff.Email
                   
                   
               
                 };
                 rollOffDetailsDTO.Add(rollOffDetailDTO);
             });*/
            var rollOfDetailsDTO = mapper.Map<List<MyDatumDTO>>(emps);    //mapper.Map<destination>(source);
;            return Ok(rollOfDetailsDTO);

        }

        [HttpGet]
        [Route("{id:double}")]
        public async Task<IActionResult> GetRollOffDetailsByGGID(double id)
        {
            var emp1 =await rollOffRepository.GetByGGIdAsync(id);
            if (emp1 == null)
            {
                return NotFound();
            }

            var rollOfDetailsDTO = mapper.Map<MyDatumDTO>(emp1);
            return Ok(rollOfDetailsDTO);
        }
        [HttpGet]
        [Route("{Email}")]
        public async Task<IActionResult> GetRollOffDetailsByEmail(string Email)
        {
            var emp2 = await rollOffRepository.GetByEmailAsync(Email);
            if (emp2 == null)
            {
                return NotFound();
            }
            var rollOfDetailsDTO = mapper.Map<MyDatumDTO>(emp2);
            return Ok(rollOfDetailsDTO);
        }
        [HttpPost]
        public async Task<IActionResult> AddEmployeeToList(MyDatum myDatum)
        {
            //DTO to Model
            var rollOfDetailsDTO = mapper.Map<MyDatumDTO>(myDatum);

            var emp3 = rollOffRepository.AddEmployeeAsync(myDatum);

            //Convert back to DTO
            var rollOfDetailsDTO2 = mapper.Map<List<MyDatumDTO>>(emp3);

            return Ok(rollOfDetailsDTO2);
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateEmployeeToList(double id,UpdateEmployeeDTO updateEmployeeDTO)
        {
            var emp = mapper.Map<MyDatum>(updateEmployeeDTO);
            var emp4 = await rollOffRepository.UpdateEmployeeAsync(id,emp);

            
            //If null return Not Found
            if (emp4 == null)
            {
                return NotFound();
            }            
            
            //Convert Details back to DTO
            var myDatumDTO = mapper.Map<MyDatumDTO>(emp4);            
            
            return Ok(myDatumDTO);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteEmployeeToList(double id)
        {
            //Get Employee from Database
            var emp5 =await rollOffRepository.DeleteEmployeeAsync(id);

            //If null return not found
            if (emp5 == null)
            {
                return NotFound();
            }

            //Delete the Employee
            //var emp6 =await rollOffRepository.DeleteEmployeeAsync(emp5);
            //convert response back to DTO
            var myDatumDTO = mapper.Map<MyDatumDTO>(emp5);

            return Ok(myDatumDTO);
        }
    }
}
