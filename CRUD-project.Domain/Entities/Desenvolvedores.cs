using System;

namespace CRUD_project.Domain.Entities
{
    public class Desenvolvedores : BaseEntity
    {
        public string Nome { get; set; }
        public string Sexo { get; set; }
        public int Idade { get; set; } 
        public string Hobby { get; set; }
        public DateTime Datanascimento { get; set; }

        public Desenvolvedores(string nome, string sexo, int idade, string hobby, DateTime datanascimento)
        {
            Nome = nome;
            Sexo = sexo;
            Idade = idade;
            Hobby = hobby;
            Datanascimento = datanascimento;
        }
    }
}
