using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProyectoCursos.Modelos;
public class Curso {
    [Required(ErrorMessage = "* La clave del curso no puede estar vacía")]
    [StringLength(10, ErrorMessage = "La clave no puede exceder a 10 posiciones")]
    [DisplayName("Clave del Curso:")]        
    public String Clave {get; set;}

    [Required]
    [StringLength(100)]
    [DisplayName("Nombre del Curso:")]
    public String Nombre {get; set;}
    [Required]
    [StringLength(1000)]
    public String Descripcion {get; set;}
    [Required]
    [StringLength(100)]
    public String Instructor {get; set;}
    [Required]
    public DateTime FechaInicio {get; set;}
    [Required]
    public DateTime FechaTermino {get; set;}
    [Required]
    [Range(10, 60, ErrorMessage ="* El número de horas debe estar entre 10 y 60")]
    public int NoHoras {get; set;}
}