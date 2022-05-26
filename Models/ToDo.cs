using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KanbanProject.Models
{
    public class ToDo
    {
            [Key]
            [Column("Id")]
            [Display(Name = "Código")]
            public int Id { get; set; }
            [Column("Requerido")]
            [Display(Name = "Pendente")]
            public String? Resquested { get; set; }

            [Column("Em processo")]
            [Display(Name = "Em processo")]
            public String? Inprogress { get; set; }

            [Column("Feito")]
            [Display(Name = "Feito")]
            public String? Done { get; set; }
        }
    }


