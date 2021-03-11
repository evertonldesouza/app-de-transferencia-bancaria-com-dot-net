using DIO.AppBank.Model.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace DIO.AppBank.Model
{
    public class Conta
    {
        private TipoConta TipoConta { get; set; }
        private double Saldo { get; set; }
        private double Credito { get; set; }
        private string Nome { get; set; }

        public Conta(TipoConta tipoConta, double saldo, double credito, string nome)
        {
            this.TipoConta = tipoConta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome;
        }

        public bool Sacar(double valor)
        {
            //validação de saldo insuficiente
            if (this.Saldo - valor < (this.Credito * -1))
            {
                Console.WriteLine("Saldo insuficiente!");
                return false;
            }
            //retira o valor pretendido
            this.Saldo -= valor;
            Console.WriteLine($"O saldo atual da conta de {this.Nome} é {this.Saldo}");
            return true;
        }

        public void Depositar(double valor)
        {
            this.Saldo += valor;
            Console.WriteLine($"O saldo atual da conta de {this.Nome} é {this.Saldo}");
        }

        public void Transferir(double valor, Conta contaDestino)
        {
            if (this.Sacar(valor))
            {
                contaDestino.Depositar(valor);
            }
        }

        public override string ToString()
        {
            string str = "";
            str += "Tipo Conta: " + this.TipoConta + " | ";
            str += "Nome: " + this.Nome + " | ";
            str += "Saldo: " + this.Saldo + " | ";
            str += "Crédito: " + this.Credito;
            return str;
        }
    }
}
