//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Pharmacist
    {
        public Pharmacist()
        {
            this.Interventions = new HashSet<Intervention>();
            this.Contributions = new HashSet<Contribution>();
            this.Kpis = new HashSet<Kpi>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public int DisplayOrder { get; set; }
    
        public virtual ICollection<Intervention> Interventions { get; set; }
        public virtual ICollection<Contribution> Contributions { get; set; }
        public virtual ICollection<Kpi> Kpis { get; set; }
    }
}
