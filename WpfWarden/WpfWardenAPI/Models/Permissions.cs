using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfWardenAPI.Models
{
    internal class Permissions
    {
        public int PermissionId { get; set; }
        public string Name { get; set; }
        public bool AddData { get; set; }
        public bool ChangeData { get; set; }
        public bool MakeReport { get; set; }
        public bool DeleteData { get; set; }
    }
}
