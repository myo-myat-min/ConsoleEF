using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleEF
{
    internal class Device
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SerialNo { get; set; }

        [Required]
        [Index("UK_Device", IsUnique = true)]
        [MaxLength(15)]
        public string DeviceName { get; set; }

    }
}
