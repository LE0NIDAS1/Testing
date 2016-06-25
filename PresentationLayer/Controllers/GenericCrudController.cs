using BusinessLayer.Interface;
using PresentationLayer.Controllers;
using PresentationLayer.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;


public abstract class GenericCrudController<mo, dt> : BaseController
{


    protected IBLGenericCRUD<dt> _bl { get; set; }

    protected abstract mo ConvertDTToMO(dt dataType);

    protected abstract dt ConvertMOToDT(mo model);

    //Obtiene todo los dataType del bl y los convierte en model
    protected List<mo> GetAll()
    {
        try
        {
            List<dt> listDT = _bl.getAll();
            return listDT.Select(x => ConvertDTToMO(x)).ToList();
        }
        catch (Exception)
        {
            throw new Exception("error desconocido");;
        }

    }

    protected mo GetForId(int id)
    {
        return ConvertDTToMO(_bl.getForId(id));
    }

    //Carga un modelo para mandarlo con valores iniciales para crear
    protected abstract mo PreLoadModelToCreate();

    //Carga un modelo para mandarlo con valores iniciales para Editar
    protected abstract mo PreLoadModelToEdit();

    //Carga los valores que van en el ViewData, ejemplo para los drop
    protected abstract void LoadViewDataToCreate();

    //Carga los valores para el Edit
    protected abstract mo LoadDataToEdit(int id);

    protected abstract List<mo> loadDataToIndex();

    protected ActionResult BlCreate(mo model)
    {
        try
        {
            _bl.create(ConvertMOToDT(model));
        }
        catch (Exception)
        {
            throw new Exception("error desconocido");;
        }
        return RedirectToAction("Index");
    }

    protected ActionResult BlEdit(mo model)
    {
        try
        {
            _bl.update(ConvertMOToDT(model));
        }
        catch (Exception)
        {
            throw new Exception("error desconocido");;
        }
        return View();
    }

    protected void BlDelete(int id)
    {
        try
        {
            _bl.delete(id);
        }
        catch (Exception)
        {
            throw new Exception("error desconocido");;
        }
    }


    // GET: Attribute
    public ActionResult Index()
    {
        List<mo> listModel = new List<mo>();
        try
        {
            listModel = loadDataToIndex();
        }
        catch (Exception ex)
        {
            throw new Exception("error desconocido");;
        }
        return View(listModel);
    }

    // GET: Attribute/Details/5
    public ActionResult Details(int id)
    {
        mo model;
        try
        {
            model = GetForId(id);
        }
        catch (Exception ex)
        {
            throw new Exception("error desconocido");;
        }
        return View(model);
    }

    // GET: Attribute/Create
    public ActionResult Create()
    {
        LoadViewDataToCreate();
        mo model = PreLoadModelToCreate();
        return View(model);
    }

    // POST: Attribute/Create
    [HttpPost]
    public ActionResult Create(mo model)
    {
        try
        {
            return BlCreate(model);
        }
        catch
        {
            LoadViewDataToCreate();
            return View(model);
        }
    }

    // GET: Attribute/Edit/5
    public ActionResult Edit(int id)
    {
        mo model = LoadDataToEdit(id);
        return View(model);
    }

    // POST: Attribute/Edit/5
    [HttpPost]
    public ActionResult Edit(mo model)
    {
        try
        {
            BlEdit(model);
        }
        catch
        {
            PreLoadModelToEdit();
            return View(model);
        }
        return RedirectToAction("Index");
    }

    // GET: Attribute/Delete/5
    public ActionResult Delete(int id)
    {
        BlDelete(id);
        return RedirectToAction("Index");
    }
}