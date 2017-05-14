using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TestOdataWS.Models;

namespace WebApplication1.Models
{
    public partial class CredentialTechnoA : Credential
    {
        [StringLength(1073741823)]
        public string technoAPrivateData { get; set; }

    }
}