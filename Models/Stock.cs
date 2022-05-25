using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CSVFILE.Models
{
    public partial class Stock //Why this is partial, I know it might be due to EF but doesn't look right to me, for simple things you should have never have to use these
    {
        public int ProductId { get; set; }
        public string Product { get; set; }
        public string ProductCode { get; set; }
        public decimal? Price { get; set; }
    }
}
