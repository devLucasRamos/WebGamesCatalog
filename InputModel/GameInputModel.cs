using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebGamesCatalog.InputModel
{
    public class GameInputModel
    {
        [Required]
        [StringLength(100,MinimumLength =3,ErrorMessage ="É necessario inserir um nome para o jogo de 3 a 100 caracteres!!")]
        public string Name { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "É necessario inserir um nome para a produtora do jogo de 3 a 100 caracteres!!")]
        public string Prod { get; set; }
        [Required]
        [Range(1,1000,ErrorMessage = "É necessario inserir um valor entre 1 a 1000 reais!!")]
        public double Price { get; set; }
    }
}
