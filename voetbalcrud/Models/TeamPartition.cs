//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace voetbalcrud.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TeamPartition
    {
        public int PositionID { get; set; }
        public int SetupID { get; set; }
        public int Amount { get; set; }
    
        public virtual Position Position { get; set; }
        public virtual Setup Setup { get; set; }
    }
}
