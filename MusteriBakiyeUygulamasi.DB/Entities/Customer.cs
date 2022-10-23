using System;
using System.Collections.Generic;

namespace MusteriBakiyeUygulamasi.DB.Entities
{
    public partial class Customer
    {
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string TckNo { get; set; } = null!;
        public string? Birthday { get; set; }

        public virtual CustomerAccount? CustomerAccount { get; set; }
    }
}
