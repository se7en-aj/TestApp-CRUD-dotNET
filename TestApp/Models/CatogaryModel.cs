using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestApp.Models
{
    public class CatogaryModel
    {
        //Creating Table Column

        [Key]
        public int CatID { get; set; }


        [Required]
        public string Name { get; set; }


        [DisplayName("Display Oder")]
        [Required]
        [Range(1,int.MaxValue,ErrorMessage ="Don't enter less then 1")]
        public int Order { get; set; }
    }
}
