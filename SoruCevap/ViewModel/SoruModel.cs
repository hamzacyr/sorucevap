using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoruCevap.ViewModel
{
    public class SoruModel
    {
        public int Id { get; set; }
        public string Baslik { get; set; }
        public string Icerik { get; set; }
        public string Tarih { get; set; }
        public int UyeId { get; set; }
        public int KatId { get; set; }
    }
}