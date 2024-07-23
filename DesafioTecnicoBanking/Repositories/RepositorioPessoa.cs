using Dapper;
using DesafioTecnicoBanking.Modelos;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioTecnicoBanking.Repositories
{
    public class RepositorioPessoa
    {
        private string _connectionString;
        public RepositorioPessoa()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public IEnumerable<Pessoa> ObterPessoas()
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                var pessoas = connection.Query<Pessoa>("SELECT * FROM pessoa");
                return pessoas;
            }
        }


        public void AdicionarPessoa(Pessoa pessoa)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                var sql = "INSERT INTO Pessoa (Nome, CPF) VALUES (@Nome, @CPF)";
                connection.Execute(sql, pessoa);
            }
        }

        public void AtualizarPessoa(Pessoa pessoa)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                var sql = "UPDATE Pessoa SET Nome = @Nome WHERE CPF = @CPF";
                connection.Execute(sql, pessoa);
            }
        }
    }
}
