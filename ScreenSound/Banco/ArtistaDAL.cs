using Microsoft.Data.SqlClient;
using ScreenSound.Modelos;

namespace ScreenSound.Banco
{
    internal class ArtistaDAL
    {
        public IEnumerable<Artista> Listar()
        {
            var lista = new List<Artista>();

            using var conexao = new Connection().ObterConexao();

            conexao.Open();

            string query = "SELECT Id, Nome, FotoPerfil, Bio FROM Artistas WITH(NOLOCK)";

            SqlCommand comando = new SqlCommand(query, conexao);

            using SqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["ID"]);
                string nome = Convert.ToString(reader["Nome"]);
                string bio = Convert.ToString(reader["Bio"]);
                string fotoPerfil = Convert.ToString(reader["FotoPerfil"]);

                Artista artista = new(nome, bio, fotoPerfil) { Id = id };

                lista.Add(artista);
            }

            return lista;
        }

        public void Adicionar(Artista artista)
        {
            using var conexao = new Connection().ObterConexao();

            conexao.Open();

            string query = "INSERT INTO Artistas (Nome, Bio, FotoPerfil) VALUES (@Nome, @Bio, @FotoPerfil)";

            SqlCommand comando = new SqlCommand(query, conexao);

            comando.Parameters.AddWithValue("@Nome", artista.Nome);
            comando.Parameters.AddWithValue("@Bio", artista.Bio);
            comando.Parameters.AddWithValue("@FotoPerfil", artista.FotoPerfil);

            int linhasAfetadas = comando.ExecuteNonQuery();

            if (linhasAfetadas > 0)
            {
                Console.WriteLine("Artista adicionado com sucesso!");
            }
            else
            {
                Console.WriteLine("Falha ao adicionar o artista.");
            }
        }

        public void Atualizar(Artista artista)
        {
            using var conexao = new Connection().ObterConexao();

            conexao.Open();

            string query = "UPDATE Artistas SET Nome = @Nome, Bio = @Bio, FotoPerfil = @FotoPerfil WHERE Id = @Id";

            SqlCommand comando = new SqlCommand(query, conexao);

            comando.Parameters.AddWithValue("@Nome", artista.Nome);
            comando.Parameters.AddWithValue("@Bio", artista.Bio);
            comando.Parameters.AddWithValue("@FotoPerfil", artista.FotoPerfil);
            comando.Parameters.AddWithValue("@Id", artista.Id);

            int linhasAfetadas = comando.ExecuteNonQuery();

            if (linhasAfetadas > 0)
            {
                Console.WriteLine("Artista atualizado com sucesso!");
            }
            else
            {
                Console.WriteLine("Falha ao atualizar o artista.");
            }
        }

        public void Excluir(int id)
        {
            using var conexao = new Connection().ObterConexao();

            conexao.Open();

            string query = "DELETE FROM Artistas WHERE Id = @Id";

            SqlCommand comando = new SqlCommand(query, conexao);

            comando.Parameters.AddWithValue("@Id", id);

            int linhasAfetadas = comando.ExecuteNonQuery();

            if (linhasAfetadas > 0)
            {
                Console.WriteLine("Artista excluído com sucesso!");
            }
            else
            {
                Console.WriteLine("Falha ao excluir o artista.");
            }
        }
    }
}