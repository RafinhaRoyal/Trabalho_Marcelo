using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace TRABALHO_DO_MARCELO
{
   public class Banco
    {
        private string connectionString = "Host=localhost;Username=postgres;Password=1234;Database=concessionaria";

        private NpgsqlConnection connection;
        public Banco()
        {
            connection = new NpgsqlConnection(connectionString);
        }

        public void conectar()
        {
            try
            {
                connection.Open();
                Console.WriteLine("Conexão feita");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro " + ex.Message);
            }
        }
        public void Saida()
        {
            try
            {
                connection.Close();
                Console.WriteLine("Saida do banco");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao Sair " + ex.Message);
            }
        }
        public void inserir(VEICULO veiculo) //1 CRUD
        {
            string query = "INSERT INTO veiculo(marca, modelo) VALUES (@marca, @modelo)";
            using (var command = new NpgsqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("marca", veiculo.marca);
                command.Parameters.AddWithValue("modelo", veiculo.modelo);
                command.ExecuteNonQuery();
            }
            Console.WriteLine("Veiculo incluido");
        }

        public void ler() //2 crud
        {
            string query = "SELECT * FROM veiculo";
            using (var command = new NpgsqlCommand(query, connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"ID: {reader["id"]}, Marca: {reader["marca"]}, Modelo: {reader["modelo"]}");
                    }
                }
            }
        }

        public void excluir(int id) //3 crud
        {
            string query = "DELETE FROM veiculo WHERE id = @id";
            using (var command = new NpgsqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("id", id);
                command.ExecuteNonQuery();
            }
            Console.WriteLine("veiculo excluido sucesso");
        }
        public void mudar(VEICULO veiculo, int id) //4 crud
        {
            string query = "UPDATE veiculo SET marca = @marca, modelo = @modelo WHERE id = @id";
            using (var command = new NpgsqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("marca", veiculo.marca);
                command.Parameters.AddWithValue("modelo", veiculo.modelo);
                command.Parameters.AddWithValue("id", id);
                command.ExecuteNonQuery();
            }
            Console.WriteLine("Veiculo mudado com sucesso");
        }
    }
}
