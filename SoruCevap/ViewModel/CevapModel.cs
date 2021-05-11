using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoruCevap.ViewModel
{
    public class CevapModel
    {
        public int Id { get; set; }
        public string Icerik { get; set; }
        public int SoruId { get; set; }
        public int UyeId { get; set; }
    }
}