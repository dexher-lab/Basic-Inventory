using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class CategoriasController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public CategoriasController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // GET: CategoriasController
        public ActionResult Index()
        {            
            List<Categoria> categorias = new List<Categoria>();
            categorias = dbContext.Set<Categoria>().ToList();
            return View(categorias);
        }

        // GET: CategoriasController/Details/5
        public ActionResult Details(int id)
        {
            Categoria categoria = dbContext.Set<Categoria>().Find(id);
            return View(categoria);
        }

        // GET: CategoriasController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoriasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Categoria categoria)
        {
            try
            {
                dbContext.Set<Categoria>().Add(categoria);
                dbContext.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoriasController/Edit/5
        public ActionResult Edit(int id)
        {
            Categoria categoria = dbContext.Set<Categoria>().Find(id);
            return View(categoria);
        }

        // POST: CategoriasController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Categoria categoria)
        {
            try
            {
                dbContext.Set<Categoria>().Update(categoria);
                dbContext.SaveChanges();
                
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoriasController/Delete/5
        public ActionResult Delete(int id)
        {
            Categoria categoria = dbContext.Set<Categoria>().Find(id);
            return View(categoria);
        }

        // POST: CategoriasController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                Categoria categoria = dbContext.Set<Categoria>().Find(id);
                dbContext.Set<Categoria>().Remove(categoria);
                dbContext.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
