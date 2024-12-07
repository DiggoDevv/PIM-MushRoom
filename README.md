### Configurações para rodar a aplicação
Configurar as informações do banco de dados no appsettings.json, colocando o nome da Database e as informações do seu banco de dados SQL “myconn”.

no Visual Studio precisa ir na aba tools e abrir o Package Manager Console, colocando o comando **Update-Database -Context BancoDBContext**
Que o banco de dados vai ser criado no SQL.

Para logar no sistema tem que criar um usuario dentro do SQL, como o sistema só faz a leitura de senha encriptada, no caso o sistema utilizado é o SHA1, para criar uma senha encriptado basta acessar o site **http://www.sha1-online.com**, depois fazer o insert da senha, exemplo de insert:

**Insert Into dbo.Login(Login, Senha) Values('user1', '7110eda4d09e062aa5e4a390b0a572ac0d2c0220')**

No caso do exemplo essa é **1234**.
Depois de criado o usuario só rodar o sistema e colocar como login **user1 e a senha 1234**.
