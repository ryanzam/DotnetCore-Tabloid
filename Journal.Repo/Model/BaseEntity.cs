using System;
using System.ComponentModel.DataAnnotations;

namespace Journal.Repository.Model
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
}
