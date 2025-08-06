using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Dto
{
    public class PropostaResponseDto
    {
        public string Id { get; set; }
        public decimal Price { get; set; }
        [JsonIgnore]
        public StatusProposta StatusProposta { get; set; }
        public string? Status { get => Enum.GetName(StatusProposta); }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
