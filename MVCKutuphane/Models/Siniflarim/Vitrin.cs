using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCKutuphane.Models;


namespace MVCKutuphane.Models.Siniflarim
{
    public class Vitrin
    {
        public IEnumerable<tblkitaplar> kitapresim { get; set; }
        public IEnumerable<tblhakkimizda> hakkimizda { get; set; }
    }
}