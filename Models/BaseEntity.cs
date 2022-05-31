using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearningProject.Models
{
    public class BaseEntity
    {
        public string CreatedBy { get; set; }
        public DateTime Created { get; set; }
    }
}
