using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using Xunit.Abstractions;

namespace Alura.Estacionamento.Testes
{
    /// <summary>
    ///     AAA
    ///     1 -> Preparação do ambiente
    ///     2 -> Ação do metodo
    ///     3 -> Validação do resultado
    /// </summary>
    public class VeiculoTestes : IDisposable
    {
        // Setup
        public ITestOutputHelper Output { get; private set; }

        private readonly Veiculo _veiculo;

        public VeiculoTestes(ITestOutputHelper output)
        {
            Output = output;
            Output.WriteLine("foi");

            _veiculo = new()
            {
                Proprietario = "Airton",
                Tipo = TipoVeiculo.Automovel,
                Placa = "ABC-1234",
                Cor = "Branco",
                Modelo = "Ferrari"
            };
        }

        [Fact(DisplayName = "Teste de Acelerar")]
        [Trait("Veiculo", "Acelerar")]
        public void TesteAcelerar()
        {
            // Arrange

            // Act
            _veiculo.Acelerar(10);

            // Assert
            Assert.Equal(100, _veiculo.VelocidadeAtual);
        }

        [Fact(DisplayName = "Teste de Frear")]
        [Trait("Veiculo", "Frear")]
        public void TesteFrear()
        {
            // Arrange

            // Act
            _veiculo.Frear(10);

            // Assert
            Assert.Equal(-150, _veiculo.VelocidadeAtual);
        }

        [Fact]
        public void TesteTipoVeiculo()
        {
            // Arrange
            Veiculo veiculo = new();

            // Act

            // Assert
            Assert.Equal(TipoVeiculo.Automovel, veiculo.Tipo);
        }

        [Fact(Skip = "Ainda não implementado")]
        public void TesteNomeProprietario()
        {

        }

        [Fact]
        public void TesteDadosVeiculo()
        {
            // Arrange

            // Act
            var dados = _veiculo.ToString();

            // Assert
            Assert.Contains("Tipo de Veiculo: Automovel", dados);
        }

        [Fact]
        public void TestaValidacaoDoNomeProprietario()
        {
            // Arrange
            string proprietario = "ab";

            // Assert
            Assert.Throws<FormatException>(() =>
            {
                // Act
                Veiculo veiculo = new(proprietario);
            });
        }

        [Fact]
        public void TestaValidacaoDaQuantidadeDeCaracteresPlaca()
        {
            string placa = "ABC1234";

            var exception = Assert.Throws<FormatException>(() =>
            {
                Veiculo veiculo = new()
                {
                    Placa = placa
                };
            });

            Assert.Equal("A placa deve possuir 8 caracteres", exception.Message);
        }

        [Fact]
        public void TestaValidacaoDosPrimeirosCaracteresDaPlaca()
        {
            string placa = "123-ABCD";

            var exception = Assert.Throws<FormatException>(() =>
            {
                Veiculo veiculo = new()
                {
                    Placa = placa
                };
            });

            Assert.Equal("Os 3 primeiros caracteres devem ser letras!", exception.Message);
        }

        [Fact]
        public void TestaValidacaoDoHifenNaPlaca()
        {
            string placa = "AABC1234";

            var exception = Assert.Throws<FormatException>(() =>
            {
                Veiculo veiculo = new()
                {
                    Placa = placa
                };
            });

            Assert.Equal("O 4° caractere deve ser um hífen", exception.Message);
        }

        [Fact]
        public void TestaValidacaoDosUltimosCaracteresDaPlaca()
        {
            string placa = "ABC-ABCD";

            var exception = Assert.Throws<FormatException>(() =>
            {
                Veiculo veiculo = new()
                {
                    Placa = placa
                };
            });

            Assert.Equal("Do 5º ao 8º caractere deve-se ter um número!", exception.Message);
        }

        public void Dispose()
        {
            Output.WriteLine("Morreu");
        }
    }
}