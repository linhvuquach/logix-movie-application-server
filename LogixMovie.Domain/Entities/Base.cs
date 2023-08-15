using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogixMovie.Domain.Entities
{
    public abstract class Base
    {
        [Key]
        public int Id { get; set; }
    }
}
