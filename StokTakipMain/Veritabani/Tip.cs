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
    
    public partial class Tip
    {
        public Tip()
        {
            this.Urunler = new HashSet<Urunler>();
        }
        public override string ToString()
        {
            return Ad;
        }
        public int Urun_Tipi_ID { get; set; }
        public string Ad { get; set; }
    
        public virtual ICollection<Urunler> Urunler { get; set; }
    }
}
