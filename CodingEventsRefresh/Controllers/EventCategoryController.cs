using CodingEventsRefresh.Data;
using CodingEventsRefresh.Models;
using CodingEventsRefresh.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodingEventsRefresh.Controllers
{
    public class EventCategoryController : Controller
    {
        private EventDbContext context;
        public EventCategoryController(EventDbContext dbContext) 
        {
            context = dbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<EventCategory> categories = context.Categories.ToList();
            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            AddEventCategoryViewModel addEventCategoryViewModel = new AddEventCategoryViewModel();
            return View(addEventCategoryViewModel);
        }

        [HttpPost]
        public IActionResult ProcessCreateEventCategoryForm(AddEventCategoryViewModel addEventCategoryViewModel)
        {
            if (ModelState.IsValid)
            {
                EventCategory category = new EventCategory
                {
                    Name = addEventCategoryViewModel.CategoryName
                };
                context.Categories.Add(category);
                context.SaveChanges();

               return Redirect("/EventCategory");
            }

            return View(addEventCategoryViewModel);
        }
    }
}
