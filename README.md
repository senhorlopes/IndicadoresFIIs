# IndicadoresFIIs
Api para retornar alguns indicadores de fundos imobiliários. 

# Compilar e executar
Basta executar os comandos:
  - dotnet restore
  - dotnet run

# Utililização
Existem dois gets criados
  - /api/resumo/getjson?ativos=ativo1;ativo2
    - Devolve um json com os dados dos fundos informados informados. 

  - /api/resumo/getxlsx?ativos=ativo1;ativo2
    - Devolve uma planilha (xlsx) com os dados dos fundos informados. 

# Excemplo
* JSON
  - http://localhost:5000/api/resumo/getjson?ativos=bcff11;mxrf11
    - [{"ativo":"bcff11","liquidezDiaria":"91.888","ultimoRendimento":"R$ 0,53","dividendYeld":"0,54%","patrimonioLiquido":"R$ 1,2 bi","valorPatrimonial":"R$ 94,27","rentabilidadeNoMes":"-2,16%","pvp":"0,93"},{"ativo":"mxrf11","liquidezDiaria":"689.784","ultimoRendimento":"R$ 0,09","dividendYeld":"0,80%","patrimonioLiquido":"R$ 760 mi","valorPatrimonial":"R$ 10,09","rentabilidadeNoMes":"-3,34%","pvp":"0,99"}]
  - http://localhost:5000/api/resumo/getxlsx?ativos=bcff11;mxrf11
    - Vai fazer download da planilha criada.
