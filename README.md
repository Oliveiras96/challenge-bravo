# <img src="https://avatars1.githubusercontent.com/u/7063040?v=4&s=200.jpg" alt="HU" width="24" /> Desafio Bravo

Esta é a minha implementação o [desafio bravo](https://github.com/hurbcom/challenge-bravo) construída com .Net Core + SQL (back-end) e React.js (front-end). 

Ps: o projeto ainda está em andamento, portanto algumas funcionalidades obrigatórias da proposta do desafio ainda não foram implementadas. Tenha em mente que esta é a implementação de um iniciante e portanto contem erros, fique a vontade para sugerir melhorias!

A API responde JSON, para conversão monetária. Usa como moeda de lastro o USD e faz conversões entre diferentes moedas com cotações de verdade e atuais (embora essas cotações ainda não sejam atualizadas de maneira automática).

Atualmente, a API converte entre as seguintes moedas:

-   USD
-   BRL
-   EUR
-   BTC
-   ETH

Ex: USD para BRL, USD para BTC, ETH para BRL, etc...

A requisição recebe como parâmetros: A moeda de origem, o valor a ser convertido e a moeda final.

Ex: `?from=BTC&to=EUR&amount=123.45`

## A ser implementado:

- Endpoint para adicionar e remover moedas suportadas pela API, usando os verbos HTTP;
- Volume de requisições exigido pelo desafio original;

# Front-end

Uma aplicação SPA feita com react em simples para consumir os serviços da API.
