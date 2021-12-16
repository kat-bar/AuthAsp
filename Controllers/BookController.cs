using Auth.Models;
using Auth.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Auth.Controllers
{
       
    public class BookController : Controller
    {
        UsersContext db;
        public BookController(UsersContext context)
        {
            db = context;
            if (!db.Books.Any())
            {
                db.Books.Add(new Book { Name = "451° по Фаренгейту", Company = "Рэй Брэдбери", Price = 1953 });
                db.Books.Add(new Book { Name = "1984", Company = "Джордж Оруэлл", Price = 1948 });
                db.Books.Add(new Book { Name = "Мастер и Маргарита", Company = "Михаил Булгаков", Price = 1940 });
                db.Books.Add(new Book { Name = "Шантарам", Company = "Грегори Дэвид Робертс", Price = 2003 });
                db.Books.Add(new Book { Name = "Три товарища", Company = "Эрих Мария Ремарк", Price = 1936 });
                db.Books.Add(new Book { Name = "Цветы для Элджернона", Company = "Дэниел Киз", Price = 1959 });
                db.SaveChanges();
            }
        }
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return db.Books.ToList();
        }

        [HttpGet("{id}")]
        public Book Get(int id)
        {
            Book product = db.Books.FirstOrDefault(x => x.Id == id);
            return product;
        }

        [HttpPost]
        public IActionResult Post(Book product)
        {
            if (ModelState.IsValid)
            {
                db.Books.Add(product);
                db.SaveChanges();
                return Ok(product);
            }
            return BadRequest(ModelState);
        }

        [HttpPut]
        public IActionResult Put(Book product)
        {
            if (ModelState.IsValid)
            {
                db.Update(product);
                db.SaveChanges();
                return Ok(product);
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Book product = db.Books.FirstOrDefault(x => x.Id == id);
            if (product != null)
            {
                db.Books.Remove(product);
                db.SaveChanges();
            }
            return Ok(product);
        }
    }
}
