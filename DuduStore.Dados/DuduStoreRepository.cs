using DuduStore.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuduStore.Dados
{
    public class DuduStoreRepository
    {
        public bool InserirUsuario(Usuario usuario)
        {
            var procedure = "sp_incluir_cliente";

            var parameters = new List<SqlParameter>()
            {
                new SqlParameter() {DbType = System.Data.DbType.String, ParameterName = "@nome", Value = usuario.Nome},
                new SqlParameter() {DbType = System.Data.DbType.String, ParameterName = "@login", Value = usuario.Login},
                new SqlParameter() {DbType = System.Data.DbType.String, ParameterName = "@senha", Value = usuario.Senha},
                new SqlParameter() {DbType = System.Data.DbType.String, ParameterName = "@tel", Value = usuario.Tel}
            };

            using (var dbHelper = new DuduStoreCommand())
            {
                var command = dbHelper.CriarComando(procedure, parameters);

                var retornaLinhas = command.ExecuteNonQuery();

                if (retornaLinhas > 0)
                    return true;
                return false;
            }
        }

        public List<Usuario> ListarUsuario()
        {
            var usuarios = new List<Usuario>();

            var procedure = "sp_listar_cliente";

            using (var dbHelper = new DuduStoreCommand())
            {
                var command = dbHelper.CriarComando(procedure);

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    usuarios.Add(new Usuario
                    {
                        Nome = reader["nome"].ToString(),
                        Login = reader["login"].ToString(),
                        Senha = reader["senha"].ToString(),
                        Tel = reader["tel"].ToString()

                    });                        
                }

                return usuarios;
            }
        }

        public Usuario ObterUsuario(int id)
        {
            var usuario = new Usuario();

            var procedure = "sp_obter_cliente";

            var parameters = new List<SqlParameter>()
            {
                new SqlParameter() {DbType = System.Data.DbType.Int32, ParameterName = "@cliente_id", Value = id}
            };

            using (var dbHelper = new DuduStoreCommand())
            {
                var command = dbHelper.CriarComando(procedure, parameters);

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    usuario.Id = Convert.ToInt32(reader["cliente_id"]);
                    usuario.Nome = reader["nome"].ToString();
                    usuario.Login = reader["login"].ToString();
                    usuario.Senha = reader["senha"].ToString();
                    usuario.Tel = reader["tel"].ToString();
                }
            }
            return usuario;
        }

        public bool AlterarUsuario(Usuario usuario)
        {
            var procedure = "sp_alterar_cliente";

            var parameters = new List<SqlParameter>()
            {
                new SqlParameter() {DbType = System.Data.DbType.Int32, ParameterName = "@cliente_id", Value = usuario.Id},
                new SqlParameter() {DbType = System.Data.DbType.String, ParameterName = "@nome", Value = usuario.Nome},
                new SqlParameter() {DbType = System.Data.DbType.String, ParameterName = "@login", Value = usuario.Login},
                new SqlParameter() {DbType = System.Data.DbType.String, ParameterName = "@senha", Value = usuario.Senha},
                new SqlParameter() {DbType = System.Data.DbType.String, ParameterName = "@tel", Value = usuario.Tel}
            };

            using (var dbHelper = new DuduStoreCommand())
            {
                var command = dbHelper.CriarComando(procedure, parameters);
                var retornar = command.ExecuteNonQuery();

                if (retornar > 0)
                    return true;
                return false;
            }
        }

        public bool ExcluirUsuario(int id)
        {
            var procedure = "sp_excluir_cliente";

            var parameters = new List<SqlParameter>()
            {
                new SqlParameter() {DbType = System.Data.DbType.Int32, ParameterName = "@cliente_id", Value = id}
            };

            using (var dbHelper = new DuduStoreCommand())
            {
                var command = dbHelper.CriarComando(procedure, parameters);
                var retornar = command.ExecuteNonQuery();

                if (retornar > 0)
                    return true;
                return false;
            }
        }
    }
}
