using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HRPartners.Models
{
    public class Nexs
    {
        [Key]
        public int NexsId { get; set; }

        [ForeignKey("PartnerModel")]
        public int PartnersId { get; set; }
        public decimal FicBudget { get; set; }
        public decimal SeismicBudget { get; set; }
        public decimal ExpenditureBudget { get; set; }

        public PartnerModel PartnerModel { get; set; }

    }
}