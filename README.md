# Projeto Docker

## Introdução

Este projeto foi desenvolvido visando o aprendizado da arquitetura Docker. Sempre tive pré-conceito sobre esta arquitetura, mas ao estudar o desenvolvimento e implantação, identifiquei que tudo depende da necessidade. Em alguns casos, teremos a necessidade de quebrar o projeto em outros pequenos projetos, facilitando o desenvolvimento e entrega do produto. 

## Concepção

Para iniciarmos, foi gerado dois projetos para este estudo.
1 - Projeto API
2 - Projeto Worker Services

Vamos detalhar o que foi feito no projeto API. 
Para trabalhar utilizando docker ao gerar o projeto podemos marcar o campo "Habilitar uso de containers", caso você já tenha um projeto que não tenha sido habilitado o uso do docker por padrão, isso poderá ser feito clicando no seu projeto com o botão direito, adicionar e click em Suporte de Orquestrado de Containers. Com essa ação, será gerado um arquivo DockerFile no seu projeto. No meu caso, foi gerado o arquivo, mas eu tive que atualizar o meu csproject adicionado a seguinte linha ** <DockerDefaultTargetOS>Linux</DockerDefaultTargetOS> __, dentro do PropertyGroup. 

Para usar o docker ao criar o projeto podemos deixar selecionado o checkbox Habilitar o suporte a contêiner, e gerar
