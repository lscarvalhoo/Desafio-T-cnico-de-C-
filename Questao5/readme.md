Saudações, segue algumas instruções e sugestões para teste dos serviços em conjunto.

1 - No serviço "Saldo", especificamente o arquivo appSettings.json e DbConnectionFactory(Localizado em Infrastructure -> Persistence), 
é necessário colocar o caminho do banco de dados SQLite, para obter, basta ir no serviço "Movimento" localizar o arquivo database.sqlite, 
click botão direito, "Copy Full Path" e colar nos respectivos lugares mencionados que estarão assinalados com "SQL_PATH".


2 - Execução separada dos serviços, em algum terminal(VS Code, PowerShell, GitBash), 
ir ao diretório de cada um via terminal ex:\Desafio Técnico de C#\Questao5\Saldo> e utilizar os comandos:
 - dotnet build
 - dotnet watch run ou dotnet run

3 - Os testes unitários utilizando NSubstitute estão localizados nas respectivas pastas para cada serviço
