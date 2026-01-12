using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Models;
using System.Linq;

namespace WebApplication2.Controllers
{
    public class ProductosController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public ProductosController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public ActionResult Index()
        {
            List<Producto> productos = new List<Producto>();
            productos = dbContext.Set<Producto>().ToList();
            return View(productos);
        }


        // GET: ProductosController/Details/5
        public ActionResult Details(int id)
        {           
            Producto producto = dbContext.Productos.Find(id);

            return View(producto);
        }

        // GET: ProductosController/Create
        public ActionResult Create()
        {
            List<Proveedor> proveedores = dbContext.Set<Proveedor>().ToList();
            IEnumerable<SelectListItem> listaProveedores = proveedores.Select(proveedor => new SelectListItem()
            {
                Text = proveedor.Name,
                Value = proveedor.Id.ToString(),
            });
            ViewBag.Proveedores = listaProveedores;

            List<Categoria> categorias = dbContext.Set<Categoria>().ToList();
            IEnumerable<SelectListItem> listaCategorias = categorias.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString(),
            });
            ViewBag.Categorias = listaCategorias;
            
            return View();
        }

        // POST: ProductosController/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(Producto producto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    dbContext.Set<Producto>().Add(producto);

                    dbContext.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                return View();
            }
            catch
            {
                return Ok();
            }
        }

        // GET: ProductosController/Edit/5
        public ActionResult Edit(int id)
        {
            Producto producto = dbContext.Productos.Find(id);

            List<Proveedor> proveedores = dbContext.Set<Proveedor>().ToList();
            IEnumerable<SelectListItem> listaProveedores = proveedores.Select(proveedor => new SelectListItem()
            {
                Text = proveedor.Name,
                Value = proveedor.Id.ToString(),
            });
            ViewBag.Proveedores = listaProveedores;

            List<Categoria> categorias = dbContext.Set<Categoria>().ToList();
            IEnumerable<SelectListItem> listaCategorias = categorias.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString(),
            });
            ViewBag.Categorias = listaCategorias;

            //ViewBag.ProveedorId = new SelectList(
            //    dbContext.Proveedores,
            //    "Name",
            //    "Id",
            //    producto.ProveedorId
            //);

            return View(producto);
        }

        // POST: ProductosController/Edit/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Producto producto)
        {
            try
            {
                dbContext.Set<Producto>().Update(producto);
                dbContext.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductosController/Delete/5
        public ActionResult Delete(int id)
        {
            Producto producto = dbContext.Set<Producto>().Find(id);
            return View(producto);
        }

        // POST: ProductosController/Delete/5
        [HttpDelete]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                Producto producto = dbContext.Set<Producto>().Find(id);
                dbContext.Set<Producto>().Remove(producto);
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
