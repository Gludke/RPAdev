using System.ComponentModel.DataAnnotations;

namespace RPAdev.Domain.Models;

public class Course : Entity//entidade pai base para abstrações futuras
{
    [MaxLength(150, ErrorMessage = "Título deve ter no máximo 150 caracteres")]
    public string Title { get; set; }
    [MaxLength(1000, ErrorMessage = "Professores deve ter no máximo 1000 caracteres")]
    public string Teachers { get; set; }
    [MaxLength(50, ErrorMessage = "Carga horária deve ter no máximo 50 caracteres")]
    public string Workload { get; set; }
    [MaxLength(5000, ErrorMessage = "Descrição deve ter no máximo 5000 caracteres")]
    public string Description { get; set; }

    public Course()
    {
    }

    public Course(string title, string teachers, string workload, string description)
    {
        Title = title;
        Teachers = teachers;
        Workload = workload;
        Description = description;
    }
}
