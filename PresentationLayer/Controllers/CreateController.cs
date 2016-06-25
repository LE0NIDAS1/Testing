using BusinessLayer;
using BusinessLayer.Implementation;
using BusinessLayer.Interface;
using PresentationLayer.Helper;
using PresentationLayer.Models;
using PresentationLayer.Models.ActionModels;
using Shared.ActionEntities;
using Shared.JuegoEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace PresentationLayer.Controllers
{
    public class CreateController : ActionConfigController
    {
        private IBLGameObject blGob = new BLGameObject();
        private IBLCreate blCreate = new BLCreate();

        // GET: Create/Create
        public ActionResult CreateActionCreatePartial(CreateModel model)
        {
            try
            {
                cargarSelectListGOB(model.IDGame);
                cargarListaTipoAccion();
            }
            catch (Exception)
            {
                throw new Exception("error desconocido");;
            }
            return PartialView(); 
        }

        // POST: Create/Create
        [HttpPost]
        public ActionResult CreateActionCreatePartial(CreateModel model, FormCollection collection)
        {
            try
            {
                DTCrearConfig createDT = new DTCrearConfig();
                createDT.IDGame = model.IDGame;
                //List<DTGameObject> listGob = new List<DTGameObject>();
                //var idGobSelected = collection.Get("GameObject").Split(',');
                //foreach (String id in idGobSelected)
                //{
                //    listGob.Add(blGob.getGameObject(int.Parse(id)));
                //}
                //createDT.gameObjects = listGob;
                createDT.IDGameObject = model.idGameObject;
                createDT.name = "Crear";
                createDT.TypeAction = "Crear";
                blCreate.create(createDT);
                cargarSelectListGOB(model.IDGame);
                cargarListaTipoAccion();
            }
            catch (Exception ex)
            {
                throw new Exception("error desconocido");;
            }

            return OnSuccessCreateGoToPage(model.IDGame);

        }

        private SelectList cargarSelectListGOB(int idGame)
        {
            IBLCreate blActionCreate = new BLCreate();
            List<GameObjectModel> listGob = blActionCreate.GetAllGOBTime(idGame).Select(x => ConversionHelper.GameObjectToModel(x)).ToList();
            List<DTCrearConfig> listAction = blActionCreate.getAll();
            int i = 0;
            foreach (DTActionConfig action in listAction)
            {
                while (i < listGob.Count)
                {
                    if (action.IDGameObject == listGob.ElementAt(i).Id)
                    {
                        listGob.Remove(listGob.ElementAt(i));
                        i = 0;
                    }
                    else
                    {
                        i++;
                    }
                }
                i = 0;
            }
            var list2 = new SelectList(listGob, "ID", "Name");
            ViewData["GameObject"] = list2;
            return ViewData["GameObject"] as SelectList;
        }

        /// <summary>
        /// Página que sigue al resultado exitoso de un Create
        /// </summary>
        /// <returns></returns>
        private ActionResult OnSuccessCreateGoToPage(int idGame)
        {
            MensajeDesplegar("Accion creada con éxito.");
            return View();
        }
    }
}
