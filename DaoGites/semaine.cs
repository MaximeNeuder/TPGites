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
    
    public partial class semaine
    {
        public semaine()
        {
            this.lesPlannings = new HashSet<planning>();
        }
    
        public int numsemaine { get; set; }
        public System.DateTime dateDebutSemaine { get; set; }
        public Nullable<System.DateTime> dateFinSemaine { get; set; }
        public Nullable<int> numPeriode { get; set; }
    
        public virtual periode laPeriode { get; set; }
        public virtual ICollection<planning> lesPlannings { get; set; }
    }
}
