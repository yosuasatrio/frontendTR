﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace frontendTR.Models
{
    public class tr_bpkb
    {
        public string agreement_number { get; set; }
        public string bpkb_no { get; set; }
        public string branch_id { get; set; }
        public string bpkb_date { get; set; }
        public string faktur_no { get; set; }
        public string faktur_date { get; set; }
        public string location_id { get; set; }
        public string police_no { get; set; }
        public string bpkb_date_in { get; set; }

    }
}
