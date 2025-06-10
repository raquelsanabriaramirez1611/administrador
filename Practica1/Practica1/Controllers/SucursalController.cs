using Practica1.Models;
using Practica1.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Practica1.Controllers
{
    public class SucursalController : Controller
    {
        // GET: Sucursal
        public ActionResult Index()
        {
            try
            {
                using (Practica1Entities db = new Practica1Entities())
                {
                    var sucursales = db.Sucursal.Select(s => new Models.ViewModels.cListaSucursales
                    {
                        SucursalID = s.SucursalId,
                        Nombre = s.Nombre,
                        Direccion = s.Direccion,
                        Telefono = s.Telefono
                    }).ToList();

                    return View(sucursales);
                }
            }
            catch (Exception ex)
            {
                return View(new List<Models.ViewModels.cListaSucursales>()); // Return an empty list in case of error        


            }
        }



        // GET: Sucursal/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                cSucursal sucursal = new cSucursal();
                using(Practica1Entities db = new Practica1Entities())
                {
                    var sucursalData = db.Sucursal.FirstOrDefault(s => s.SucursalId  == id);
                    if (sucursalData != null)
                    {
                        sucursal.SucursalID = sucursalData.SucursalId;
                        sucursal.Nombre = sucursalData.Nombre;
                        sucursal.Direccion = sucursalData.Direccion;
                        sucursal.Telefono = sucursalData.Telefono;
                    }
                    return View(sucursal);
                }
            }catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Sucursal", "Details"));
            }
                
        }

        // GET: Sucursal/Create
        public ActionResult Create()
        {
            return View();
        }

    
        // POST: Sucursal/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        // GET: Sucursal/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Sucursal/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Sucursal/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Sucursal/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }

    internal class Practica1Entities1
    {
    }
}
