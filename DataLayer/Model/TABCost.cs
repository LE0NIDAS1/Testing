
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------


namespace DataLayer.Model
{

using System;
    using System.Collections.Generic;
    
public partial class TABCost
{

    public int Quantity { get; set; }

    public int ID_RESOURCE_FK { get; set; }

    public int ID_GAMEOBJECT_FK { get; set; }

    public int ID { get; set; }



    public virtual TABResource TABResource { get; set; }

    public virtual TABGameObject TABGameObject { get; set; }

}

}
