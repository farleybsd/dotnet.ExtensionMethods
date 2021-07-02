using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExtensionMethods.ExtensionMethods
{
    public class Agendamento
    {
        public string AgendarSalao(string usuario,DateTime data)
        {
            using (var ctx = new DataContext())
            {
                
                string resultado = string.Empty;
                //Busca datas com os parametros recebidos na chamada dos métodos
                var agendamento = ctx.Agendamento.Where(x => x.DataAgenda == data).Select(x =>
                new {


                     x.Usuario ,
                    x.DataAgenda ,
                    x.DataSolicitacao }).ToList();
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
                    return resultado = "Agendamento realizado com sucesso!";
                }
                else
                {
                    return resultado = "Data indisponivel.";
                }
            }
        }

        
    }
}
