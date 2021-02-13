using System.Threading.Tasks;
using AutoPark.DAL.Entities;
using AutoPark.DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;

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

        public async Task<ActionResult> Index()
        {
            var vehicles = await _vehiclesRepository.GetAll();
            return View(vehicles);
        }

        public ActionResult Create()
        {
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
            Vehicle vehicle = await _vehiclesRepository.Get(id);
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