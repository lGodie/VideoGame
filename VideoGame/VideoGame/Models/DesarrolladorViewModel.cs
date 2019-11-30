using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VideoGame.Models
{
    public class DesarrolladorViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Nombre ")]
        [Required(ErrorMessage = "digite Nombre")]
        public string Nombre { get; set; }

        [Display(Name = "Apellido")]
        public string Apellido { get; set; }


        [Display(Name = "Cargo")]
        public string cargo { get; set; }


        [Display(Name = "Genero")]
        public string Genero{ get; set; }

        [Display(Name = "Telefono")]
        public string Telefono { get; set; }

    }
}
