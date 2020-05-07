using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace backend.DTOs
{
    public class TipoItemDTO
    {
        public int Id { get; set; }
        
        [Required (ErrorMessage="Nome para o tipo é obrigatorio.")]
        public string Name { get; set; }
        public List<ItemDTO> Items { get; set; }
    }
}