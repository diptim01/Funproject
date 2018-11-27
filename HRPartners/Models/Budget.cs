using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HRPartners.Models
{
    public class Budget
    {
        [Key]
        public int BudgetId { get; set; }

        public int FicsID { get; set; }
        public int SeismicId { get; set; }
        public int ExpenditureId { get; set; }
        public int PartnerId { get; set; }
        public bool IsBudgetApproved { get; set; }
        public bool IsSentToNexs { get; set; }


        [ForeignKey("PartnerId")]
        public PartnerModel PartnerModel { get; set; }
        [ForeignKey("FicsID")]
        public FicsModel FicsModel { get; set; }
        [ForeignKey("SeismicId")]
        public SeismicModel SeismicModel { get; set; }
        [ForeignKey("ExpenditureId")]
        public ExpenditueModel ExpenditureModel { get; set; }


    }
}