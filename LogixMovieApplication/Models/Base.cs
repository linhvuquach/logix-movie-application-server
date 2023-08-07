using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Logix_Movie_Application.Models
{
    public abstract class Base
    {
        [Key]
        public int Id { get; set; }
    }
}