using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFramework2SQLLibrary
{
    public partial class RequestLine
    {
        public int Id { get; set; }
        public int RequestId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        [ForeignKey("ProductId")]
        [InverseProperty("RequestLine")]
        public virtual Products Product { get; set; }
        [ForeignKey("RequestId")]
        [InverseProperty("RequestLine")]
        public virtual Request Request { get; set; }
    }
}
