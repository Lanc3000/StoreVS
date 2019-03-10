using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Magazin.Domain.Entities
{
     public class Goods
    {

        [Display(Name = "ID")]
        public int GoodsId { get; set; }

        [Display(Name = "Название")]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Display(Name = "Категория")]
        public string Category { get; set; }

        [Display(Name = "Цена (руб)")]
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Пожалуйста, введите положительное значение для цены")]
        public decimal Price { get; set; }

        [Display(Name = "Размер")]
        public int Size{ get; set; }

        [Display(Name = "Картинка")]
        public byte[] ImageData { get; set; }

        public string ImageMimeTipe { get; set; }

    }
}
