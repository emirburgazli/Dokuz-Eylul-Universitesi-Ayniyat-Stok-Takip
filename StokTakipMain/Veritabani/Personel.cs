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
    
    public partial class Personel
    {
        public Personel()
        {
            this.Urun_Hareket = new HashSet<Urun_Hareket>();
        }
        public override string ToString()
        {
            return Ad;
        }
        public int Personel_ID { get; set; }
        public Nullable<int> Unvan_ID { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public Nullable<int> Bolum_ID { get; set; }
        public string Sicil_No { get; set; }
        public string Gorev { get; set; }
    
        public virtual Bolum Bolum { get; set; }
        public virtual Unvanlar Unvanlar { get; set; }
        public virtual ICollection<Urun_Hareket> Urun_Hareket { get; set; }
    }
}
