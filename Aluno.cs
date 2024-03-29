using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4ºSemestre_AT_ProjetoDeBloco
{
    internal class Aluno
    {
        public string Nome { get; set; }
        public string Matricula { get; set; }
        public List<Turma> Turmas { get; set; } = new List<Turma>();

        public void AddTurma(Turma turma)
        {
            if (!Turmas.Contains(turma))
            {
                Turmas.Add(turma);
                turma.AddAluno(this);
            }
        }

        public string ExibirTurmas()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var turma in Turmas)
            {
                sb.AppendLine($"Turma {turma.Codigo}: {turma.Disciplina.Nome} ");
            }
            return sb.ToString();
        }

        public override string ToString()
        {
            return $"Nome: {Nome}, Matricula: {Matricula}";
        }
    }
}
