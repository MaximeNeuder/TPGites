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
    
    public partial class tarif
    {
        public int numGite { get; set; }
        public int numPeriode { get; set; }
        public Nullable<decimal> prixSemaine { get; set; }
    
        public virtual gite leGite { get; set; }
        public virtual periode laPeriode { get; set; }
    }
}
