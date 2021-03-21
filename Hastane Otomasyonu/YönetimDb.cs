using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Hastane_Otomasyonu
{
    public class YönetimDb:DbContext
    {
        public DbSet<Kullanıcılar> Kullanıcılar { get; set; }
        public DbSet<Hastalar> Hastalar { get; set; }
    }
}
