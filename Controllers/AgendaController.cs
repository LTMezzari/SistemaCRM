using SistemaCRM.Models;
using SistemaCRM.Repository;
using System;
using System.Web.Mvc;

namespace SistemaCRM.Controllers
{
    public class AgendaController : Controller
    {
        private AgendaRepository Repository {
            get {
                return new AgendaRepository();
            }
        }
        private ContatoRepository ContatoRepository {
            get {
                return new ContatoRepository();
            }
        }

        // GET: Agenda
        public ActionResult Index()
        {
            return View(Repository.Read());
        }

        // GET: Agenda/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Agenda/Create
        public ActionResult Create()
        {
            return View(ContatoRepository.Read());
        }

        // POST: Agenda/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                if (!ModelState.IsValid)
                    throw new Exception("Agenda inválida.");

                var agenda = new Agenda();
                agenda.DataAgenda = DateTime.Parse(collection["DataAgenda"]);
                agenda.Titulo = collection["Titulo"];
                agenda.Descricao = collection["Descricao"];
                agenda.HorarioInicio = DateTime.Parse(collection["HorarioInicio"]);
                agenda.HorarioFim = DateTime.Parse(collection["HorarioFim"]);

                Repository.Create(agenda);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Agenda/Edit/5
        public ActionResult Edit(int id)
        {
            var contatos = ContatoRepository.Read();
            return View(Repository.Read().Find(c => c.Id == id));
        }

        // POST: Agenda/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                if (!ModelState.IsValid)
                    throw new Exception("Agenda inválida.");

                var agenda = new Agenda();
                agenda.Id = id;
                agenda.DataAgenda = DateTime.Parse(collection["DataAgenda"]);
                agenda.Titulo = collection["Titulo"];
                agenda.Descricao = collection["Descricao"];
                agenda.HorarioInicio = DateTime.Parse(collection["HorarioInicio"]);
                agenda.HorarioFim = DateTime.Parse(collection["HorarioFim"]);

                Repository.Update(agenda);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Agenda/Delete/5
        public ActionResult Delete(int id)
        {
            return View(Repository.Read().Find(c => c.Id == id));
        }

        // POST: Agenda/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var agenda = new Agenda();
                agenda.Id = id;
                Repository.Delete(agenda);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
