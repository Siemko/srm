﻿using System.ComponentModel.DataAnnotations;

namespace SRM.Models.ViewModels.StudentsList
{
    public class StudentGroupVM
    {
        [StringLength(100)]
        public string Name { get; set; }
    }
}
