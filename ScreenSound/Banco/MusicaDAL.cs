using Microsoft.EntityFrameworkCore;
using ScreenSound.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound.Banco
{
    internal class MusicaDAL
    {
        private readonly ScreenSoundContext _contexto;

        public MusicaDAL(ScreenSoundContext contexto)
        {
            _contexto = contexto;
        }

        public IEnumerable<Musica> Listar()
        {
            return _contexto.Musicas.ToList();
        }

        public void Adicionar(Musica musica)
        {
            _contexto.Musicas.Add(musica);
            _contexto.SaveChanges();
        }

        public void Atualizar(Musica musica)
        {
            _contexto.Musicas.Update(musica);
            _contexto.SaveChanges();
        }

        public void Excluir(int id)
        {
            var musica = _contexto.Musicas.Find(id);
            if (musica != null)
            {
                _contexto.Musicas.Remove(musica);
                _contexto.SaveChanges();
            }
        }

        public Musica? RecuperarPeloNome(string nome)
        {
            return _contexto.Musicas.FirstOrDefault(a => a.Nome.Equals(nome));
        }
    }
}
