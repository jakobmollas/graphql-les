﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace graphql_les.Models
{
    public class Platform
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }

        public string LicensKey { get; set; }

        public ICollection<Command> Commands { get; set; } = new List<Command>();
    }
}
