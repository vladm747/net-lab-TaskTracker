using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using TaskTrackerDAL.Enums;

namespace TaskTrackerDAL.Entities
{
    public class ToDo
    {
        [Key]
        public int ToDoId { get; set; }
        [Required]
        [StringLength(40)]
        public string Name { get; set; }
        [Required]
        [StringLength(250)]
        public string Description { get; set; }
        [Required]
        public decimal RequiredTime { get; set; }
        [Required]
        public Status Status { get; set; }
        [Required]
        public Priority Priority { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
