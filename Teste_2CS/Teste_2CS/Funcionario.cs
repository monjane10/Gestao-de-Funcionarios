using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste_2CS
{
    internal class Funcionario
    {
        private int codigo;
        private string nome;
        private int diasTrabalhados;
        private decimal salarioDiario;

        public Funcionario(int codigo, string nome, int diasTrabalhados, decimal salarioDiario)
        {
            this.codigo = codigo;
            this.nome = nome;
            this.diasTrabalhados = diasTrabalhados;
            this.salarioDiario = salarioDiario;
        }

        public decimal getSalarioDiario()
        {
            return salarioDiario;
        }

        public int getCodigo()
        {
            return codigo;
        }

        public string getNome()
        {
            return nome;
        }

        public int getDiasTrabalhados()
        {
            return diasTrabalhados;
        }

        public decimal salarioMensal()
        {
            return (decimal)getSalarioDiario() * getDiasTrabalhados();
        }
    }
}
