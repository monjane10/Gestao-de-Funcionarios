using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Teste_2CS
{
    internal class FuncionarioDAO { 
    private static SqlConnection conn;
    private string url;

    public FuncionarioDAO()
    {
        try
        {
            url = @"Server=EDY-ADRIANO;Database=empresa;User Id=EDY-ADRIANO;Password=;Trusted_Connection=True;";
            conn = new SqlConnection(url);
            conn.Open();
        }
        catch (SqlException e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public ArrayList imprimirFuncionarios()
    {
        ArrayList funcionarios = new ArrayList();
        try
        {
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM funcionarios", conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int codigo = reader.GetInt32(0);
                        string nome = reader.GetString(1);
                        int diasTrabalhados = reader.GetInt32(2);
                        decimal salarioDiario = reader.GetDecimal(3);
                        funcionarios.Add(new Funcionario(codigo, nome, diasTrabalhados, salarioDiario));
                    }
                }
            }
        }
        catch (SqlException e)
        {
            Console.WriteLine(e.Message);
        }
        return funcionarios;
    }

    public bool insert(Funcionario funcionario)
    {
        try
        {
            using (SqlConnection con = new SqlConnection(url))
            {
                //con.Open();
                string query = "INSERT INTO funcionarios(nome, diasTrabalhados, salario_diario) VALUES (@nome, @diasTrabalhados, @salarioDiario)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nome", funcionario.getNome());
                    cmd.Parameters.AddWithValue("@diasTrabalhados", funcionario.getDiasTrabalhados());
                    cmd.Parameters.AddWithValue("@salarioDiario", funcionario.getSalarioDiario());
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
        }
        catch (SqlException e)
        {
            Console.WriteLine(e.Message);
            return false;
        }
    }

    public bool update(Funcionario funcionario)
    {
        try
        {
            //conn.Open();
            string query = "UPDATE funcionarios SET nome = @nome, diasTrabalhados = @diasTrabalhados, salario_diario = @salarioDiario WHERE codigo = @codigo";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@nome", funcionario.getNome());
                cmd.Parameters.AddWithValue("@diasTrabalhados", funcionario.getDiasTrabalhados());
                cmd.Parameters.AddWithValue("@salarioDiario", funcionario.getSalarioDiario());
                cmd.Parameters.AddWithValue("@codigo", funcionario.getCodigo());
                cmd.ExecuteNonQuery();
                return true;
            }

        }
        catch (SqlException e)
        {
            Console.WriteLine(e.Message);
            return false;
        }
    }

    public void apagar(Funcionario funcionario)
    {
        try
        {
            using (SqlConnection con = new SqlConnection(url))
            {
                con.Open();
                string query = "DELETE funcionarios WHERE codigo = @codigo";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@codigo", funcionario.getCodigo());
                    cmd.ExecuteNonQuery();
                }
            }
        }
        catch (SqlException e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
}
