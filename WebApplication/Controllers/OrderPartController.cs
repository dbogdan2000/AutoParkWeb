using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoPark.DAL.Entities;
using AutoPark.DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication.Controllers
{
    public class OrderPartController : Controller
    {
        private readonly IRepository<OrderPart> _ordersPartsRepository;
        private readonly IRepository<Part> _partsRepository;
        private readonly IRepository<Order> _ordersRepository;
        private readonly IRepository<Vehicle> _vehiclesRepository;

        public OrderPartController(IRepository<OrderPart> ordersPartsRepository, IRepository<Part> partsRepository, IRepository<Order> ordersRepository, IRepository<Vehicle> vehiclesRepository)
        {
            _ordersPartsRepository = ordersPartsRepository;
            _partsRepository = partsRepository;
            _ordersRepository = ordersRepository;
            _vehiclesRepository = vehiclesRepository;
        }

        [HttpGet]
        public async Task<ActionResult> Create(int id)
        {
            var parts = await _partsRepository.GetAll();
            var order = await _ordersRepository.Get(id);
            var vehicle = await _vehiclesRepository.Get(order.Vehicle_Id);
            ViewBag.Vehicle = $"{vehicle.Model_Name} {vehicle.Registration_Number}";
            ViewBag.PartsList = parts.Select(part => new SelectListItem(part.Part_Name, part.Id.ToString()));
            return View(new OrderPart {Order_Id = id});
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(OrderPart orderPart)
        {
            await _ordersPartsRepository.Create(orderPart);
            return RedirectToAction("Index", "Order");
        }

        [HttpGet]
        public async Task<ActionResult> GetInfo(int id)
        {
            var order = await _ordersRepository.Get(id);
            var vehicle = await _vehiclesRepository.Get(order.Vehicle_Id);
            ViewBag.Vehicle = $"{vehicle.Model_Name} {vehicle.Registration_Number}";
            var ordersParts = await _ordersPartsRepository.GetAll();
            var parts = new List<OrderPart>();
            foreach (var orderPart in ordersParts)
            {
                if (orderPart.Order_Id == id)
                {
                    orderPart.Part = await _partsRepository.Get(orderPart.Part_Id);
                    parts.Add(orderPart);
                }
            }
            
            return View(parts);
        }
    }
}