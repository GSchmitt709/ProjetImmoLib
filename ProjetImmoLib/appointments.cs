//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjetImmoLib
{
    using System;
    using System.Collections.Generic;
    
    public partial class appointments
    {
        public int idApointment { get; set; }
        public System.DateTime dateHour { get; set; }
        public string subject { get; set; }
        public int idBroker { get; set; }
        public int idCustomer { get; set; }
    
        public virtual brokers brokers { get; set; }
        public virtual customers customers { get; set; }
    }
}
