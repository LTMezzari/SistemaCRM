using SistemaCRM.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SistemaCRM.Repository {
    public class ContatoRepository: Database {
        public void Create(Contato contato) {
            try {
                base.OpenConn();
                base.Cmd = new SqlCommand(@"INSER INTO Contato VALUES(@nome, @email)", base.Con);

                base.Cmd.Parameters.AddWithValue("@nome", contato.Nome);
                base.Cmd.Parameters.AddWithValue("@email", contato.Email);

                base.Cmd.ExecuteNonQuery();
            } catch (Exception e) {
                throw new Exception($"Erro ao criar um contato: {e.Message}");
            } finally {
                base.CloseConn();
            }
        }

        public List<Contato> Read() {
            var contatos = new List<Contato>();

            try {
                base.OpenConn();
                base.Cmd = new SqlCommand(@"SELECT * FROM Contato", base.Con);
                base.Dr = base.Cmd.ExecuteReader();
                
                while (base.Dr.Read()) {
                    var contato = new Contato();
                    contato.ID = (int) base.Dr["ID"];
                    contato.Nome = (string) base.Dr["Nome"];
                    contato.Email = (string) base.Dr["Email"];
                    contatos.Add(contato);
                }
            } catch (Exception e) {
                throw new Exception($"Erro ao criar um contato: {e.Message}");
            } finally {
                base.CloseConn();
            }

            return contatos;
        }

        public void Update(Contato contato) {
            try {
                base.OpenConn();
                base.Cmd = new SqlCommand(@"UPDATE Contato SET Nome=@nome, Email=@email WHERE ID=@id", base.Con);

                base.Cmd.Parameters.AddWithValue("@nome", contato.Nome);
                base.Cmd.Parameters.AddWithValue("@email", contato.Email);
                base.Cmd.Parameters.AddWithValue("@ID", contato.ID);

                base.Cmd.ExecuteNonQuery();
            }
            catch (Exception e) {
                throw new Exception($"Erro ao editar um contato: {e.Message}");
            }
            finally {
                base.CloseConn();
            }
        }

        public void Delete(Contato contato) {
            try {
                base.OpenConn();
                base.Cmd = new SqlCommand(@"Delete FROM Contato WHERE ID=@id", base.Con);

                base.Cmd.Parameters.AddWithValue("@ID", contato.ID);

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