//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PokemonGame.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Challenge
    {
        public int ChallengeId { get; set; }
        public int ChallengerId { get; set; }
        public int OpponentId { get; set; }
        public string Status { get; set; }
        public System.DateTime CreatedDate { get; set; }
    
        public virtual User User { get; set; }
        public virtual User User1 { get; set; }
    }
}
