using System.ComponentModel.DataAnnotations;

namespace VideoGame.Data.Entities
{
    public class Riesgo
    {
        public int Id { get; set; }

        [Display(Name = "Nombre del riesgo")]
        public string Nombre { get; set; }

        [Display(Name = "Descripcion del riesgo")]
        public string Descripcion { get; set; }

        [Display(Name = "Tipo de riesgo")]
        public string TipoRiesgo { get; set; }

        public int gameId { get; set; }


    }
}