/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BaseProject.Attribute;

namespace BaseProject.Example
{
    public class CRUD
    {
        [SessionManager()]
        public class TablaController : Controller
        {
            private Model db = new Model();

            // GET: Tabla
            public ViewResult Index() => View();

            //Get data for update table
            public async Task<JsonResult> GetData() =>
                // Return JSON data from table Tabla
                Json(
                    new
                    {
                    // Async get data
                    data = await Task.Run(() => db. // Get data from db
                          tabla
                          .OrderByDescending(x => x.cat_FechaCrea) // Order by descending Fecha Crea
                          .Select(
                              x => new
                              {
                                  descripcion = x.descripcion,
                                  numero = x.cat_Id
                              }
                          )
                        )
                    },
                    JsonRequestBehavior.AllowGet
                    );

            // GET: Tabla/Details/5
            public async Task<JsonResult> Details(int? id)
            {
                if (id == null)
                {
                    return Json("error", JsonRequestBehavior.AllowGet);
                }
                tabla vTabla = await db.tabla.FindAsync(id);

                if (vTabla == null)
                {
                    return Json("error", JsonRequestBehavior.AllowGet);
                }

                object result = new
                {
                    id = vTabla.cat_Id,
                    descripcion = vTabla.descripcion,
                    usuarioCrea = vTabla.tbUsuarios.usu_NombreDeUsuario,
                    fechaCrea = General.FechaRetorno(vTabla.cat_FechaCrea),
                    usuarioModifica = General.UsuarioModifica(vTabla.cat_UsuarioModifica, vTabla?.tbUsuarios1?.usu_NombreDeUsuario),
                    fechaModifica = General.FechaModifica(vTabla.cat_FechaModifica)
                };

                return Json(result, JsonRequestBehavior.AllowGet);
            }

            // POST: Tabla/Create
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<JsonResult> Create([Bind(Include = "descripcion")] tabla tabla)
            {
                string response = "error";

                if (tabla.descripcion != null)
                {
                    try
                    {
                        if ( // Si se inserto mal retornar la vista
                            await Task.Run(() =>

                                // Retornar la insersion asincrona

                                db.
                                UDP_Esquema_vTabla_Insert(
                                    tabla.descripcion,
                                    1)
                                .FirstOrDefault().Id == -1
                            )
                            )
                        {
                            return Json(response, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            //Si se inserto bien redireccionar al index
                            response = "bien";
                        }
                    }
                    catch (Exception)
                    {
                        return Json(response, JsonRequestBehavior.AllowGet);
                    }
                }

                return Json(response, JsonRequestBehavior.AllowGet);
            }

            // POST: Tabla/Edit/5
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<JsonResult> Edit([Bind(Include = "cat_Id,descripcion")] tabla tabla)
            {
                string response = "error";

                if (tabla.cat_Id != 0 && tabla.descripcion != null)
                {
                    try
                    {
                        if ( // Si se inserto mal retornar la vista
                            await Task.Run(() =>

                                 // Retornar la insersion asincrona
                                 db.
                                UDP_Esquema_vTabla_Update(
                                    tabla.cat_Id,
                                    tabla.descripcion,
                                    1)
                                .FirstOrDefault()
                                .Id == -1
                            )
                            )
                        {
                            return Json(response, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            //Si se inserto bien redireccionar al index
                            response = "bien";
                        }
                    }
                    catch (Exception)
                    {
                        return Json(response, JsonRequestBehavior.AllowGet);
                    }
                }

                return Json(response, JsonRequestBehavior.AllowGet);
            }

            // POST: Tabla/Delete/5
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public async Task<JsonResult> DeleteConfirmed(int id)
            {
                string response = "error";
                try
                {
                    tabla tabla = await db.tabla.FindAsync(id);
                    db.tabla.Remove(tabla);
                    await db.SaveChangesAsync();
                    response = "bien";
                }
                catch (Exception)
                {
                    return Json(response, JsonRequestBehavior.AllowGet);
                }
                return Json(response, JsonRequestBehavior.AllowGet);
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
}*/