### Configurações para rodar a aplicação
Configurar as informações do banco de dados no appsettings.json, colocando do nome da Database e as informações do seu banco de dados SQL “myconn”.

precisa ir até tools e abrir o Package Manager Console, colocando o comando **Update-Database -Context BancoDBContext**
Que o banco de dados vai ser criado no SQL.

Para logar no sistema tem que criar um usuario dentro do SQL através do insert:

**Insert Into dbo.Login(Login, Senha) Values('user1', '7110eda4d09e062aa5e4a390b0a572ac0d2c0220')**

O sistema só faz a leitura de senha encriptada, no caso essa é *1234*.
Depois só fazer o rodar o sistema e colocar como login **user1 e a senha 1234**.
