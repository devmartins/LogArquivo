# LogArquivo

Biblioteca .Net Framework para gerar log em arquivo txt.<br>
<br>
Métodos disponiveis:<br>
Log.Excecao(Exception ex)<br>
Log.Erro(string conteudo)<br>
Log.Mensagem(string conteudo)<br>
Log.Info(string conteudo)<br>
<br>
Nuget Package:<br>
<a href="https://www.nuget.org/packages/LogArquivo" target="_blank">LogArquivo
 <img src="https://img.shields.io/badge/Nuget-1.1.0-green.svg"/></a><br>
<br>
Requer um arquivo "Web.config/App.config" na pasta do projeto com a chave GerarLog:<br>
```js
<add key="GerarLog" value="true" />
```

Exemplo:
```c#
using LogArquivo;

try
{
  File.ReadAllText("qualquer.txt");
}
catch (Exception ex)
{
  Log.Excecao(ex);
}
```

Ferramentas:<br>
Visual Studio 2019 Community<br>
.Net Framework 4 - Roda em apps Console/Web<br>
C#<br>
