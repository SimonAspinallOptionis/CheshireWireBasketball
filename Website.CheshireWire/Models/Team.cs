//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Website.CheshireWire.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Team
    {
        public Team()
        {
            this.Players = new HashSet<Player>();
            this.Coaches = new HashSet<Coach>();
            this.Fixtures = new HashSet<Fixture>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public int LeagueId { get; set; }
    
        public virtual League League { get; set; }
        public virtual ICollection<Player> Players { get; set; }
        public virtual ICollection<Coach> Coaches { get; set; }
        public virtual ICollection<Fixture> Fixtures { get; set; }
    }
}
