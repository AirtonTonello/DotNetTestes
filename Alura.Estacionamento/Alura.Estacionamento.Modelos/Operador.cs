using System;

namespace Alura.Estacionamento.Alura.Estacionamento.Modelos
{
    public class Operador
    {
        private string _matricula;
        public string Matricula
        {
            get => _matricula;
            set => _matricula = value;
        }

        private string _nome;
        public string Nome
        {
            get => _nome;
            set => _nome = value;
        }

        public Operador()
        {
            this.Matricula = Guid.NewGuid().ToString()[0..8];
        }

        public override string ToString()
        {
            return $"Operador: {this.Nome}\n" +
                   $"Matricula: {this.Matricula}";
        }
    }
}
