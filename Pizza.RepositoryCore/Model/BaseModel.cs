﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pizza.Repository.Model
{
    public abstract class BaseModel
    {

        [Key]
        [Required]
        [Column(Order = 0)]
        public Guid Id { get; set; }     
    }
}