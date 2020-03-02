# Gerenciamento-de-Consulta
Sistema de gerenciamento de consulta .NET framework e Vue.js



# Iniciando projeto
 - banco de dados SqlServer
 - versão do .NET framework 4.7.2
 - versão do nodeJs 10.16.3
 - versão do Vue.js 2.6.11



# Gerar Migrations e Banco de Dados
 -Comando necessarios
   - Fazer o Downloads do Projeto no GitHub;
   - Abrir o projeto clicando em 'Gerenciamento de Consulta.sln' no VS 2019;
   - Nos arquivos "Web.config" dentro do projeto "WebApi" e o arquivo "App.config" dentro do projeto "RepositoryWebApi" verifique se a connectionString utilizada é compativel com seu servidor de banco de dados;
   - No Search digitar "Console" e selecionar o Packege Maneger Console;
   - No Packege Maneger Console(que abre na parte de baixo da tela);
   - Digitar os Seguintes comandos: 
  
	> Enable-Migrations - (A primeira vez para criar, depois não necessario)
	
	> add-Migration
	
	> update-database

 -Abrir a pasta 'frontend' no VS CODE, abrir o terminal utilizando o comando (CTRL + "):

	> npm install

	> npm rum serve (Para rodar o projeto)




# Arquitetura do Projeto Gerenciamento de Consulta

 - Arquitetura Utilizada - DDD (Domain Driven Design)

 -Domain (RepositoryWebApi)

	> Repository: Fazem as funções de CRUD no Banco de Dados.
	
	> Models: São onde se encontra as Class (Agendamento, Anaminese, Pacientes), e pasta de Enum(EnumPartesCorpos, EnumPlanos).

	> Map: Pasta onde se encontra a class MapConfig, que cria o mapeamento entre (PacienteDTO, AnamineseDTO, AgendamentoDTO).

	> DTO: Pasta onde se encontra os class PacienteDTO, AnamineseDTO, AgendamentoDTO que servem para fazer mapeamento com as class Paciente, Anaminese, Agendamento.


 -Driver (WebApi):

	> Controllers : Faz a comunicações com o Front-End, por meio do Json.

	> Service: Executam as regras de negocios e fazem a comunicação com o Front-End, por meio de Json.

	> Utilidades: Onde se encontra a Class que faz a validação do cpf.



-Design (Front Vue):

	> Public: Onde ficam as imagens do projeto.

	> Components: Contem os componetes HTML.

	> Pages: Contem as paginas desenvolvidas em vue.js e suas funções em javascript.

	> Service: São os serviços que fazem a integração com a WebApi, utilizando o Axios para fazer a comunicação com o beck-end.




# Ferramentas adicionais usadas

AutoMapp:

	> ferramenta c# utilizada para fazer mapeamento automatico entre classes, está sendo utilizada para fazer a conversão das classes do sistema para as classes DTO nas controllers.
	> documentação: https://docs.automapper.org/en/stable/Getting-started.html

Entity Framework code-frist:
	
	> Configuração do Entity Framework para gerar o banco de dados de forma semi automatica com base no código 
	> documentação: https://docs.microsoft.com/pt-br/aspnet/mvc/overview/getting-started/getting-started-with-ef-using-mvc/creating-an-entity-framework-data-model-for-an-asp-net-mvc-application

	
vue-bootstrap:

	> pacote do npm, disponibiliza components css para facilitar a criação do layout do site
	> documentação: https://bootstrap-vue.js.org/
	
axios:

	> pacote do npm, utilizado para realizar as requisições em promise para o backend
	> documentação: https://www.npmjs.com/package/axios  

v-mask: 

	> pacote do npm, utilizado para aplicar mascaras nos campos
	> documentação: https://www.npmjs.com/package/v-mask