using System;

namespace Questao1
{
    public class ContaBancaria
    { 
        private const double TAXA = 3.50;
        private int numero;
        private string titular;
        private double saldo;

        public ContaBancaria(int numero, string titular)
        {
            this.numero = numero;
            this.titular = titular;
            this.saldo = 0; 
        }

        public ContaBancaria(int numero, string titular, double depositoInicial)
        {
            this.numero = numero;
            this.titular = titular;
            this.saldo = depositoInicial; 
        }

        public int Numero
        {
            get { return numero; } 
        }

        public string Titular
        {
            get { return titular; }
            set { titular = value; }
        }

        public double Saldo
        {
            get { return saldo; }
        }
         
        public void Deposito(double valor)
        {
            saldo += valor;
        }
         
        public void Saque(double valor)
        { 
                saldo -= (valor + TAXA); 
        }

        public void AlterarNome(string novoNome)
        {
            titular = novoNome;
        }

    }
}