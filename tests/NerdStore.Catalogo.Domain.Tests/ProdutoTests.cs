using NerdStore.Core.DomainObjects;
using System;
using System.Threading.Tasks;
using Xunit;

namespace NerdStore.Catalogo.Domain.Tests
{
    public class ProdutoTests
    {
        [Fact]
        public async Task Produto_Validar_NomeDeveRetornarExceptions()
        {
            var ex = await Assert.ThrowsAsync<DomainException>(
               () => Task.Run(() => new Produto(string.Empty, "Descricao", false, 100, Guid.NewGuid(), DateTime.Now, "Imagem", new Dimensoes(1, 1, 1)))
            );

            Assert.Equal("O campo Nome do produto não pode estar vazio", ex.Message);
        }

        [Fact]
        public async Task Produto_Validar_DescricaoDeveRetornarExceptions()
        {
            var ex = await Assert.ThrowsAsync<DomainException>(
               () => Task.Run(() => new Produto("Nome", string.Empty, false, 100, Guid.NewGuid(), DateTime.Now, "Imagem", new Dimensoes(1, 1, 1)))
            );

            Assert.Equal("O campo Descricao do produto não pode estar vazio", ex.Message);
        }

        [Fact]
        public async Task Produto_Validar_ValorDeveRetornarException()
        {
            var ex = await Assert.ThrowsAsync<DomainException>(
               () => Task.Run(() => new Produto("Nome", "Descricao", false, 0, Guid.NewGuid(), DateTime.Now, "Imagem", new Dimensoes(1, 1, 1)))
            );

            Assert.Equal("O campo Valor do produto não pode ser menor ou igual a 0", ex.Message);
        }

        [Fact]
        public async Task Produto_Validar_CategoriaIdDeveRetornarException()
        {
            var ex = await Assert.ThrowsAsync<DomainException>(
               () => Task.Run(() => new Produto("Nome", "Descricao", false, 100, Guid.Empty, DateTime.Now, "Imagem", new Dimensoes(1, 1, 1)))
            );

            Assert.Equal("O campo CategoriaId do produto não pode estar vazio", ex.Message);
        }

        [Fact]
        public async Task Produto_Validar_ImagemDeveRetornarException()
        {
            var ex = await Assert.ThrowsAsync<DomainException>(
               () => Task.Run(() => new Produto("Nome", "Descricao", false, 100, Guid.NewGuid(), DateTime.Now, string.Empty, new Dimensoes(1, 1, 1)))
            );

            Assert.Equal("O campo Imagem do produto não pode estar vazio", ex.Message);
        }

        [Fact]
        public async Task Produto_Dimensoes_Validar_AlturaDeveRetornarException()
        {
            var ex = await Assert.ThrowsAsync<DomainException>(
               () => Task.Run(() => new Produto("Nome", "Descricao", false, 100, Guid.NewGuid(), DateTime.Now, "Imagem", new Dimensoes(0, 1, 1)))
            );

            Assert.Equal("O campo Altura não pode ser menor ou igual a 0", ex.Message);
        }

        [Fact]
        public async Task Produto_Dimensoes_Validar_LarguraDeveRetornarException()
        {
            var ex = await Assert.ThrowsAsync<DomainException>(
               () => Task.Run(() => new Produto("Nome", "Descricao", false, 100, Guid.NewGuid(), DateTime.Now, "Imagem", new Dimensoes(1, 0, 1)))
            );

            Assert.Equal("O campo Largura não pode ser menor ou igual a 0", ex.Message);
        }

        [Fact]
        public async Task Produto_Dimensoes_Validar_ProfundidadeDeveRetornarException()
        {
            var ex = await Assert.ThrowsAsync<DomainException>(
               () => Task.Run(() => new Produto("Nome", "Descricao", false, 100, Guid.NewGuid(), DateTime.Now, "Imagem", new Dimensoes(1, 1, 0)))
            );

            Assert.Equal("O campo Profundidade não pode ser menor ou igual a 0", ex.Message);
        }
    }
}