using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProEventos.Application.Dtos
{
    public class EventoDto
    {
        public int Id { get; set; }

        [Range(1,1200)]
        public int QtdPessoas { get; set; }

        [StringLength(50, MinimumLength = 4, ErrorMessage = "Tem que ter mais que 4 e menos que 50")]
        public string Local { get; set; }

        public string DataEvento { get; set; }

        [Required(ErrorMessage="O campo {0} é obrigatório.")]
        [MinLengthAttribute(4),
        MaxLengthAttribute(50)]
        public string Tema { get; set; }

        [RegularExpression(@".*\(gif|jpe?g|bmp|png)$")]
        public string ImagemURL { get; set; }

        [Phone]
        public string Telefone {get;set;}

        [Display(Name = "e-mail")]
        [EmailAddress(ErrorMessage = "O campo {0} não é um email válido")]
        public string Email { get; set; }
        
        public IEnumerable<LoteDto> Lotes {get;set;}

        public IEnumerable<RedeSocialDto> RedesSociais {get;set;}

        public IEnumerable<PalestranteDto> Palestrantes {get;set;}
    }
}