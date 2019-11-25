using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VideoGame.Data.Entities
{
    public partial class Game
    {
        public int Id { get; set; }



        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Digite nombre")]
        public string Name { get; set; }

        [Display(Name = "Pais")]
        public string Country { get; set; }



        [Display(Name = "Sitio web")]
        [Required(ErrorMessage = "Sigite sitio web")]
        public string Website { get; set; }

        [Display(Name = "Descripción")]
        public string Description { get; set; }


        [Display(Name = "Lenguaje")]
        public string Languages { get; set; }


        [Display(Name = "Tamaño de juego")]
        [Required(ErrorMessage = "Tamaño invalido")]
        public string GameSize { get; set; }

        [Display(Name = "Plataforma")]
        [Required(ErrorMessage = "Ingrese plataforma")]
        public string Platform { get; set; }

        [Display(Name = "Genero")]
        public string Genre { get; set; }


        [Display(Name = "Tipo")]
        public string Type { get; set; }

        public ICollection<Riesgo> Riesgos { get; set; }

    }
    }
