using System.Collections.Generic;
using MySqlConnector;
using System;
namespace rastreiebrasil.Models
{
    public class FormularioRepository
    {
        private const string DadosConexao = "DATABASE=RastreieBrasil;DATASOURCE=localhost;USER=root";
        public void TestarConexao()
        {
            //informa a credencial de acesso
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);

            //abre conexao
            Conexao.Open();

            Console.WriteLine("Banco de dados funcionando!");

            //fecha conexao    
            Conexao.Close();
        }
        public void Inserir(Formulario user)
        {
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();

            //query sql (insert)
            String QuerySql = "insert into Cotacao (nome,placa,telefone) values (@nome,@placa,@telefone)";


            MySqlCommand Comando = new MySqlCommand(QuerySql, Conexao);

            Comando.Parameters.AddWithValue("@nome", user.nome);
            Comando.Parameters.AddWithValue("@placa", user.placa);
            Comando.Parameters.AddWithValue("@telefone", user.telefone);

            Comando.ExecuteNonQuery();

            Conexao.Close();
        }
        public List<Formulario> Listar()
        {
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();

            //query sql (select)
            String QuerySql = "select * from Cotacao";

            MySqlCommand Comando = new MySqlCommand(QuerySql, Conexao);

            //executa no banco de dados e retorna uma lista de dados
            MySqlDataReader Reader = Comando.ExecuteReader();

            //lista de usuario
            List<Formulario> Lista = new List<Formulario>();

            //percorre todos os registros retornados no banco de dados(objeto Reader)
            while (Reader.Read())
            {

                Formulario userEncontrado = new Formulario();

                userEncontrado.Id = Reader.GetInt32("Id");

                if (!Reader.IsDBNull(Reader.GetOrdinal("nome")))
                    userEncontrado.nome = Reader.GetString("nome");

                if (!Reader.IsDBNull(Reader.GetOrdinal("placa")))
                    userEncontrado.placa = Reader.GetString("placa");

                if (!Reader.IsDBNull(Reader.GetOrdinal("telefone")))
                    userEncontrado.telefone = Reader.GetString("telefone");

                //add na lista de usuarios
                Lista.Add(userEncontrado);

            }
                Conexao.Close();

                return Lista;
        }
    }
}