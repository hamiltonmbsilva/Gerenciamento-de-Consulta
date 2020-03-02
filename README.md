# Gerenciamento-de-Consulta
Sistema de gerenciamento de consulta C# .net

# Iniciando projeto

# Gerar Migrations e Banco de Dados
 -Comando necessarios
   - Fazer o Downloads do Projeto no GitHub;
   - Abrir o projeto clicando em 'Gerenciamento de Consulta.sln' no VS 2019;
   - No Search digitar "Consoler";
   - No Packege Maneger Console(que abre na parte de baixo da tela);
   - Digitar os Seguintes comandos: 
  
	> Enable-Migrations - (A primeira vez para criar, depois não necessario)
	
	> add-Migration
	
	> upadate-database
 -Abrir a pasta 'frontend' no VS CODE, abrir o terminal utilizando o comando (CTRL + "):

	> npm install

	> npm rum serve (Para rodar o projeto)

# Arquitetura do Projeto Gerenciamento de Consulta

 -Back-End (WebApi):

	> Controllers : Faz a comunicações com o Front-End, por meio do Json.

	> Service: Executam as regras de negocios e fazem a comunicação com o Front-End, por meio de Json.

	> Utilidades: Onde se encontra a Class que faz a validação do cpf.

	> Repository: Fazem as funções de CRUD no Banco de Dados.
	
	> Models: São onde se encontra as Class (Agendamento, Anaminese, Pacientes), e pasta de Enum(EnumPartesCorpos, EnumPlanos).

	> Map: Pasta onde se encontra a class MapConfig, que cria o mapeamento entre (PacienteDTO, AnamineseDTO, AgendamentoDTO).

	> DTO: Pasta onde se encontra os class PacienteDTO, AnamineseDTO, AgendamentoDTO que servem para fazer mapeamento com as class Paciente, Anaminese, Agendamento.

-Front-End (Front Vue):

	> Public: Onde ficam as imagens do projeto.

	> Components: Contem os componetes HTML.

	> Pages: Contem as paginas desenvolvidas em vue.js e suas funções em javascript.

	> Service: São os serviços que fazem a integração com a WebApi, utilizando o Axios para fazer a comunicação com o beck-end.

# Ferramentas adicionais usadas

-eslint:

	> pacote do npm, utilizado para formatar o código no padrão 'AiBNB styleguide'
	> documentação: https://www.npmjs.com/package/eslint
	
vue-bootstrap:

	> pacote do npm, disponibiliza components css para facilitar a criação do layout do site.
	> documentação: https://bootstrap-vue.js.org/
	
axios:

	> pacote do np, utilizado para realizar as requisições em promise para o backend
	> documentação: https://www.npmjs.com/package/axios  



	



