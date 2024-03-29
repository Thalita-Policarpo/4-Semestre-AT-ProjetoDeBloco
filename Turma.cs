using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4ºSemestre_AT_ProjetoDeBloco
{
    internal class Turma
    {
        private List<Aluno> alunos = new List<Aluno>();
        private Professor professor;
        private Disciplina disciplina;
        private const int capacidadeMinima = 10; // Capacidade mínima da turma
        private const int capacidadeMaxima = 50; // Capacidade máxima da turma

        public string Codigo { get; set; }
        public int NumeroDeAlunos => alunos.Count;
        public List<Aluno> Alunos => alunos; // Adicionado para corrigir o erro
        public Disciplina Disciplina => disciplina; // Adicionado para corrigir o erro

        public string AddAluno(Aluno aluno)
        {
            if (NumeroDeAlunos >= capacidadeMaxima)
            {
                return "Turma já está cheia.";
            }
            else if (alunos.Contains(aluno))
            {
                return "Aluno já adicionado.";
            }
            else
            {
                alunos.Add(aluno);
                aluno.AddTurma(this);
                if (NumeroDeAlunos >= capacidadeMinima)
                {
                    return "Aluno adicionado. Turma pode ser aberta.";
                }
                else
                {
                    return $"Aluno adicionado. Turma precisa de mais {capacidadeMinima - NumeroDeAlunos} alunos para ser aberta.";
                }
            }
        }

        public bool AbrirTurma()
        {
            return NumeroDeAlunos >= capacidadeMinima && NumeroDeAlunos <= capacidadeMaxima;
        }

        public void AddProfessor(Professor professor)
        {
            this.professor = professor;
            professor.AddTurma(this);
        }

        public void AddDisciplina(Disciplina disciplina)
        {
            this.disciplina = disciplina;
            disciplina.AddTurma(this);
        }

        public string GerarPauta()
        {
            StringBuilder pauta = new StringBuilder($"Código da Turma: {Codigo}\n");
            pauta.AppendLine($"Nome da Disciplina: {disciplina.Nome}");
            pauta.AppendLine($"Nome do Professor: {professor.Nome}");
            pauta.AppendLine("Lista de Alunos:");
            foreach (var aluno in alunos)
            {
                pauta.AppendLine(aluno.ToString());
            }
            return pauta.ToString();
        }
    }
}
