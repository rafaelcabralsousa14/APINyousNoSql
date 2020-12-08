using NyousAPINoSql.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NyousAPINoSql.Interfaces
{
    public interface iEventoRepository
    {
        List<EventoDomain> Listar();

        void Adicionar(EventoDomain evento);

        void Atualizar(string id, EventoDomain evento);

        void Remover(string id);
    }
}
