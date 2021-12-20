using System;
using System.Linq;
using System.Collections.Generic;

namespace VendasWebMVC.Models
{
    public class Vendedor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public double SalarioBase { get; set; }
        public Departamento Departamento { get; set; }
        public ICollection<RegistroVendas> Vendas { get; set; } = new List<RegistroVendas>();

        public Vendedor()
        {
        }

        public Vendedor(int id, string nome, string email, DateTime dataNascimento, double salarioBase, Departamento departamento)
        {
            Id = id;
            Nome = nome;
            Email = email;
            DataNascimento = dataNascimento;
            SalarioBase = salarioBase;
            Departamento = departamento;
        }

        public void AddVendas(RegistroVendas sr)
        {
            Vendas.Add(sr);
        }

        public void RemoveVendas(RegistroVendas sr)
        {
            Vendas.Remove(sr);
        }

        public double TotalVendas(DateTime initial, DateTime final)
        {
            return Vendas.Where(sr => sr.Data >= initial && sr.Data <= final).Sum(sr => sr.Quantia);
        }
    }
}
