using System.Threading.Tasks;
using AutoPark.DAL.Entities;
using AutoPark.DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    public class PartController: Controller
    {
        private readonly IRepository<Part> _partsRepository;

        public PartController(IRepository<Part> partsRepository)
        {
            _partsRepository = partsRepository;
        }

        public async Task<ActionResult> Index()
        {
            var parts = await _partsRepository.GetAll();
            return View(parts);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Part part)
        {
            await _partsRepository.Create(part);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            var part = await _partsRepository.Get(id);
            return View(part);
        }

        [HttpPost]
        public async Task<ActionResult> EditConfirm(Part part)
        {
            await _partsRepository.Update(part);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            await _partsRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}