using ExtensionMethods.ExtensionMethods;
using System;

namespace ExtensionMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Os métodos de extensão permitem que você "adicione" tipos existentes sem criar um novo tipo derivado,
            recompilar ou, caso contrário, modificar o tipo original.Os métodos de extensão são métodos estáticos,
            mas são chamados como se fossem métodos de instância no tipo estendido. Para o código de cliente escrito em C#,
            F # e Visual Basic, não há nenhuma diferença aparente entre chamar um método de extensão e os métodos definidos
            em um tipo.
            */
            using var ctx = new DataContext();
            Setup(ctx);

            Agendamento agendamento = new Agendamento();

            var resultado = agendamento.AgendarSalaoExtension("cleiton", DateTime.Now);

            foreach (var item in resultado)
            {
                Console.WriteLine($"Nome : {item.Usuario} Data Agenda : {item.DataAgenda} DataSolicitacao:{item.DataSolicitacao}");
            }

            Console.ReadKey();
        }

        static void Setup(DataContext db)
        {
            if (db.Database.EnsureCreated())
            {
                db.Agendamento.Add(
                    new Agenda
                    {
                        Usuario = "Farley",
                        DataAgenda = DateTime.Now,
                        DataSolicitacao = DateTime.Now.AddDays(2)
                    });

                db.SaveChanges();
                db.ChangeTracker.Clear();
            }
        }
    }
}

