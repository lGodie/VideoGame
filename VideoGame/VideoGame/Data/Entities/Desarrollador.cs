﻿using System.ComponentModel.DataAnnotations;

namespace VideoGame.Data.Entities
{
    public class Desarrollador
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
        public string Genero { get; set; }

        [Display(Name = "Telefono")]
        public string Telefono { get; set; }
        public User User { get; set; }
    }
}
