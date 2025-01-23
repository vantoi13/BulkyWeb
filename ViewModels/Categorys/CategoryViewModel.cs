using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BulkyWeb.ViewModels.Categorys
{
    public class CategoryViewModel
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Category Name")]
        public string? Name { get; set; }

        [DisplayName("Display Order")]
        public int? DisplayOrder { get; set; }


    }
}