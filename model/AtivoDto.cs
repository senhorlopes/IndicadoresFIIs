namespace fiisapi.model
{
    public class AtivoDto
    {
        public AtivoDto(string ativo)
        {
            this.Ativo = ativo;
        }
        public string Ativo {get; set; }
        public string LiquidezDiaria {get; set; }
        public string UltimoRendimento {get; set; }
        public string DividendYeld {get; set; }
        public string PatrimonioLiquido {get; set; }
        public string ValorPatrimonial {get; set; }
        public string RentabilidadeNoMes {get; set; }
        public string Pvp {get; set; }
    }
}