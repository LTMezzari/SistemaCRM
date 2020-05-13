using SistemaCRM.Models;
using SistemaCRM.Repository;
using System;
using System.Web.Mvc;

namespace SistemaCRM.Controllers {
    public class ContatoController : Controller {
        private ContatoRepository Repository {
            get {
                return new ContatoRepository();
            }
        }

        // GET: Contato
        public ActionResult Index() {
            return View(Repository.Read());
        }

        // GET: Contato/Details/5
        public ActionResult Details(int id) {
            return View();
        }

        // GET: Contato/Create
        public ActionResult Create() {
            return View();
        }

        // POST: Contato/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection) {
            try {
                // TODO: Add insert logic here
                if (!ModelState.IsValid)
                    throw new Exception("Contato inválido.");

                var contato = new Contato();
                contato.Nome = collection["Nome"];
                contato.Email = collection["Email"];
                Repository.Create(contato);

                return RedirectToAction("Index");
            } catch {
                return View();
            }
        }

        // GET: Contato/Edit/5
        public ActionResult Edit(int id) {
            return View(Repository.Read().Find(c => c.ID == id));
        }

        // POST: Contato/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection) {
            try {
                // TODO: Add update logic here
                if (!ModelState.IsValid)
                    throw new Exception("Contato inválido.");

                var contato = new Contato();
                contato.Nome = collection["Nome"];
                contato.Email = collection["Email"];
                contato.ID = id;

                Repository.Update(contato);

                return RedirectToAction("Index");
            } catch {
                return View();
            }
        }

        // GET: Contato/Delete/5
        public ActionResult Delete(int id) {
            return View(Repository.Read().Find(c => c.ID == id));
        }

        // POST: Contato/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection) {
            try {
                // TODO: Add delete logic here
                var contato = new Contato();
                contato.ID = id;
                Repository.Delete(contato);

                return RedirectToAction("Index");
            } catch {
                return View();
            }
        }
    }
}
