# Propostas

## Requisitos

- [x] Docker
- [x] Docker Compose
- [x] Visual Studio
 
## Debug
1. Clone o reposit�rio
2. Execute o projedo docker-compose (Ele iniciar� o debug )
3. No projeto Infra.Database execute o comando 
	 ```bash
	   dotnet ef database update --connection "Server=localhost;Database=proposta;User Id=sa;Password=SqlServer2022!; TrustServerCertificate=True"
	```
4. Inicie o debug ![debug.](image/debug.png "debug.")

5. Para alterar quais os projetos ser�o iniciados no debug, 
	1. clique em "Manage Docker compose Launch Setting" ![debug-settings](image/debug-settings.png "debug-settings")
	2. Selecione os projetos que deseja iniciar e qual dever� ser aberto automaticamente pelo navegador(Voc� pode acessar os outros swagger normalmente pelo navegador) ![launch-settings](image/launch-settings.png "debug-settings2")