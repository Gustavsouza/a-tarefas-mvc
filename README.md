
# Controle de tarefas MVC

Uma breve descrição sobre o que esse projeto faz e para quem ele é

#Clonagem do repositório: Comece clonando este repositório para sua máquina local usando o comando:
git clone https://github.com/seu-usuario/a-tarefas-mvc.git

Configuração do Banco de Dados: Abra a solução no Visual Studio e execute o seguinte comando no Console do Gerenciador de Pacotes para criar o banco de dados:
Add-Migration Inicial

Aplicação do Banco de Dados: Depois de criar a migração, aplique as alterações do banco de dados usando o comando:
Update-Database


aplicação através do Swagger pelo link:
https://localhost:Porta/index.html

Acesse a seção de gerenciamento de tarefas através do link: https://localhost:Porta/tarefas
  Nesta seção, você pode realizar operações de criação, leitura, atualização e exclusão 


•	CriarTarefa: Permite criar uma nova tarefa.

•	ObterTarefaPorId: Permite obter os detalhes de uma tarefa específica com base em seu ID.

•	ObterTodasAsTarefas: Retorna a lista de todas as tarefas cadastradas.

•	AtualizarTarefa: Permite atualizar os detalhes de uma tarefa existente.

•	DeletarTarefa: Remove uma tarefa com base no ID fornecido.

•	FinalizarTarefa: Marca uma tarefa como concluída.

•	ListarTarefasPorStatus: Lista as tarefas com base no status de conclusão.

•	UsuariosMaisFinalizaram: Retorna estatísticas sobre os usuários que mais finalizaram tarefas.


Acesse a seção de gerenciamento de usuários pelo link: https://localhost:Porta/Usuarios
Nesta área, você também pode executar operações de criação, leitura, atualização e exclusão 

•	Criar: Permite criar um novo usuário.

•	Obter: Permite obter os detalhes de um usuário com base no endereço de e-mail.

•	ObterTodos: Retorna a lista de todos os usuários cadastrados.

•	Atualizar: Permite atualizar os detalhes de um usuário existente.

•	Deletar: Remove um usuário com base no ID fornecido.

•	TarefasPorUsuario: Retorna as tarefas associadas a um usuário específico


Configure o appsettings.json 
"ConnectionStrings": {
    "TarefasGmillConnection": "Server=(localdb)\\MSSQLLocalDB;Database=TarefasGmill;Trusted_Connection=True;MultipleActiveResultSets=true"
  }

