using Microsoft.AspNetCore.Mvc;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HerramientasController : Controller
    {
        private readonly ApplicationDbContext _db;

        public HerramientasController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Herramienta> HerramientasList = _db.Herramientas;
            return View(HerramientasList);
        }

        //GET Method
        public IActionResult Create()
        {
            
            return View();
        }

        //POST Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Herramienta herramienta)
        {
            if(ModelState.IsValid) { 
            _db.Herramientas.Add(herramienta);
            _db.SaveChanges();
            return RedirectToAction("Index");
            }
            return View(herramienta);
        }
        //GET Method
        public IActionResult Edit(int? id)
        {
            if(id==null || id == 0)
            {
                return NotFound();
            }

            var herramientaEditar = _db.Herramientas.Find(id);

            if (herramientaEditar == null) 
            { return NotFound(); }

            return View(herramientaEditar);
        }

        //POST Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Herramienta herramienta)
        {
            if (ModelState.IsValid)
            {
                _db.Herramientas.Update(herramienta);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(herramienta);
        }

        //GET Method
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var herramientaBorrar = _db.Herramientas.Find(id);

            if (herramientaBorrar == null)
            { return NotFound(); }

            return View(herramientaBorrar);
        }

        //POST Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {

            var herramientaDelete = _db.Herramientas.Find(id);
            if (herramientaDelete == null)
            {
                return NotFound();
            }
            
                _db.Herramientas.Remove(herramientaDelete);
                _db.SaveChanges();
                return RedirectToAction("Index");
            
         
        }
    }
}
