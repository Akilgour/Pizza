using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pizza.Repository.Model
{
    public abstract class BaseModel
    {

        [Key]
        [Required]
        [Column(Order = 0)]
        //TODO AK Put in, will probably need to script a db update
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
    }
}