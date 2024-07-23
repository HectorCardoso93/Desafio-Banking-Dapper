using Dapper;
using Dapper.Contrib.Extensions;
using DesafioTecnicoBanking.Modelos;
using Microsoft.VisualBasic.ApplicationServices;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioTecnicoBanking.Repositories
{
    public class RepositorioConta
    {
        private string _connectionString;

        public RepositorioConta()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public IEnumerable<Conta> ObterContas()
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                var contas = connection.Query<Conta>("SELECT * FROM conta");
                return contas;
            }
        }

        public void AdicionarConta(Conta conta)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                var sql = "INSERT INTO Conta (NumeroConta, Agencia, CPFTitular, Saldo, ChequeEspecial, IsContaCorrente) VALUES (@NumeroConta, @Agencia, @CPFTitular, @Saldo, @ChequeEspecial, @IsContaCorrente)";
                var parameters = new
                {
                    NumeroConta = conta.NumeroConta,
                    Agencia = conta.Agencia,
                    CPFTitular = conta.Titular.Cpf,
                    Saldo = conta.Saldo,
                    ChequeEspecial = conta.ChequeEspecial,
                    IsContaCorrente = conta.IsContaCorrente
                };
                connection.Execute(sql, parameters);
            }
        }

        public void AtualizarSaldoConta( Conta conta)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                var sql = $"UPDATE Conta SET Saldo = @Saldo WHERE NumeroConta = @NumeroConta";
                connection.Execute(sql, conta);
            }
        }
        public void AtualizarData(Conta conta)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                var sql = $"UPDATE Conta SET DataUltimaOperacao = @DataUltimaOperacao WHERE NumeroConta = @NumeroConta";
                connection.Execute(sql, conta);
            }
        }

        public void DeletarConta(int numeroConta)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                var sql = "DELETE FROM conta WHERE NumeroConta = @NumeroConta";
                connection.Execute(sql, new { NumeroConta = numeroConta });
            }
        }
        public int ObterProximoNumeroConta()
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                var sql = "SELECT MAX(NumeroConta) FROM Conta";
                var ultimoNumeroConta = connection.QuerySingleOrDefault<int?>(sql);
                var proximoNumeroConta = (ultimoNumeroConta ?? 0) + 1;
                return proximoNumeroConta;
            }
        }
        public Conta ObterConta(int numeroConta)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                var sql = "SELECT * FROM conta WHERE NumeroConta = @NumeroConta";
                return connection.QueryFirstOrDefault<Conta>(sql, new {NumeroConta = numeroConta});
            }
        }
    }
}
