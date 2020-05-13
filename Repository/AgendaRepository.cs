using SistemaCRM.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SistemaCRM.Repository {
    public class AgendaRepository: Database {
        public void Create(Agenda agenda) {
            try {
                base.OpenConn();
                base.Cmd = new SqlCommand(@"INSER INTO Agenda VALUES(@date, @contato, @titulo, @descricao, @inicio, @final)", base.Con);

                base.Cmd.Parameters.AddWithValue("@date", agenda.DataAgenda);
                base.Cmd.Parameters.AddWithValue("@contato", agenda.Contato.ID);
                base.Cmd.Parameters.AddWithValue("@titulo", agenda.Titulo);
                base.Cmd.Parameters.AddWithValue("@descricao", agenda.Descricao);
                base.Cmd.Parameters.AddWithValue("@inicio", agenda.HorarioInicio);
                base.Cmd.Parameters.AddWithValue("@final", agenda.HorarioFim);

                base.Cmd.ExecuteNonQuery();
            }
            catch (Exception e) {
                throw new Exception($"Erro ao criar um contato: {e.Message}");
            }
            finally {
                base.CloseConn();
            }
        }

        public List<Agenda> Read() {
            var agendas = new List<Agenda>();

            try {
                base.OpenConn();
                base.Cmd = new SqlCommand(@"SELECT a.*, b.ID AS Codigo, b.Nome, b.Email FROM Agenda AS a INNER JOIN Contato AS b ON a.contato_id = b.ID", base.Con);
                base.Dr = base.Cmd.ExecuteReader();

                while (base.Dr.Read()) {
                    var contato = new Contato();
                    contato.ID = (int) base.Dr["Codigo"];
                    contato.Nome = (string) base.Dr["Nome"];
                    contato.Email = (string) base.Dr["Email"];

                    var agenda = new Agenda();
                    agenda.Id = (int) base.Dr["ID"];
                    agenda.DataAgenda = (DateTime) base.Dr["data_agenda"];
                    agenda.Titulo = (string) base.Dr["titulo"];
                    agenda.Descricao = (string) base.Dr["descricao"];
                    agenda.HorarioInicio = (DateTime) base.Dr["horario_inicio"];
                    agenda.HorarioFim = (DateTime) base.Dr["horario_fim"];

                    agenda.Contato = contato;

                    agendas.Add(agenda);
                }
            }
            catch (Exception e) {
                throw new Exception($"Erro ao criar um contato: {e.Message}");
            }
            finally {
                base.CloseConn();
            }

            return agendas;
        }

        public void Update(Agenda agenda) {
            try {
                base.OpenConn();
                base.Cmd = new SqlCommand(@"UPDATE Agenda SET data_agenda=@date, contato_id=@contato, titulo=@titulo, descricao=@descricao, horario_inicio=@inicio, horario_fim=@final WHERE ID=@id", base.Con);

                base.Cmd.Parameters.AddWithValue("@date", agenda.DataAgenda);
                base.Cmd.Parameters.AddWithValue("@contato", agenda.Contato.ID);
                base.Cmd.Parameters.AddWithValue("@titulo", agenda.Titulo);
                base.Cmd.Parameters.AddWithValue("@descricao", agenda.Descricao);
                base.Cmd.Parameters.AddWithValue("@inicio", agenda.HorarioInicio);
                base.Cmd.Parameters.AddWithValue("@final", agenda.HorarioFim);
                base.Cmd.Parameters.AddWithValue("@ID", agenda.Id);

                base.Cmd.ExecuteNonQuery();
            }
            catch (Exception e) {
                throw new Exception($"Erro ao editar um contato: {e.Message}");
            }
            finally {
                base.CloseConn();
            }
        }

        public void Delete(Agenda agenda) {
            try {
                base.OpenConn();
                base.Cmd = new SqlCommand(@"Delete FROM Agenda WHERE ID=@id", base.Con);

                base.Cmd.Parameters.AddWithValue("@ID", agenda.Id);

                base.Cmd.ExecuteNonQuery();
            }
            catch (Exception e) {
                throw new Exception($"Erro ao apagar um contato: {e.Message}");
            }
            finally {
                base.CloseConn();
            }
        }
    }
}