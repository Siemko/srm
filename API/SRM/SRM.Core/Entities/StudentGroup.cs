﻿using System.ComponentModel.DataAnnotations;

namespace SRM.Core.Entities
{
    public class StudentGroup
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }
    }
}
