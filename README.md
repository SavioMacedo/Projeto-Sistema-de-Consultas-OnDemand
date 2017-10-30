# Sistema de Execução Facilitada de SQL
Olá, este sistema foi feito para a disciplina de projetos 3 da graduação do curso de Sistemas de Informação do Centro de Ensino Superior de Juiz de Fora/CES-JF.
## Afinal, o que faz?
O mesmo é uma interface amigavel para a execução de SQL em cima de bases predeterminadas, o objetivo do mesmo é que os resultados de SQL que são frequentemente pedidos para a area de ti por outra area da empresa, possam ser executados por meio de apenas um botão pelo usuario final, no caso a area que sempre solicita par a TI.
A TI pode cadastrar os SQL's e parametros e setar o banco de dados alvo por meio de uma configuração amigavel.
## Arquitetura
O projeto está sendo construido em cima da linuagem ASP.NET Core 2.x, o mesmo roda em cima de um banco de dados SQLite gerido pela própria aplicação.
O banco alvo para execução dos SQL's está sendo o data warehouse AdventureWorks 2014 da Microsoft para estudos, e a configuração está sendo feita internamente, via código C#.
## Status do Projeto
O objetivo inicial para a entrega do trabalho é o funcionamento da execução e parametrização deste Execucação por meio de uma interface amigavel.
Para trabalhos futuros, este projeto irá receber autenticação via Identity provido pelo .Net Core e a configuração do banco de dados alvo das execução via interface e não mais como código conforme é atualmente.
