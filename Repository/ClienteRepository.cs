using Domain.Models;
using Domain.Repository;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly IConfiguration _configuration;

        public ClienteRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        private string GetConnection()
        {
            var connection = _configuration.GetSection("RepositoryConfiguration")
                .GetSection("SqlConnectionString").Value;
            return connection;
        }

        public IEnumerable<Cliente> BuscarCliente()
        {
            var connectionString = this.GetConnection();
            using IDbConnection connection = new SqlConnection(connectionString);

            try
            {
                var query = "select * from produto;";
                var lista = connection.Query<Cliente>(query);
                return lista;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public Cliente CadastrarCliente(Cliente cliente)
        {
            var connectionString = this.GetConnection();
            using IDbConnection connection = new SqlConnection(connectionString);

            var query = @"insert into clientes(nome, email, telefone)
                        values(@nome, @email, @telefone);
                        SELECT CAST(SCOPE_IDENTITY() as int );";

            var parametros = new DynamicParameters();
            parametros.Add("nome", cliente.Nome);
            parametros.Add("email", cliente.Email);
            parametros.Add("telefone", cliente.Telefone);

            cliente.Id = connection.QuerySingle<int>(query, parametros);

            return cliente;
        }

        public Cliente EditarCliente(Cliente cliente)
        {
            var connectionString = this.GetConnection();
            using IDbConnection connection = new SqlConnection(connectionString);

            var query = @"UPDATE clientes SET nome= @nome, email= @email, telefone= @telefone
             WHERE id=@id;";

            var parametros = new DynamicParameters();
            parametros.Add("nome", cliente.Nome);
            parametros.Add("email", cliente.Email);
            parametros.Add("telefone", cliente.Telefone);
            parametros.Add("id", cliente.Id);

            var clienteEditado = connection.ExecuteScalar<Cliente>(query, parametros);


            return clienteEditado;
        }

        public void DeletarCliente(int id)
        {
            var connectionString = this.GetConnection();
            using IDbConnection connection = new SqlConnection(connectionString);

            var query = $@"Delete from clientes 
            WHERE id = {id};";

            var deletar = connection.ExecuteScalar<int>(query);


        }
    }
}
