using System.Collections.Immutable;
using Demo1.Data;
using Demo1.Model;
using Demo1.Repo.Abstraction;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly AppDbContext _Context;
        private readonly IGenaric<Vehicle> _vehicleRepo;
        public VehicleController(AppDbContext context , IGenaric<Vehicle> vehicleRepo )
        {
            _Context = context;
            _vehicleRepo = vehicleRepo;

        }

        [HttpGet("get avilible")]
        public IActionResult GetAvilibleVehicles(Vehicle vehicle)
        {
            var vehicles = _vehicleRepo.GetAll().Where(v => v.Status == "Available").ToList();
            var result = vehicles.Select(v => new
            {
                v.Id ,
                v.Make,
                v.Model,
                v.Year,
                v.Color,
                v.Price,
                v.Mileage,
                v.VIN,
                v.FuelType,
                v.Transmission,
                v.Status,
                CategoryName = _Context.Categories.FirstOrDefault(c => c.Id == v.CategoryId)?.Name
            }).ToList();
            return Ok(result);
        }

        [HttpPost("add vehicle")]
        public IActionResult AddVehicle(Vehicle vehicle)
        {
            if (vehicle == null)
            {
                return BadRequest("Vehicle is null");
            }
          
            var category = _Context.Categories.FirstOrDefault(c => c.Id == vehicle.CategoryId);
            if (category == null)
            {
                return BadRequest("Category with Id does not exist");
            }   
            var s = new Vehicle
            {
                Make = vehicle.Make,
                Model = vehicle.Model,
                Year = vehicle.Year,
                Color = vehicle.Color,
                Price = vehicle.Price,
                Mileage = vehicle.Mileage,
                VIN = vehicle.VIN,
                FuelType = vehicle.FuelType,
                Transmission = vehicle.Transmission,
                Status = vehicle.Status,
                CategoryId = category.Id
            };
            _vehicleRepo.Add(s);
            _vehicleRepo.save();

            //return Ok(s);
            return Created();
        }


        [HttpPut("update vehicle {id} ,  {status}")]
        public IActionResult UpdateVehicle(Vehicle vehicle , string status)
        {
           var s =  _Context.Vehicles.FirstOrDefault(v => v.Id == vehicle.Id);
            if (s == null)
            {
                return NotFound("Vehicle not found");
            }
           
           if (!string.IsNullOrEmpty(status))
            {
                s.Status = status;
            }

            _vehicleRepo.Update(s);
            _vehicleRepo.save();
            return Ok(s);
        }


        [HttpDelete("delete vehicle {id}")]
        public IActionResult DeleteVehicle(int id)
        {
            var s = _Context.Vehicles.FirstOrDefault(v => v.Id == id);
            if (s == null)
            {
                return NotFound("Vehicle not found");
            }
            _vehicleRepo.Delete(s);
            _vehicleRepo.save();
            return Ok("Vehicle deleted successfully");
        }
    }
}
