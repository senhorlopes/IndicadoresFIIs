using System.Collections.Generic;
using System.IO;
using System.Linq;
using fiisapi.model;
using fiisapi.regras;
using Microsoft.AspNetCore.Mvc;

namespace fiisapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResumoController: ControllerBase
    {
        private IEnumerable<AtivoDto> GetAtivos(string ativos)
        {
            var listaNomeAtivos = new List<string>();
            if (ativos.Contains(";"))
                listaNomeAtivos = ativos.Split(';').ToList();
            else 
                listaNomeAtivos.Add(ativos);
            
            var listaAtivos = new List<AtivoDto>();
            
            var resumoAtivo = new ResumoAtivo();

            foreach (var ativo in listaNomeAtivos)
                listaAtivos.Add(resumoAtivo.GetResumo(ativo));
           
            return listaAtivos;
        } 

        [HttpGet("GetJson")]
        public IEnumerable<AtivoDto> Get(string ativos)
        {
            return GetAtivos(ativos);
        }

        [HttpGet("GetXlsx")]
        public IActionResult GetXlsx(string ativos)
        {
            var nomeArquivo = new AtivosExcel().Criar(GetAtivos(ativos));
            var stream = System.IO.File.OpenRead(nomeArquivo);
            return new FileStreamResult(stream,"application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }
    }
}