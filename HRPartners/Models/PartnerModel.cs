using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRPartners.Models
{
    public class PartnerModel
    {
        public int PartnersId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public decimal EstimatedValue { get; set; }
    }
}