using System.ComponentModel.DataAnnotations;

namespace CaseItau.API.Model
{
    public class Fund
    {
        [Required]
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Cnpj { get; set; }
        [Required]
        public decimal? Patrimony { get; set; }
        [Required]
        public FundType Type { get; set; }
    }
}
