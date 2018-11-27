using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HRPartners.Models
{
    public class ExpenditueModel
    {
        [Key]
        public int ExpenditureId { get; set; }

        public decimal Budget { get; set; }

        public string Comment { get; set; }
    }
}