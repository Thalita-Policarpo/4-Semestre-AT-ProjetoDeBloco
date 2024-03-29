
namespace _4ºSemestre_AT_ProjetoDeBloco
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Criação dos professores
            Professor joao = new Professor { Nome = "João", Matricula = "123" };
            Professor jose = new Professor { Nome = "José", Matricula = "456" };

            // Criação das disciplinas
            Disciplina java = new Disciplina { Nome = "Java", Codigo = "JAVA101", Professor = joao };
            Disciplina dotNet = new Disciplina { Nome = ".Net", Codigo = "NET101", Professor = jose };
            Disciplina pb = new Disciplina { Nome = "PB", Codigo = "PB101", Professor = jose };

            // Criação das turmas
            Turma turma1 = new Turma { Codigo = "1" };
            turma1.AddDisciplina(java);
            turma1.AddProfessor(joao);

            Turma turma2 = new Turma { Codigo = "2" };
            turma2.AddDisciplina(dotNet);
            turma2.AddProfessor(jose);

            Turma turma3 = new Turma { Codigo = "3" };
            turma3.AddDisciplina(pb);
            turma3.AddProfessor(jose);

            // Criação dos alunos

            Aluno aluno1 = new Aluno { Nome = "Aluno 1", Matricula = "789" };
            aluno1.AddTurma(turma1);
            turma1.AddAluno(aluno1);

            int qtdAluno = 2;

             for (int i = 1; i <= 11; i++)
            {
                Aluno aluno = new Aluno { Nome = $"Aluno {qtdAluno}", Matricula = $"{789 + qtdAluno}" };
                aluno.AddTurma(turma1);
                turma1.AddAluno(aluno);
                qtdAluno++;
            }

            for (int i = 12; i <= 25; i++)
            {
                Aluno aluno = new Aluno { Nome = $"Aluno {qtdAluno}", Matricula = $"{789 + qtdAluno}" };
                aluno.AddTurma(turma2);
                turma2.AddAluno(aluno);
                qtdAluno++;
            }

            // Exibindo as alocações
            Console.WriteLine("Alocação de Turmas");
            Console.WriteLine(turma1.GerarPauta());
            Console.WriteLine(turma2.GerarPauta());
            Console.WriteLine(turma3.GerarPauta());

            Console.WriteLine($"\nAlocação do aluno: {aluno1.Nome}");
            Console.WriteLine(aluno1.ExibirTurmas());

            Console.WriteLine($"\nAlocação do Professor: {jose.Nome}");
            Console.WriteLine(jose.ExibirTurmas());

            Console.WriteLine($"\nAlocação da disciplina : {dotNet.Nome}");
            Console.WriteLine(dotNet.ExibirTurmas());

            // Adicionando mais alunos à turma 1 para atingir a capacidade máxima
            for (int i = 10; i <= 50; i++)
            {
                Aluno aluno = new Aluno { Nome = $"Aluno {i}", Matricula = $"{i}" };
                aluno.AddTurma(turma1);
                turma1.AddAluno(aluno);
            }

            // Tentando adicionar mais um aluno à turma 1
            Aluno aluno51 = new Aluno { Nome = "Aluno 51", Matricula = "51" };
            string resultado = turma1.AddAluno(aluno51);
            Console.WriteLine($"\nTentativa de adicionar aluno à turma 1: {resultado}");

            // Tentando abrir a turma 3 que não tem alunos
            bool podeAbrir = turma3.AbrirTurma();
            Console.WriteLine($"\nTentativa de abrir a turma 3: {(podeAbrir ? "Sucesso" : "Falha, não há alunos suficientes")}");
        }
    }
}
