using Microsoft.Data.SqlClient;
using ScreenSound.Modelos;

namespace ScreenSound.Banco
{
    internal class ArtistaDAL
    {
        private readonly ScreenSoundContext _contexto;

        public ArtistaDAL(ScreenSoundContext contexto)
        {
            _contexto = contexto;
        }

        public IEnumerable<Artista> Listar()
        {
            return _contexto.Artistas.ToList();
        }

        public void Adicionar(Artista artista)
        {
            _contexto.Artistas.Add(artista);
            _contexto.SaveChanges();
        }

        public void Atualizar(Artista artista)
        {
            _contexto.Artistas.Update(artista);
            _contexto.SaveChanges();
        }

        public void Excluir(int id)
        {
            var artista = _contexto.Artistas.Find(id);

            if (artista != null)
            {
                _contexto.Artistas.Remove(artista);
                _contexto.SaveChanges();
            }
        }
    }
}