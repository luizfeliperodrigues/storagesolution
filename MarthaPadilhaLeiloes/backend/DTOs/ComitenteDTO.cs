using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace backend.DTOs
{
    public class ComitenteDTO
    {
        public int Id { get; set; }

        [Required (ErrorMessage="Codigo para o comitente é obrigatorio.")]
        [RegularExpression("([0-9]*)", ErrorMessage = "Codigo deve ser numérico.")]
        public int BusinessCode { get; set; }

        [Required (ErrorMessage="Nome para o comitente é obrigatorio.")]
        public string Name { get; set; }
        public List<ItemDTO> Items { get; set; }
    }
}