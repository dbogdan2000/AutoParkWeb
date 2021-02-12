using System.Collections.Generic;
using System.Threading.Tasks;
using AutoPark.DAL.Entities;
using AutoPark.DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace WebApplication.Controllers
{
    public class VehicleTypeController : Controller
    {
        private readonly IRepository<VehicleType> _vehiclesTypesRepository;

        public VehicleTypeController(IRepository<VehicleType> vehiclesTypesRepository)
        {
            _vehiclesTypesRepository = vehiclesTypesRepository;
        }
        
        public ActionResult Create()
        {
             return View();
        }
        
        [HttpPost]
        public async Task<ActionResult> Create(VehicleType type)
        {
            await _vehiclesTypesRepository.Create(type);
            return RedirectToAction("Index");
        }
      
        public ActionResult Index()
        {
            var types =  _vehiclesTypesRepository.GetAll().Result;
            return View(types);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            await _vehiclesTypesRepository.Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            VehicleType type = _vehiclesTypesRepository.Get(id).Result;
            return View(type);
        }

        [HttpPost]
        public async Task<ActionResult> EditConfirm(VehicleType type)
        {
            await _vehiclesTypesRepository.Update(type);
            return RedirectToAction("Index");
        }
    }
}