using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MYCARS.Models;
using System.Diagnostics;
using System.Net;

namespace MYCARS.Controllers
{
    public class HomeController : Controller
    {
        private readonly MyCarDbContext _context;


        public HomeController(MyCarDbContext context)
        {
            _context = context; // Инициализация контекста базы данных через конструктор
        }

        // GET: Firms
        public IActionResult Index()
        {
            var bikes = _context.Bikes.ToList();
            return View(bikes);
        }

        public IActionResult Create()
        {
            return View();
        }

        // POST-действие для создания новой фирмы
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Bike bike)
        {
            if (ModelState.IsValid)
            {
                _context.Bikes.Add(bike);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(bike);
        }

        // Действие для отображения формы редактирования фирмы по её идентификатору
        public IActionResult Edit(int id)
        {
            var bike = _context.Bikes.Find(id);
            return View(bike);
        }

        // POST-действие для сохранения изменений фирмы
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Bike bike)
        {
            if (ModelState.IsValid)
            {
                _context.Bikes.Update(bike);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(bike);
        }

        // Действие для отображения формы подтверждения удаления фирмы по её идентификатору
        public IActionResult Delete(int id)
        {
            var bike = _context.Bikes.Find(id);
            if (bike == null)
            {
                return NotFound();
            }

            _context.Bikes.Remove(bike);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Cars()
        {
            var cars = _context.Cars.ToList();
            return View(cars);
        }

        public IActionResult CreateCar()
        {
            return View();
        }

        // POST-действие для создания новой фирмы
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateCar(Car car)
        {
            if (ModelState.IsValid)
            {
                _context.Cars.Add(car);
                _context.SaveChanges();
                return RedirectToAction(nameof(Cars));
            }
            return View(car);
        }

        public IActionResult EditCar(int id)
        {
            var car = _context.Cars.Find(id);
            return View(car);
        }

        // POST-действие для сохранения изменений фирмы
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditCar(Car car)
        {
            if (ModelState.IsValid)
            {
                _context.Cars.Update(car);
                _context.SaveChanges();
                return RedirectToAction(nameof(Cars));
            }
            return View(car);
        }

        // Действие для отображения формы подтверждения удаления фирмы по её идентификатору
        public IActionResult DeleteCar(int id)
        {
            var car = _context.Cars.Find(id);
            if (car == null)
            {
                return NotFound();
            }

            _context.Cars.Remove(car);
            _context.SaveChanges();
            return RedirectToAction(nameof(Cars));
        }

        public IActionResult Skateboards()
        {
            var skateboards = _context.Skateboards.ToList();
            return View(skateboards);
        }

        public IActionResult CreateSkateboard()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateSkateboard(Skateboard skateboard)
        {
            if (ModelState.IsValid)
            {
                _context.Skateboards.Add(skateboard);
                _context.SaveChanges();
                return RedirectToAction(nameof(Skateboards));
            }
            return View(skateboard);
        }

        public IActionResult EditSkateboard(int id)
        {
            var skateboard = _context.Skateboards.Find(id);
            return View(skateboard);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditSkateboard(Skateboard skateboard)
        {
            if (ModelState.IsValid)
            {
                _context.Skateboards.Update(skateboard);
                _context.SaveChanges();
                return RedirectToAction(nameof(Skateboards));
            }
            return View(skateboard);
        }

        // Действие для отображения формы подтверждения удаления фирмы по её идентификатору
        public IActionResult DeleteSkateboard(int id)
        {
            var skateboard = _context.Skateboards.Find(id);
            if (skateboard == null)
            {
                return NotFound();
            }

            _context.Skateboards.Remove(skateboard);
            _context.SaveChanges();
            return RedirectToAction(nameof(Skateboards));
        }

        public IActionResult GenerateReport()
        {
            var cars = _context.Cars.Where(c => c.raiting == 5).ToList();
            var bikes = _context.Bikes.Where(b => b.raiting == 5).ToList();
            var skateboards = _context.Skateboards.Where(s => s.raiting == 5).ToList();

            var viewModel = new ReportViewModel
            {
                Cars = cars,
                Bikes = bikes,
                Skateboards = skateboards
            };

            return View(viewModel);
        }
    }
}