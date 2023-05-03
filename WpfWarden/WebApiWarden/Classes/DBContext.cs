using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiWarden.Models;

namespace WebApiWarden.Classes
{
    public class DBContext
    {
        public static WardenEntities db = new WardenEntities();
    }
}