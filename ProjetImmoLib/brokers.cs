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
    
    public partial class brokers
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public brokers()
        {
            this.appointments = new HashSet<appointments>();
        }
    
        public int idBroker { get; set; }
        public string lastname { get; set; }
        public string firstname { get; set; }
        public string mail { get; set; }
        public string phonenumber { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<appointments> appointments { get; set; }
    }
}
