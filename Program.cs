using System;
using System.Collections.Generic;

namespace banco
{

    
    class Conta
    {
        private int saldo;
        private readonly  Dictionary<DateTime, int> historico;

        // Correção: Remova o tipo de retorno do construtor
        public Conta( int saldo) 
        {
            this.saldo = saldo;
            this.historico = new Dictionary<DateTime, int>();
        }

        public void Deposita(int valor)
        {
            // Correção: A lógica estava invertida
            if (valor <= 0)
            {
                throw new ArgumentException("Valor inválido para depósito.");
            }
            
            {
                saldo += valor;
                DateTime data = DateTime.Now;
                addHistorico(data, valor);
            }
        }


        public void Sacar(int valor)
        {

            if (saldo < valor)
            {

               throw new InvalidOperationException("Saldo insuficiente.");

            }
            
            {
                saldo -= valor;
                DateTime data = DateTime.Now;
                addHistorico(data, -valor);
            }


        }

        // Método adicionado para obter o saldo
        public int ObterSaldo()
        {
            return saldo;
        }

        private  void addHistorico(DateTime data, int valor)
        {
            historico.Add(data, valor);
        }

        public void Extrato(){
            foreach(var item in historico){
                Console.WriteLine(item);
            }
        }
    }

    class Cliente : Conta
    {
        private  readonly  string nome;
        private readonly  string cpf;
        private readonly  string dataNascimento;

        public Cliente(string nome, string cpf, string dataNascimento, int saldo) : base(saldo)
        {
            this.nome = nome;
            this.cpf = cpf;
            this.dataNascimento = dataNascimento;
        }

        public string Nome => nome;

        public string Cpf => cpf; 

        public string DataNascimento => dataNascimento; 
    }

    class Program
    {
        static void Main(string[] args)
        {
        Cliente conta = new Cliente("henrique", "00000000", "04042002", 0);

        conta.Deposita(12);
        conta.Deposita(150);
        conta.Sacar(120);

        conta.Extrato();

             
    }
}}
