using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExtensionMethods.ExtensionMethods
{
    public static class AgendamentoExtension
    {
        // Para o extension funcionar tem que passar a classe que esta sendo extendida usando o this
        public static List<Agenda> AgendarSalaoExtension(this Agendamento ag, string usuario, DateTime data)
        {
            using (var ctx = new DataContext())
            {
                List<Agenda> resultado = new List<Agenda>();
                //Busca datas com os parametros recebidos na chamada dos métodos
                var agendamento = ctx.Agendamento.Where(x => x.DataAgenda == data);
                //Popula a variável com true ou false
                bool disponivel = agendamento.Any();
                //Validade se é false, se sim grava na tabela se não retorna a mensagem
                if (disponivel == false)
                {
                    Agenda agenda = new Agenda()
                    {
                        Usuario = usuario,
                        DataAgenda = data,
                        DataSolicitacao = DateTime.Now
                    };
                    ctx.Agendamento.Add(agenda);
                    ctx.SaveChanges();

                    var lista = ctx.Agendamento.Where(p => p.Usuario == usuario && p.DataAgenda == data).ToList();

                    foreach (var item in lista)
                    {
                        resultado.Add(item);
                    }

                    return resultado;
                }
                else
                {
                    var lista = ctx.Agendamento.ToList();

                    foreach (var item in lista)
                    {
                        resultado.Add(item);
                    }

                    return resultado;
                }
            }
        }
    }
}
