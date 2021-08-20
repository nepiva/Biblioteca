using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Biblioteca.Data;
using Biblioteca.Models;
using Biblioteca.Services;

namespace Biblioteca.Controllers
{
    public class ElementsController : Controller
    {
        private readonly IElementsService _elementsService;

        public ElementsController(IElementsService elementsService)
        {
            _elementsService = elementsService;
        }

        // GET: Elements
        public IActionResult Index()
        {
            List<Element> allElementsList = _elementsService.GetAllElements().ToList();
            return View(allElementsList);
        }
    }
}
