using System;
using System.Data.SqlClient;

namespace SistemaCRM.Repository {
    public class Database {
        protected SqlConnection Con;
        protected SqlCommand Cmd;
        protected SqlDataReader Dr;

        protected void OpenConn() {
            try {
                Con = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=BDCrm;Integrated Security=True;MultipleActiveResultSets=True;");
                Con.Open();
            }
            catch (Exception e) {
                throw new Exception($"Erro ao abrir a conexão: {e.Message}");
            }
        }

        protected void CloseConn() {
            try {
                if (Con == null)
                    return;

                Con.Close();
            } catch (Exception e) {
                throw new Exception($"Erro ao fechar conexão: ${e.Message}");
            }
        }
    }
}