using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace ProyInstituto.Models
{
    public class Profesor
    {
        [Range(100,200,ErrorMessage ="El campo debe ser un n�mero entre 100 y 200")] 
        public int Id {get;set;}
        [Required,MaxLength(30)]
        [MinLength(3)]
        public string Nombre{get;set;}
        [Required(ErrorMessage ="Debe ingresar el Apellido")]
        public string Apellido{get;set;}
        [Required]
        [Range(11111,99999)]
        public int Legajo {get;set;}
        public bool ADistancia {get;set;}
        public int DNI {get;set;}
        public DateTime FechaNacimiento {get;set;}
        [Range(1,3)]
        public int Nivel {get;set;}
        
        //public Carrera CarreraDictada {get;set;} 
        public int Materia{get;set;}
    }
}