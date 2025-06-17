using Practica1.Models;
using Practica1.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
        public ActionResult Create(createSucursal sucursal)
        {
            try
            {
                if (!ModelState.IsValid) 
                    {
                        return View(sucursal);
                    }
                    using(Practica1Entities db = new Practica1Entities())
                    {
                        Sucursal newSucursal = new Sucursal
                        {
                            Nombre = sucursal.Nombre,
                            Direccion = sucursal.Direccion,
                            Telefono = sucursal.Telefono
                        };

                        db.Sucursal.Add(newSucursal);
                        db.SaveChanges();
                        ViewBag.MensajeProceso = "Sucursal creada exitosamente";
                        ViewBag.ValorMensaje = 1;
                        return View(sucursal);
                    }
                }
            catch(Exception ex)
            {
                ViewBag.MensajeProceso = "Error al crear la sucursal " + ex.Message;
                ViewBag.ValorMensage = 0;
                return View(sucursal);
            }

            }               


        // GET: Sucursal/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                editSucursal sucursal = new editSucursal();
                using (Practica1Entities db = new Practica1Entities())
                {
                    var sucursalData = db.Sucursal.FirstOrDefault(s => s.SucursalId == id);
                    if (sucursalData != null)
                    {
                        sucursal.SucursalID = sucursalData.SucursalId;
                        sucursal.Nombre = sucursalData.Nombre;
                        sucursal.Direccion = sucursalData.Direccion;
                        sucursal.Telefono = sucursalData.Telefono;
                    }
                    return View(sucursal);
                }
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Sucursal", "Edit"));
            }
        }

        // POST: Sucursal/Edit/5
        [HttpPost]
        public ActionResult Edit(editSucursal sucursal)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(sucursal);
                }
                using (Practica1Entities db = new Practica1Entities())
                {
                    var sucursalActual = db.Sucursal.Find(sucursal.SucursalID);
                    if (sucursalActual != null)
                    {
                        sucursalActual.Nombre = sucursal.Nombre;
                        sucursalActual.Direccion = sucursal.Direccion;
                        sucursalActual.Telefono = sucursal.Telefono;



                        db.Entry(sucursalActual).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        ViewBag.MensajeProceso = "Sucursal editada exitosamente";
                        ViewBag.ValorMensaje = 1;

                    }
                    return View(sucursal);
                }
            }
            catch (Exception ex)
            {
                ViewBag.MensajeProceso = "Error al editar la sucursal " + ex.Message;
                ViewBag.ValorMensage = 0;
                return View(sucursal);
            }
        }

        // GET: Sucursal/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                using (Practica1Entities db = new Practica1Entities())
                {
                    var sucursal = db.Sucursal.Find(id);
                    if (sucursal != null)
                    {
                        db.Sucursal.Remove(sucursal);
                        db.SaveChanges();
                        TempData["MensajeEliminado"] = "Sucursal eliminada exitosamente";
                        TempData["ValorMensaje"] = 0;
                    }
                }

            }
            catch (Exception ex)
            {
                TempData["MensajeEliminado"] = "Error al eliminar la sucursal " + ex.Message;
                TempData["ValorMensaje"] = 0;
            }
            return RedirectToAction("Index");
           
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
