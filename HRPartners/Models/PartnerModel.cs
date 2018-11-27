using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HRPartners.Models
{
    public class PartnerModel
    {
        [Key]
        public int PartnersId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public decimal EstimatedValue { get; set; }
    }
}