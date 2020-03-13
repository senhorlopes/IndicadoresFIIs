using System;
using System.Linq;
using fiisapi.model;
using HtmlAgilityPack;

namespace fiisapi.regras
{
    public class ResumoAtivo
    {
        string url = "https://www.fundsexplorer.com.br/funds/";
        public AtivoDto GetResumo(string nomeAtivo)
        {
            var ativo = new AtivoDto(nomeAtivo);
            var doc = new HtmlWeb().Load(url+nomeAtivo);
            var resultado = doc.DocumentNode.SelectNodes("//div[@class='carousel-cell']").ToList();

            foreach (var node in resultado)
            {
                try
                {
                    var texto = node.SelectSingleNode(".//span[@class='indicator-title']").InnerText.Trim();
                    var valor = node.SelectSingleNode(".//span[@class='indicator-value']").InnerText;
                    valor = valor.Replace('\n', ' ').Trim();

                    Set(ativo,texto,valor);
                }
                catch (Exception)
                {
                }
            }

            return ativo;
        }

        private void Set(AtivoDto ativo, string texto, string valor)
        {
            if (texto == "Liquidez Diária") 
                ativo.LiquidezDiaria = valor;
            else if (texto == "Último Rendimento") 
                ativo.UltimoRendimento = valor;
            else if (texto == "Dividend Yield") 
                ativo.DividendYeld = valor;
            else if (texto == "Patrimônio Líquido") 
                ativo.PatrimonioLiquido = valor;
            else if (texto == "Valor Patrimonial") 
                ativo.ValorPatrimonial = valor;
            else if (texto == "Rentab. no mês") 
                ativo.RentabilidadeNoMes = valor;
            else if (texto == "P/VP") 
                ativo.Pvp = valor;
        }
    }
}