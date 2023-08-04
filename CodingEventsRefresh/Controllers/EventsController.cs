using CodingEventsRefresh.Models;
using CodingEventsRefresh.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using EventData = CodingEventsRefresh.Data.EventData;
using System.Globalization;
using CodingEventsRefresh.ViewModels;

namespace CodingEventsRefresh.Controllers
{
    public class EventsController : Controller
    {

        [HttpGet]
        public IActionResult Index()
        {
            List<Event> events = new List<Event>(EventData.GetAll());
            
            return View(events);
        }

        [HttpGet]
        public IActionResult Add()
        {
            AddEventViewModel addEventViewModel = new AddEventViewModel();

            return View(addEventViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddEventViewModel addEventViewModel)
        {
            Event newEvent = new Event
            {
                Name = addEventViewModel.Name,
                Description = addEventViewModel.Description,
            };

            EventData.Add(newEvent);

            return Redirect("/Events");
        }

        [HttpGet]
        [Route("/Events/Delete")]
        public IActionResult Delete()
        {
            ViewBag.events = EventData.GetAll();

            return View();
        }

        [HttpPost]
        public IActionResult Delete(int[] eventIds)
        {
            foreach(int eventId in eventIds)
            {
                EventData.Remove(eventId);
            }

            return Redirect("/Events");
        }

        [HttpPost]
        [Route("/Events/Edit/{eventId}")]
        public IActionResult Edit(int eventId)
        {
            Event editingEvent = EventData.GetById(eventId);
            ViewBag.eventToEdit = editingEvent;
            ViewBag.title = $"Edit Event {editingEvent.Name} (id = {editingEvent.Id}";
            return View();
        }

        [HttpPost]
        [Route("/Events/Edit")]
        public IActionResult SubmitEditEventForm(int eventId, string name, string description)
        {
            Event editingEvent = EventData.GetById(eventId);
            editingEvent.Name = name;
            editingEvent.Description = description;
            return Redirect("/Events");
        }

    }
}
