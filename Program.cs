using System;

namespace Revisao
{
    class Program
    {
        static void Main(string[] args)
        {
            Aluno[] alunos = new Aluno[5];
            var indiceAluno = 0;
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X") // ToUpper() = vai pegar a letra do usuário e mudar para caixa alta
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        Console.WriteLine("Informe o nome do aluno:");
                        var aluno = new Aluno();// instanciando um objeto aluno
                        aluno.Nome = Console.ReadLine();// recebendo do usuário e atribuindo ao objeto aluno

                        Console.WriteLine("Informe a nota do aluno:");
                       
                        if (decimal.TryParse(Console.ReadLine(), out decimal nota))
                        // TryParse = indica que pode ou não fazer o 'Parse' 
                        // Caso o TryParse consiga fazer a consversão, ele já atribui o valor para a variavel nota
                        {
                            aluno.Nota = nota;
                        }else
                        {
                            throw new ArgumentException("O valor da nota deve ser em decimal");
                        }
                        // Atribuindo o objeto 'aluno' que foi criado na posição do array 'alunos[]' 
                        // indicada pelo 'indiceAluno'
                        alunos[indiceAluno] = aluno;
                        indiceAluno++;
                        break;
                    case "2":
                        // foreach = Para cada 'ListaAluno' no meu array 'alunos' faça...
                        foreach(var listaAluno in alunos)
                        {
                            if(!string.IsNullOrEmpty(listaAluno.Nome))
                            // ! = nega a condição, se o 'Nome' for diferente de nulo ou vazio faça...
                            {
                                // $ = string interpolation, para facilitar a concatenação
                                Console.WriteLine($"ALUNO: {listaAluno.Nome} - NOTA: {listaAluno.Nota}");
                            }
                            
                        }
                        break;
                    case "3":
                        decimal notaTotal = 0;
                        var nrAlunos = 0;

                        for(var i=0; i < alunos.Length; i++)
                        {
                             if(!string.IsNullOrEmpty(alunos[i].Nome))
                             {
                                 notaTotal = notaTotal + alunos[i].Nota;
                                 nrAlunos++;
                             }
                        }

                        var mediaGeral = notaTotal / nrAlunos;
                        ConceitoEnum conceitoGeral;

                        if(mediaGeral <= 2)
                        {
                            conceitoGeral = ConceitoEnum.E;
                        }else if (mediaGeral <=4) 
                        {
                            conceitoGeral = ConceitoEnum.D;
                        }else if (mediaGeral <= 6)
                        {
                            conceitoGeral = ConceitoEnum.C;
                        }else if (mediaGeral < 10)
                        {
                            conceitoGeral = ConceitoEnum.B;
                        }else
                        {
                            conceitoGeral = ConceitoEnum.A;
                        }
                        Console.WriteLine($"MÉDIA GERAL: {mediaGeral} - CONCEITO GERAL: {conceitoGeral}");

                        break;
                    default:
                        throw new ArgumentOutOfRangeException(); // Vai disparar uma exeção indicando que o valor informado 
                                                                 // esta fora das opções 
                }

                    opcaoUsuario = ObterOpcaoUsuario();
            }
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1 - Inserir novo aluno");
            Console.WriteLine("2 - Listar alunos");
            Console.WriteLine("3 - Calcular média");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine(); // Vai receber a opção do usuário
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
