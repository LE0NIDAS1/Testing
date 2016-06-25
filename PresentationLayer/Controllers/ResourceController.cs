using BusinessLayer;
using BusinessLayer.Interface;
using PresentationLayer.Helper;
using PresentationLayer.Models;
using Shared.JuegoEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;



namespace PresentationLayer.Controllers
{
    public class ResourceController : BaseController
    {
        private IBLResource blRes = new BLResource();
        
        // GET: Resource
        public ActionResult Index()
        {
            List<ResourceModel> listModel = new List<ResourceModel>();
            try
            {
                List<DTResource> listResource = blRes.getAllResources();
                foreach (DTResource resource in listResource)
                {
                    listModel.Add(ConversionHelper.ResourceToModel(resource));
                }
            }
            catch (Exception ex)
            {
                throw new Exception("error desconocido");;
            }
            return View(listModel);
        }


        // GET: Resource/Create
        public ActionResult Create()
        {
            ResourceModel resModel = new ResourceModel();
            resModel.IdGame = int.Parse(Request.QueryString["IdGame"]);
            return View(resModel);
        }

        // POST: Resource/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                DTResource res = new DTResource();
                res.name = collection.Get("Name");
                res.image = "algo";
                res.idGame = int.Parse(collection.Get("IdGame"));
                blRes.addResource(res);
                return RedirectToAction("Edit", "Game", new { id = res.idGame });
            }
            catch (Exception ex)
            {
                throw new Exception("error desconocido");;
            }
        }

        // GET: Resource/Edit/5
        public ActionResult Edit(int id = -1)
        {
            ResourceModel resModel = new ResourceModel();
            try
            {
                DTResource res = blRes.getResource(id);
                resModel.Name = res.name;
                resModel.Id = res.id;
                string url = "";
                if (!String.IsNullOrEmpty(res.image))
                {
                   
                }
                resModel.Image = url;
            }
            catch (Exception)
            {
                throw new Exception("error desconocido");;
            }
            return View(resModel);
        }

        // POST: Resource/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                DTResource res = blRes.getResource(id);
                res.name = collection.Get("Name");
                
                blRes.updateResource(res);
                return OnSuccessEditGoToPage(res.idGame);
            }
            catch (Exception ex)
            {
                throw new Exception("error desconocido");;
            }
        }

        // GET: Resource/Delete/5
        public ActionResult Delete(int id = -1)
        {
            try
            {
                blRes.deleteResource(id);
            }
            catch (Exception)
            {
                throw new Exception("error desconocido");;
            }
            return RedirectToAction("Index", "Game", null);
        }

        /// <summary>
        /// Página que sigue al resultado exitoso de un Edit
        /// </summary>
        /// <returns></returns>
        private ActionResult OnSuccessEditGoToPage(int idGame)
        {
            MensajeDesplegar("Juego modificado.");

            return RedirectToAction("Edit", "Game", new { id = idGame });
        }
    }
}
