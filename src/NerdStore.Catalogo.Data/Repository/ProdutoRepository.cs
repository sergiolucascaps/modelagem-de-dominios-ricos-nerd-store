using Microsoft.EntityFrameworkCore;
using NerdStore.Catalogo.Domain;
using NerdStore.Core.Data;

namespace NerdStore.Catalogo.Data.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly CatalogoContext _catalogoContext;

        public ProdutoRepository(CatalogoContext catalogoContext)
        {
            _catalogoContext = catalogoContext;
        }

        public IUnitOfWork UnitOfWork => _catalogoContext;

        public void Adicionar(Produto produto)
            => _catalogoContext.Produtos.Add(produto);

        public void Adicionar(Categoria categoria)
            => _catalogoContext.Categorias.Add(categoria);

        public void Atualizar(Produto produto)
            => _catalogoContext.Produtos.Update(produto);

        public void Atualizar(Categoria categoria)
            => _catalogoContext.Categorias.Add(categoria);

        public async Task<IEnumerable<Categoria>> ObterCategorias()
            => await _catalogoContext.Categorias.AsNoTracking().ToListAsync();

        public async Task<IEnumerable<Produto>> ObterPorCategoria(int codigo)
            => await _catalogoContext.Produtos.AsNoTracking().Include(p => p.Categoria).Where(p => p.Categoria.Codigo == codigo).ToListAsync();

        public async Task<Produto> ObterPorId(Guid id)
            => await _catalogoContext.Produtos.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);

        public async Task<IEnumerable<Produto>> ObterTodos()
            => await _catalogoContext.Produtos.AsNoTracking().ToListAsync();

        public void Dispose()
        {
            _catalogoContext?.Dispose();
        }
    }
}
