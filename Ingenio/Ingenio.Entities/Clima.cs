using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingenio.Entities
{
    [Table("Clima")]
    public class Clima
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Ciudad { get; set; }

        public DateTime? Fecha { get; set; }
        public TimeSpan? Hora { get; set; }

        [Required]
        [StringLength(10)]
        public string Temperatura { get; set; }
        [StringLength(10)]
        public string precipitaciones { get; set; }

        public double Humendad { get; set; }

        [Required]
        [StringLength(10)]
        public string Viento { get; set; }

    }
}
