using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Testes.Mocks;
using Xunit.Abstractions;

namespace Alura.Estacionamento.Testes
{
    public class PatioTestes : IDisposable
    {
        public ITestOutputHelper Output { get; private set; }
        private Patio _estacionamento;

        public PatioTestes(ITestOutputHelper output)
        {
            Output = output;
            Output.WriteLine("foi");

            _estacionamento = new Patio()
            {
                Operador = new()
                {
                    Nome = "Operador Airton"
                }
            };
        }

        [Fact]
        public void TesteFaturamento()
        {
            // Arrange
            Veiculo veiculo = new()
            {
                Proprietario = "Airton",
                Tipo = TipoVeiculo.Automovel,
                Cor = "Branco",
                Modelo = "Fusca",
                Placa = "ABC-1234"
            };

            // Act
            _estacionamento.RegistrarEntradaVeiculo(veiculo);
            _estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            var faturamento = _estacionamento.TotalFaturado();

            // Assert
            Assert.Equal(2, faturamento);
        }

        [Theory]
        [InlineData("Airton 1", "ABC-1231", "Branco", "Cruze")]
        [InlineData("Airton 2", "ABC-1232", "Branco", "Cruze")]
        [InlineData("Airton 3", "ABC-1233", "Branco", "Cruze")]
        [InlineData("Airton 4", "ABC-1234", "Branco", "Cruze")]
        [InlineData("Airton 5", "ABC-1235", "Branco", "Cruze")]
        public void TesteFaturamentoComVariosVeiculos(string proprietario, string placa, string cor, string modelo)
        {
            // Arrange
            Veiculo veiculo = new()
            {
                Proprietario = proprietario,
                Tipo = TipoVeiculo.Automovel,
                Cor = cor,
                Modelo = modelo,
                Placa = placa
            };

            // Act
            _estacionamento.RegistrarEntradaVeiculo(veiculo);
            _estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            var faturamento = _estacionamento.TotalFaturado();

            // Assert
            Assert.Equal(2, faturamento);
        }

        [Theory]
        [ClassData(typeof(VeiculoMock))]
        public void TestaFaturamentoComMock(Veiculo veiculo)
        {
            // Arrange

            // Act
            _estacionamento.RegistrarEntradaVeiculo(veiculo);
            _estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            var faturamento = _estacionamento.TotalFaturado();

            // Assert
            Assert.Equal(2, faturamento);
        }

        [Theory]
        [InlineData("Airton 5", "ABC-1235", "Branco", "Cruze")]
        public void TestaLocalizaVeiculoNoPatio(string proprietario, string placa, string cor, string modelo)
        {
            // Arrange
            Veiculo veiculo = new()
            {
                Proprietario = proprietario,
                Tipo = TipoVeiculo.Automovel,
                Cor = cor,
                Modelo = modelo,
                Placa = placa
            };

            _estacionamento.RegistrarEntradaVeiculo(veiculo);

            // Act
            var consulta = _estacionamento.PesquisaVeiculo(veiculo.IdTicket);

            // Assert
            Assert.Equal(placa, consulta.Placa);
            Assert.IsType<Veiculo>(consulta);
        }

        [Fact]
        public void TesteAlteraVeiculo()
        {
            // Arrange
            Veiculo veiculo = new()
            {
                Proprietario = "Airton",
                Tipo = TipoVeiculo.Motocicleta,
                Cor = "Branco",
                Modelo = "Cruze",
                Placa = "ABC-1234"
            };

            _estacionamento.RegistrarEntradaVeiculo(veiculo);

            Veiculo veiculoAlterado = new()
            {
                Proprietario = "Airton",
                Tipo = TipoVeiculo.Automovel,
                Cor = "Branco",
                Modelo = "Cruze",
                Placa = "ABC-1234"
            };

            // Act
            Veiculo alterado = _estacionamento.AlterarDadosVeiculo(veiculoAlterado);

            // Assert
            Assert.Equal(alterado.Tipo, veiculoAlterado.Tipo);
        }

        [Fact]
        public void TestaGeracaoDoTicket()
        {
            // Arrange
            Veiculo veiculo = new()
            {
                Proprietario = "Airton",
                Tipo = TipoVeiculo.Motocicleta,
                Cor = "Branco",
                Modelo = "Cruze",
                Placa = "ABC-1234"
            };

            // Act
            _estacionamento.RegistrarEntradaVeiculo(veiculo);

            // Assert
            Assert.NotNull(veiculo.Ticket);
            Assert.NotEmpty(veiculo.Ticket);
        }

        public void Dispose()
        {
            Output.WriteLine("Morreu");
        }
    }
}
