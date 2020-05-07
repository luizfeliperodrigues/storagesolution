using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace backend.DTOs
{
    public class ItemDTO
    {
        public int Id { get; set; }

        [Required (ErrorMessage="O campo {0} é obrigatorio.")]
        [RegularExpression("([0-9]*)", ErrorMessage = "Codigo deve ser numérico.")]
        public int BusinessCode { get; set; }

        [Required (ErrorMessage="O campo {0} é obrigatorio.")]
        public string Description { get; set; }

        [Required (ErrorMessage="O campo {0} é obrigatorio.")]
        [RegularExpression("([0-9]*)", ErrorMessage = "Codigo deve ser numérico.")]
        public int StoredQuantity { get; set; }

        [Required (ErrorMessage="O campo {0} é obrigatorio.")]
        [RegularExpression("([0-9]*)", ErrorMessage = "Codigo deve ser numérico.")]
        public double Price { get; set; }
        public double PriceReference { get; set; }

        [Required (ErrorMessage="O campo {0} é obrigatorio.")]
        public string Local { get; set; }
        public TipoItemDTO TipoItem { get; set; }
        public ComitenteDTO Comitente { get; set; }
        public List<AuctionDTO> Auctions { get; set; }
    }
}