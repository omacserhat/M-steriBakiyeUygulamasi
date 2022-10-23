using System;
using System.Collections.Generic;

namespace MusteriBakiyeUygulamasi.DB.Entities
{
    public partial class CustomerAccount
    {
        public string AccountNumber { get; set; } = null!;
        public decimal Balance { get; set; }
        public string TckNo { get; set; } = null!;

        public virtual Customer TckNoNavigation { get; set; } = null!;
    }
}
