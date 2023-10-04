using Alura.Estacionamento.Modelos;
using System.Collections;

namespace Alura.Estacionamento.Testes.Mocks
{
    /// <summary>
    ///     Mock de veiculo para testar metodos
    /// </summary>
    public class VeiculoMock : Veiculo, IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                new Veiculo()
                {
                    Proprietario = "Airton 1",
                    Placa = "ABC-1231",
                    Cor = "Branco",
                    Modelo = "Cruze",
                },
            };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
