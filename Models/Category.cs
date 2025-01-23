using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BulkyWeb.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public int? DisplayOrder { get; set; }

    }
}