//------------------------------------------------------------------------------
// <auto-generated>
//    Ce code a été généré à partir d'un modèle.
//
//    Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//    Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DaoGites
{
    using System;
    using System.Collections.Generic;
    
    public partial class contrat
    {
        public contrat()
        {
            this.lesGitesReserves = new HashSet<planning>();
        }
    
        public int numContrat { get; set; }
        public Nullable<System.DateTime> dateContrat { get; set; }
        public Nullable<int> valide { get; set; }
        public Nullable<int> annule { get; set; }
        public Nullable<int> numClient { get; set; }
    
        public virtual client leClient { get; set; }
        public virtual ICollection<planning> lesGitesReserves { get; set; }
    }
}
