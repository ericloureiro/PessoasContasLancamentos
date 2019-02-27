# PessoasContasLancamentos

Considerando os seguintes arquivos de texto localizados na pasta "Arquivos":

- pessoa.mxm
Contém dados dos usuários do sistema de um banco. Cada linha representa um usuário. Os valores em cada linha estão separados pelo caractere "|", sendo o primeiro valor correspondente ao código do usuário e o segundo ao nome do usuário.

- conta.mxm
	Contém os relacionamentos entre os usuários do sistema e suas contas-correntes. Cada usuário contido no arquivo “pessoa.mxm” pode ter de 1 a N contas. Cada linha representa o relacionamento entre um usuário e uma conta. Os valores em cada linha estão separados pelo caractere "|", sendo o primeiro valor correspondente ao código da conta e o segundo ao código do usuário (mesmo código existente no arquivo “pessoa.mxm”).

- lancamento.mxm
	Contém lançamentos de valores feitos em contas-correntes. Cada conta corrente contida no arquivo “conta.mxm” pode ter de 0 a N lançamentos. Cada linha representa um lançamento feito na conta. Os valores em cada linha estão separados pelo caractere "|", sendo o primeiro valor correspondente ao código da conta e o segundo ao valor do lançamento, que pode ser positivo ou negativo.
Pede-se:

1 – Gerar um arquivo csv com o nome “devedores.mxm”. Esse arquivo deve conter todos usuários cuja soma de todos os lançamentos em todas as suas contas seja negativa. Em cada linha, colocar dois valores: o nome (não é o código, é o nome) do usuário e a soma de todos lançamentos em todas as suas contas.
Ex:
Usuário 1,-987366.33;
Usuário 3,-125.63;
Usuário 7,-898.12;

2 – Gerar um arquivo csv com o nome “bonus.mxm”. Esse arquivo deve conter todos usuários cuja média de todos os lançamentos em todas as suas contas seja maior que R$ 1.000,00. Em cada linha, colocar dois valores: o nome (não é o código, é o nome) do usuário e a média de todos os lançamentos em todas as suas contas.
Ex:
Usuário 5,23987366.33;
Usuário 9,845632.12;
Usuário 8,1500.23;
