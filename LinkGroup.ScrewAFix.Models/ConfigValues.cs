using System;
using System.Collections.Generic;
using System.Text;

namespace LinkGroup.ScrewAFix.Models
{
   public class ConfigValues
    {
        public const string ConfigName = "ConfigValues";

        public string AccountEndpoint  { get; set; }
        public string InventoryEndpoint { get; set; }
        public string PaymnetEndpoint { get; set; }
        public string CoommunicationsEndpoint { get; set; }


    }
}
