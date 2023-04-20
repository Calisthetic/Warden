using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfWarden.Models;

namespace WpfWarden.Classes
{
    internal class DBContext
    {
        public static WardenEntities db = new WardenEntities();
    }
}
