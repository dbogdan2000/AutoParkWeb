using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoPark.DAL.Entities;
using AutoPark.DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication.Controllers
{
    public class VehicleController : Controller
    {
        private readonly IRepository<Vehicle> _vehiclesRepository;
        private readonly IRepository<VehicleType> _vehiclesTypesRepository;

        public VehicleController(IRepository<Vehicle> vehiclesRepository,
            IRepository<VehicleType> vehiclesTypesRepository)
        {
            _vehiclesRepository = vehiclesRepository;
            _vehiclesTypesRepository = vehiclesTypesRepository;
        }

        [HttpGet]
        public async Task<ActionResult> Index(string sortParameter)
        {
            var vehicles = await _vehiclesRepository.GetAll();
            foreach (var vehicle in vehicles)
            {
                vehicle.VehicleType = await _vehiclesTypesRepository.Get(vehicle.Vehicle_Type_Id);
            }
            switch (sortParameter)
            {
                case "Model Name":
                    vehicles = vehicles.OrderBy(vehicles => vehicles.Model_Name);
                    break;
                case "Type":
                    vehicles = vehicles.OrderBy(vehicle => vehicle.VehicleType.Type_Name);
                    break;
                case "Mileage":
                    vehicles = vehicles.OrderBy(vehicles => vehicles.Mileage);
                    break;
            }
            return View(vehicles);
        }

        [HttpGet]
        public async Task<ActionResult> Create()
        {
            var types = await _vehiclesTypesRepository.GetAll();
            ViewBag.TypeList = types.Select(type => new SelectListItem(type.Type_Name,type.Id.ToString()));
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Vehicle vehicle)
        {
            await _vehiclesRepository.Create(vehicle);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            await _vehiclesRepository.Delete(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            var vehicle = await _vehiclesRepository.Get(id);
            var types = await _vehiclesTypesRepository.GetAll();
            ViewBag.TypeList = types.Select(type => new SelectListItem(type.Type_Name,type.Id.ToString()));
            return View(vehicle);
        }
        
        [HttpPost]
        public async Task<ActionResult> EditConfirm(Vehicle vehicle)
        {
            await _vehiclesRepository.Update(vehicle);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult> GetInfo(int id)
        {
            var vehicle = await _vehiclesRepository.Get(id);
            vehicle.VehicleType = await _vehiclesTypesRepository.Get(vehicle.Vehicle_Type_Id);
            return View(vehicle);
        }
    }
}