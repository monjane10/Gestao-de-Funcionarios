using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Teste_2CS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            txtNome.Focus();
            imprimirFunc();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtCodigo.Text = lstvFuncionario.SelectedItems[0].SubItems[0].Text;
                txtNome.Text = lstvFuncionario.SelectedItems[0].SubItems[1].Text;
                txtDiasTrab.Text = lstvFuncionario.SelectedItems[0].SubItems[2].Text;
                txtSalarioDia.Text = lstvFuncionario.SelectedItems[0].SubItems[3].Text;
            }
            catch (Exception ex)
            {
                
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            int codigo = 0;
            string nome = "";
            int diasTrab = 0;
            decimal salDiario = 0.0M;
            FuncionarioDAO fd = new FuncionarioDAO();
            if (lstvFuncionario.SelectedIndices.Count > 0)
            {
                codigo = int.Parse(lstvFuncionario.SelectedItems[0].SubItems[0].Text);
                nome = lstvFuncionario.SelectedItems[0].SubItems[1].Text;
                diasTrab = int.Parse(lstvFuncionario.SelectedItems[0].SubItems[2].Text);
                salDiario = decimal.Parse(lstvFuncionario.SelectedItems[0].SubItems[3].Text);
                Funcionario funcionario = new Funcionario(codigo, nome, diasTrab, salDiario);
                fd.apagar(funcionario);
            }
            lstvFuncionario.Items.Clear();
            limparCampos();
            imprimirFunc();
        }

        public void imprimirFunc()
        {
            ArrayList funcionarios = new ArrayList();
            FuncionarioDAO func = new FuncionarioDAO();
            funcionarios = func.imprimirFuncionarios();
            ListViewItem lstv;
            foreach (Funcionario funcionario in funcionarios)
            {
                string[] dados = new string[] { funcionario.getCodigo() + "", funcionario.getNome(), funcionario.getDiasTrabalhados() + "", funcionario.getSalarioDiario() + "", funcionario.salarioMensal() + "" };
                lstv = new ListViewItem(dados);
                lstvFuncionario.Items.Add(lstv);
            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            lstvFuncionario.Items.Clear();
            FuncionarioDAO conn = new FuncionarioDAO();
            string nome = txtNome.Text;
            int diasTrabalhados = int.Parse(txtDiasTrab.Text);
            decimal salarioDiario = decimal.Parse(txtSalarioDia.Text);
            Funcionario fun = new Funcionario(-1, nome, diasTrabalhados, salarioDiario);

            if (conn.insert(fun))
                MessageBox.Show("Funcionário Gravado.");
            else
                MessageBox.Show("Erro ao gravar.");
            limparCampos();
            imprimirFunc();
        }

        public void limparCampos()
        { 
            txtCodigo.Text = string.Empty;
            txtDiasTrab.Text = string.Empty;
            txtNome.Text = string.Empty;
            txtSalarioDia.Text = string.Empty;
        }


        private void btnEditar_Click(object sender, EventArgs e)
        {
            string nome = "";
            int codigo = 0;
            decimal salDiario = 0.0M;
            int diasTrab = 0;

            if (lstvFuncionario.SelectedIndices.Count > 0)
            {
                FuncionarioDAO conn = new FuncionarioDAO();
                codigo = int.Parse(txtCodigo.Text);
                nome = txtNome.Text;
                diasTrab = int.Parse(txtDiasTrab.Text);
                salDiario = decimal.Parse(txtSalarioDia.Text);
                Funcionario fun = new Funcionario(codigo, nome, diasTrab, salDiario);

                if (conn.update(fun))
                    MessageBox.Show("Funcionário Editado.");
                else
                    MessageBox.Show("Erro ao editar.");
                lstvFuncionario.Items.Clear();
                limparCampos();
                imprimirFunc();
            }
        }

        private void btnGravar_Click_1(object sender, EventArgs e)
        {
            lstvFuncionario.Items.Clear();
            FuncionarioDAO conn = new FuncionarioDAO();
            string nome = txtNome.Text;
            int diasTrabalhados = int.Parse(txtDiasTrab.Text);
            decimal salarioDiario = decimal.Parse(txtSalarioDia.Text);
            Funcionario fun = new Funcionario(-1, nome, diasTrabalhados, salarioDiario);

            if (conn.insert(fun))
                MessageBox.Show("Funcionário Gravado.");
            else
                MessageBox.Show("Erro ao gravar.");
            limparCampos();
            imprimirFunc();
        }
    }
}
