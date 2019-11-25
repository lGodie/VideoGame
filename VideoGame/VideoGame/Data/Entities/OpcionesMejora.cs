using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VideoGame.Data.Entities
{
    public class OpcionesMejora
    {
        public int Id { get; set; }

        [Display(Name = "Descripcion de la mejora")]
        public string Descripcion { get; set; }

        [Display(Name = "Tipo de mejora")]
        public string TipoOpcionMejora { get; set; }

        public int gameId { get; set; }

    }
}
