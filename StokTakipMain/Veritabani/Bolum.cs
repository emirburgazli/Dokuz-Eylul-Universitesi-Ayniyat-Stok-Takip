//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StokTakipMain.Veritabani
{
    using System;
    using System.Collections.Generic;
    
    public partial class Bolum
    {
        public Bolum()
        {
            this.Personel = new HashSet<Personel>();
        }
        public override string ToString()
        {
            return Bolum_Adi;
        }
        public int Bolum_ID { get; set; }
        public string Bolum_Adi { get; set; }
    
        public virtual ICollection<Personel> Personel { get; set; }
    }
}
