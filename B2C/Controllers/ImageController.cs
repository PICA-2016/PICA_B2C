using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace B2C.Controllers
{
    /// <summary>
    /// Controller Image.
    /// </summary>
    public class ImageController : Controller
    {
        // GET: Image
        public FileResult Index(int id)
        {
            //return File(Contenido, TipoArchivo, Nombre);
            return null;
        }
    }
}