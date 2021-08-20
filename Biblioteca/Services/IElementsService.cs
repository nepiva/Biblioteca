using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Biblioteca.Data;
using Biblioteca.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core;

namespace Biblioteca.Services
{
    public interface IElementsService
    {
        IEnumerable<Element> GetAllElements();
    }
    /// <summary>
    /// Service to use element actions
    /// </summary>
    public class ElementsService : IElementsService
    {
        private readonly LibraryContext _context;

        public ElementsService(LibraryContext context)
        {
            _context = context;
        }
        public IEnumerable<Element> GetAllElements()
        {
            List<Book> bookList = _context.Books.ToList();
            List<Movie> movieList = _context.Movies.ToList();
            List<Magazine> magazineList = _context.Magazines.ToList();

            List<Element> allElements = (from book in bookList select (Element)book).ToList();
            allElements.AddRange((from movie in movieList select (Element)movie).ToList());
            allElements.AddRange((from magazine in magazineList select (Element)magazine).ToList());
            return allElements;
        }
    }
}
