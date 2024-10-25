Em desenvolvimento 


# Projeto Docker

## Especificação

1. Projeto API
2. Projeto Worker Services

### Vamos detalhar o que foi feito no projeto API.  

Para usar o Docker ao criar o projeto, podemos deixar selecionado o checkbox "Habilitar o suporte a contêiner", e assim o suporte será configurado automaticamente. Caso você já tenha um projeto que não tenha sido habilitado o uso do Docker por padrão, isso poderá ser feito clicando no seu projeto com o botão direito, selecionando "Adicionar" e clicando em "Suporte de Orquestrado de Containers". Com essa ação, será gerado um arquivo **Dockerfile** no seu projeto.

No meu caso, foi gerado o arquivo, mas eu tive que atualizar o meu arquivo `.csproj` adicionando a seguinte linha:

```xml
<DockerDefaultTargetOS>Linux</DockerDefaultTargetOS>
```

Isso deve ser colocado dentro do bloco `PropertyGroup`.

Dentro do meu projeto, no arquivo Program.cs, eu remove todas as configurações de uso de container, para em seguida adicionar a classe de endpoints. Esta classe, foi utilizada para manter os endpoints de acesso a minha apliação, nela foi configurada um endpoint post conforme imagem: 

![endpoints.png](wwwroot/img)
