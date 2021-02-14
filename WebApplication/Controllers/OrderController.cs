using System.Linq;
using System.Threading.Tasks;
using AutoPark.DAL.Entities;
using AutoPark.DAL.Interfaces;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication.Controllers
{
    public class OrderController : Controller
    {
        private readonly IRepository<Order> _ordersRepository;
        private readonly IRepository<Vehicle> _vehiclesRepository;

        public OrderController(IRepository<Order> ordersRepository, IRepository<Vehicle> vehiclesRepository)
        {
            _ordersRepository = ordersRepository;
            _vehiclesRepository = vehiclesRepository;
        }


        public async Task<ActionResult> Index()
        {
            var orders = await _ordersRepository.GetAll();
            foreach (var order in orders)
            {
                order.Vehicle = await _vehiclesRepository.Get(order.Vehicle_Id);
            }
            return View(orders);
        }

        public async Task<ActionResult> Create()
        {
            var vehicles = await _vehiclesRepository.GetAll();
            ViewBag.VehiclesList = vehicles.Select(vehicle =>
                new SelectListItem($"{vehicle.Model_Name} {vehicle.Registration_Number}", vehicle.Id.ToString()));
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Order order)
        {
            await _ordersRepository.Create(order);
            return RedirectToAction("Index");
        }
    }
}