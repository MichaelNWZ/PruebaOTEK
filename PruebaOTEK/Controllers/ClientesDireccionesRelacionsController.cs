using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PruebaOTEK.Models;

namespace PruebaOTEK.Controllers
{
    public class ClientesDireccionesRelacionsController : Controller
    {
        private PruebaOTekDBEntities db = new PruebaOTekDBEntities();

        // GET: ClientesDireccionesRelacions
        public ActionResult Index()
        {
            var clientesDireccionesRelacions = db.ClientesDireccionesRelacions.Include(c => c.Cliente).Include(c => c.Direccione);
            return View(clientesDireccionesRelacions.ToList());
        }

        // GET: ClientesDireccionesRelacions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientesDireccionesRelacion clientesDireccionesRelacion = db.ClientesDireccionesRelacions.Find(id);
            if (clientesDireccionesRelacion == null)
            {
                return HttpNotFound();
            }
            return View(clientesDireccionesRelacion);
        }

        // GET: ClientesDireccionesRelacions/Create
        public ActionResult Create()
        {
            ViewBag.ID_Clientes = new SelectList(db.Clientes, "ID", "Nombre");
            ViewBag.ID_Direcciones = new SelectList(db.Direcciones, "ID", "Direccion");
            return View();
        }

        // POST: ClientesDireccionesRelacions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ID_Clientes,ID_Direcciones")] ClientesDireccionesRelacion clientesDireccionesRelacion)
        {
            if (ModelState.IsValid)
            {
                db.ClientesDireccionesRelacions.Add(clientesDireccionesRelacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Clientes = new SelectList(db.Clientes, "ID", "Nombre", clientesDireccionesRelacion.ID_Clientes);
            ViewBag.ID_Direcciones = new SelectList(db.Direcciones, "ID", "Direccion", clientesDireccionesRelacion.ID_Direcciones);
            return View(clientesDireccionesRelacion);
        }

        // GET: ClientesDireccionesRelacions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientesDireccionesRelacion clientesDireccionesRelacion = db.ClientesDireccionesRelacions.Find(id);
            if (clientesDireccionesRelacion == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Clientes = new SelectList(db.Clientes, "ID", "Nombre", clientesDireccionesRelacion.ID_Clientes);
            ViewBag.ID_Direcciones = new SelectList(db.Direcciones, "ID", "Direccion", clientesDireccionesRelacion.ID_Direcciones);
            return View(clientesDireccionesRelacion);
        }

        // POST: ClientesDireccionesRelacions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ID_Clientes,ID_Direcciones")] ClientesDireccionesRelacion clientesDireccionesRelacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clientesDireccionesRelacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Clientes = new SelectList(db.Clientes, "ID", "Nombre", clientesDireccionesRelacion.ID_Clientes);
            ViewBag.ID_Direcciones = new SelectList(db.Direcciones, "ID", "Direccion", clientesDireccionesRelacion.ID_Direcciones);
            return View(clientesDireccionesRelacion);
        }

        // GET: ClientesDireccionesRelacions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientesDireccionesRelacion clientesDireccionesRelacion = db.ClientesDireccionesRelacions.Find(id);
            if (clientesDireccionesRelacion == null)
            {
                return HttpNotFound();
            }
            return View(clientesDireccionesRelacion);
        }

        // POST: ClientesDireccionesRelacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClientesDireccionesRelacion clientesDireccionesRelacion = db.ClientesDireccionesRelacions.Find(id);
            db.ClientesDireccionesRelacions.Remove(clientesDireccionesRelacion);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
