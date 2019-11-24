using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VideoGame.Data.Entities
{
    public class Desarrollador
    {
        public int Id { get; set; }

        public User User { get; set; }
    }
}
