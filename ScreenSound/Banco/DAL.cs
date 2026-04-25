using ScreenSound.Modelos;

namespace ScreenSound.Banco
{
    internal abstract class DAL<T> where T : class
    {
        protected readonly ScreenSoundContext _contexto;

        protected DAL(ScreenSoundContext contexto)
        {
            _contexto = contexto;
        }

        public IEnumerable<T> Listar()
        {
            return _contexto.Set<T>().ToList();
        }

        public void Adicionar(T entidade)
        {
            _contexto.Set<T>().Add(entidade);
            _contexto.SaveChanges();
        }

        public void Atualizar(T entidade)
        {
            _contexto.Set<T>().Update(entidade);
            _contexto.SaveChanges();
        }

        public void Excluir(T entidade)
        {
            _contexto.Set<T>().Remove(entidade);
            _contexto.SaveChanges();
        }

        public T? RecuperarPor(Func<T, bool> condicao)
        {
            return _contexto.Set<T>().FirstOrDefault(condicao);
        }
    }
}
