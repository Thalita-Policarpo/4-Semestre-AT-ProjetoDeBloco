using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4ºSemestre_AT_ProjetoDeBloco
{
    internal class Disciplina
    {
        public string Nome { get; set; }
        public string Codigo { get; set; }
        public Professor Professor { get; set; }
        public List<Turma> Turmas { get; set; } = new List<Turma>();

        public void AddTurma(Turma turma)
        {
            if (!Turmas.Contains(turma))
            {
                Turmas.Add(turma);
                turma.AddDisciplina(this);
            }
        }

        public string ExibirTurmas()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var turma in Turmas)
            {
                sb.AppendLine($"Professor: {Professor.Nome}");
            }
            return sb.ToString();
        }

        public override string ToString()
        {
            return $"Nome: {Nome}, Código: {Codigo}, Professor: {Professor.Nome}";
        }
    }
}
