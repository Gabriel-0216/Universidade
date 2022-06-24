# Projeto Universidade
### Esse é o projeto mais denso que já criei até hoje.
###### O objetivo é simular um ambiente de gestão de instituições de ensino superior com painel de gestão da universidade + ambiente para alunos onde eles possam verificar e pagar mensalidades em aberto e até se matricular em cursos...

O projeto basicamente implementa alguns padrões e diversas coisas que o .NET nos provê.

Identity para autenticação/autorização, Entity Framework Core com code-first e FluentMapping, uso da biblioteca Flunt para validações das entidades no dominio, padrão Repository no acesso a dados, CQRS implementado com a biblioteca MediatR, WebApp com arquitetura MVC, WebApi REST, uso do template Worker Service para processamento das mensagens, RabbitMQ, Docker, Testes unitários com xUnit

##### O projeto é composto por algumas camadas:

#### -> Dominio
##### Onde todas as regras de negócio e validações estão centralizadas, todos os modelos do sistema

#### -> Infra
##### Camada de acesso a dados com padrão Repository, mapeamentos das entidades no Entity Framework Core

#### -> Application
##### Implementação do padrão CQRS + MediatR, toda a lógica da aplicação passa por essa camada, consultas, comandos...

#### -> Negocios 
##### Essa camada é responsável por comunicar com o message broker do RabbitMQ, é uma camada acessada apenas pela API e pelo WebApp

#### -> Servicos
##### Algumas rotinas como a geração de contrato e pagamento das mensalidades funcionam por mensageria, cada uma dessas rotina tem um projeto separado onde cada projeto roda pelo template Worker Service em segundo plano escutando as mensagens da fila e fazendo o processamento.

#### -> WebApp
##### Aplicação Web MVC

#### -> WebApi
##### Aplicação WebApi, o objetivo é replicar o WebApp em uma SPA com Angular.

#### -> Testes unitários
##### Camada pra testes do dominio.


### Exemplo simples de funcionamento:
#### Cadastros simples: [Gerenciamento de cursos, estudantes (Create, Read, Update, Delete)]
##### Aplicação Web/API envia uma requisição via MediatR; handler do Command/Query na camada Application recebe a requisição e envia a resposta

#### Rotina "complexa": [Pagamento de mensalidade, geração de contrato]
##### Aplicação Web/API envia requisição para a camada de negócios, camada de negócios envia para o message broker; Camada de serviço que está escutando a fila recebe a mensagem e envia para a camada de Application via MediatR

Tentativa de representação da arquitetura:

![](https://github.com/Gabriel-0216/Universidade/blob/master/diagramaarquitetura.png)
