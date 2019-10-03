using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VideoGame.Models
{
    public partial class Games
    {
        public int Id { get; set; }



        [Display(Name = "Име")]
        [Required(ErrorMessage = "Името е задължително поле")]
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
        [Required(ErrorMessage = "tamaño invalido")]
        public string GameSize { get; set; }

        [Display(Name = "Plataforma")]
        [Required(ErrorMessage = "Ingrese plataforma")]
        public string Platform { get; set; }

        [Display(Name = "Genero")]
        public string Genre { get; set; }


        [Display(Name = "Tipo")]
        public string Type { get; set; }

    }
    }
