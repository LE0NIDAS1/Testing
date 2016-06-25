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


namespace PresentationLayer.Controllers
{
    public class GenerateController : BaseController
    {
        private IBLGenerate blGenerate = new BLGenerate();
        private IBLResource blRes = new BLResource();

        // GET: Generate
        public ActionResult Index()
        {
            List<GenerateModel> listModel = new List<GenerateModel>();
            try
            {
                List<DTGenerate> listGenerate = blGenerate.getAllGenerates();
                foreach (DTGenerate generate in listGenerate)
                {
                    listModel.Add(ConversionHelper.GenerateToModel(generate));
                }
            }
            catch (Exception ex)
            {
                throw new Exception("error desconocido");;
            }
            return View(listModel);
        }

        // GET: Generate/Details/5
        public ActionResult Details(int id)
        {
            GenerateModel generateModel;
            try
            {
                DTGenerate generate = blGenerate.getGenerate(id);
                generateModel = ConversionHelper.GenerateToModel(generate);
            }
            catch (Exception)
            {
                throw new Exception("error desconocido");;
            }
            return View(generateModel);
        }

        // GET: Generate/Create
        public ActionResult Create(int idGameObject, int idGame)
        {
            cargarListaRecuros(idGame);

            GenerateModel model = new GenerateModel();
            model.Id_GameObject = idGameObject;
            return View(model);
        }

        // POST: Generate/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            GenerateModel generateModel = new GenerateModel();
            generateModel.Id_GameObject = int.Parse(collection.Get("id_GameObject"));
            generateModel.Id_Resource = int.Parse(collection.Get("id_Resource"));
            generateModel.time = int.Parse(collection.Get("time"));
            generateModel.Quantity = int.Parse(collection.Get("Quantity"));
            try
            {
                DTGenerate generate = new DTGenerate();
                generate.idGameObject = generateModel.Id_GameObject;
                generate.idResource = generateModel.Id_Resource;
                generate.time = generateModel.time;
                generate.quantity = generateModel.Quantity;
                blGenerate.addGenerate(generate);
                return RedirectToAction("Index", "Game", null);
            }
            catch
            {
                //cargarListaRecuros();
                return View(generateModel);
            }
        }

        // GET: Cost/Edit/5
        public ActionResult Edit(int id=-1)
        {
            GenerateModel generateModel;
            try
            {
                //cargarListaRecuros();
                DTGenerate generate = blGenerate.getGenerate(id);
                generateModel = ConversionHelper.GenerateToModel(generate);
            }
            catch (Exception)
            {
                throw new Exception("error desconocido");;
            }
            return View(generateModel);
        }

        // POST: Cost/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            GenerateModel generateModel = new GenerateModel();
            //generateModel.Id_Resource = int.Parse(collection.Get("id_Resource"));
            generateModel.time = int.Parse(collection.Get("time"));
            generateModel.Quantity = int.Parse(collection.Get("Quantity"));
            try
            {
                DTGenerate generate = blGenerate.getGenerate(id); ;
                //generate.idResource = int.Parse(collection.Get("id_Resource"));
                generate.time = int.Parse(collection.Get("time"));
                generate.quantity = int.Parse(collection.Get("Quantity"));
                blGenerate.updateGenerate(generate);
                return RedirectToAction("Index", "Game", null);
            }
            catch
            {
                //cargarListaRecuros();
                return View(generateModel);
            }
        }

        private void cargarListaRecuros(int idGame)
        {
            List<DTResource> listResBase = blRes.getAllResources();
            List<ResourceModel> listResModel = new List<ResourceModel>();
            foreach (DTResource resource in listResBase)
            {
                if (resource.idGame == idGame)
                {
                    listResModel.Add(ConversionHelper.ResourceToModel(resource));
                }
            }
            ViewData["Resource"] = new SelectList(listResModel, "ID", "Name");
        }

        // GET: Cost/Delete/5
        public ActionResult Delete(int idGameObject, int id=-1)
        {
            try
            {
                blGenerate.deleteGenerate(id);
            }
            catch (Exception)
            {
                throw new Exception("error desconocido");;
            }
            return RedirectToAction("Index", "Game", null);
        }

        // POST: Cost/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index", "Game", null);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("error desconocido");;
        //    }
        //}
    }
}
