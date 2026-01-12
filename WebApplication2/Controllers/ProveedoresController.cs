using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class ProveedoresController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public ProveedoresController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // GET: ProveedoresController
        public ActionResult Index()
        {
            List<Proveedor> proveedores = new List<Proveedor>();
            proveedores = dbContext.Set<Proveedor>().ToList();
            return View(proveedores);
        }

        // GET: ProveedoresController/Details/5
        public ActionResult Details(int id)
        {
            Proveedor proveedor = dbContext.Set<Proveedor>().Find(id);
            return View(proveedor);

        }

        // GET: ProveedoresController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProveedoresController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Proveedor proveedor)
        {
            try
            {
                dbContext.Set<Proveedor>().Add(proveedor);
                dbContext.SaveChanges();
                
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProveedoresController/Edit/5
        public ActionResult Edit(int id)
        {
            Proveedor proveedor = dbContext.Set<Proveedor>().Find(id);
            return View(proveedor);
        }

        // POST: ProveedoresController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Proveedor proveedor)
        {
            try
            {
                dbContext.Set<Proveedor>().Update(proveedor);
                dbContext.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProveedoresController/Delete/5
        public ActionResult Delete(int id)
        {
            Proveedor proveedor = dbContext.Set<Proveedor>().Find(id);
            return View(proveedor);
        }

        // POST: ProveedoresController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                Proveedor proveedor = dbContext.Set<Proveedor>().Find(id);
                dbContext.Set<Proveedor>().Remove(proveedor);
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
