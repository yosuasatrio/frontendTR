using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace frontendTR.Models
{
    public class ms_storage_location
    {
        public string location_id { get; set; }
        public string location_name { get; set; }

        public List<ms_storage_location> StorageLocationList { get; set; }
    }
}
