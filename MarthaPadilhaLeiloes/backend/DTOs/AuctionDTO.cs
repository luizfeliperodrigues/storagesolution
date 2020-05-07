using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace backend.DTOs
{
    public class AuctionDTO
    {
        public int Id { get; set; }

        [Required (ErrorMessage="Codigo para o comitente é obrigatorio.")]
        [RegularExpression("([0-9]*)", ErrorMessage = "Codigo deve ser numérico.")]
        public int BusinessCode { get; set; }

        [Required (ErrorMessage="0 para Compra e 1 para Venda.")]
        public NegotiationDTO Negotiation { get; set; }

        [Required (ErrorMessage="Preencher a data é obrigatório.")]
        public string Date { get; set; }
        public List<ItemDTO> Items { get; set; }
    }
}