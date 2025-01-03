﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CelebrateIt.Models
{
    public class Categories
    {
        public int CategoryId { get; set; }

        [MaxLength(150)]
        public string CategoryName { get; set; }

        public ParentCategory ParentCategory { get; set; }

        [InverseProperty("Categories")]
        public ICollection<Facilities> Facilities { get; set; }

    }
}