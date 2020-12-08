﻿using MongoDB.Driver;
using NyousAPINoSql.Contexts;
using NyousAPINoSql.Domains;
using NyousAPINoSql.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NyousAPINoSql.Repositories
{
    public class EventoRepository : iEventoRepository
    {
        private readonly IMongoCollection<EventoDomain> _eventos;

        public EventoRepository(iNyousDatabaseSettings settings){
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _eventos = database.GetCollection<EventoDomain>(settings.EventosCollectionName);
        }

        public void Adicionar(EventoDomain evento)
        {
            try
            {
                _eventos.InsertOne(evento);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Atualizar(string id, EventoDomain evento)
        {
            try
            {
                _eventos.ReplaceOne(c => c.Id == id, evento);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<EventoDomain> Listar()
        {
            try
            {
                return _eventos.AsQueryable<EventoDomain>().ToList();
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public void Remover(string id)
        {
            try
            {
                var evento = _eventos.Find<EventoDomain>(e => e.Id == id).First();

                _eventos.DeleteOne(c => c.Id == id);
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
