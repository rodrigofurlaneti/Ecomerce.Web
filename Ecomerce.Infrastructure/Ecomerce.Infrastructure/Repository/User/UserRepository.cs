using Ecomerce.Domain.SeedWork;
using System.Data.SqlClient;
using System.Data;

namespace Ecomerce.Infrastructure.Repository.User
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(ILogger logger) : base(logger) { }

        public async Task DeleteAsync(int id)
        {
            try
            {
                _logger.TraceEntry("Infrastructure_User_DeleteAsync");
                _commandText = "USP_Restaurant_User_Delete";
                SqlConnection sqlConnection = new SqlConnection(_connectionString);
                SqlCommand sqlCommand = new SqlCommand(_commandText, sqlConnection);
                GetUserDelete(sqlCommand, id);
                sqlConnection.Open();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                await sqlCommand.ExecuteNonQueryAsync();
                sqlConnection.Close();
                _logger.TraceExit("Infrastructure_User_DeleteAsync");
            }
            catch (ArgumentNullException ex)
            {
                _logger.TraceException("Infrastructure_User_DeleteAsync");
                string mensagemErro = "Erro ao consumir a procedure " + _commandText + " , está na camada Infrastructure, Repository, entidade User, método DeleteAsync, tipo assíncrono. " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }
        }

        public async Task<List<Domain.Models.User>> GetAsync()
        {
            List<Domain.Models.User> list = new List<Domain.Models.User>();
            try
            {
                _logger.TraceEntry("Infrastructure_User_GetAsync");
                _commandText = "USP_Restaurant_User_Get";
                using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand(_commandText, sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();
                    while (sqlDataReader.Read())
                    {
                        GetListUser(sqlDataReader, list);
                    }
                }
                _logger.TraceExit("Infrastructure_User_GetAsync");

            }
            catch (ArgumentNullException ex)
            {
                _logger.TraceException("Infrastructure_User_GetAsync");
                string mensagemErro = "Erro ao consumir a procedure " + _commandText + " , está na camada Infrastructure, Repository, entidade User, método Get, tipo assíncrono. " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }
            return list;
        }

        public async Task<Domain.Models.User> GetByIdAsync(int id)
        {
            Domain.Models.User entity = new Domain.Models.User();
            try
            {
                _logger.TraceEntry("Infrastructure_User_GetByIdAsync");
                _commandText = "USP_Restaurant_User_GetById";
                using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand(_commandText, sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@Id", id);
                    sqlConnection.Open();
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();
                    while (sqlDataReader.Read())
                    {
                        GetUser(sqlDataReader, entity);
                    }
                }
                _logger.TraceExit("Infrastructure_User_GetByIdAsync");
            }
            catch (ArgumentNullException ex)
            {
                _logger.TraceException("Infrastructure_User_GetByIdAsync");
                string mensagemErro = "Erro ao consumir a procedure " + _commandText + " , está na camada Infrastructure, Repository, entidade User, método GetByIdAsync, tipo assíncrono. " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }
            return entity;
        }

        public async Task PostAsync(Domain.Models.User entity)
        {
            try
            {
                _logger.TraceEntry("Infrastructure_User_PostAsync");
                _commandText = "USP_Restaurant_User_Post";
                SqlConnection sqlConnection = new SqlConnection(_connectionString);
                SqlCommand sqlCommand = new SqlCommand(_commandText, sqlConnection);
                GetUserInsert(sqlCommand, entity);
                sqlConnection.Open();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                await sqlCommand.ExecuteNonQueryAsync();
                sqlConnection.Close();
                _logger.TraceExit("Infrastructure_User_PostAsync");
            }
            catch (ArgumentNullException ex)
            {
                _logger.TraceException("Infrastructure_User_PostAsync");
                string mensagemErro = "Erro ao consumir a procedure " + _commandText + " , está na camada Infrastructure, Repository, entidade User, método PostAsync, tipo síncrono. " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }
        }

        public async Task PutAsync(Domain.Models.User entity)
        {
            try
            {
                _logger.TraceEntry("Infrastructure_User_PutAsync");
                _commandText = "USP_Restaurant_User_Put";
                SqlConnection sqlConnection = new SqlConnection(_connectionString);
                SqlCommand sqlCommand = new SqlCommand(_commandText, sqlConnection);
                GetUserUpdate(sqlCommand, entity);
                sqlConnection.Open();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                await sqlCommand.ExecuteNonQueryAsync();
                sqlConnection.Close();
                _logger.TraceExit("Infrastructure_User_PutAsync");
            }
            catch (ArgumentNullException ex)
            {
                _logger.TraceException("Infrastructure_User_PutAsync");
                string mensagemErro = "Erro ao consumir a procedure " + _commandText + " , está na camada Infrastructure, Repository, entidade User, método PutAsync, tipo assíncrono. " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }
        }

        #region Helpers

        private static void GetListUser(SqlDataReader sqlDataReader, List<Domain.Models.User> listVehicleUserModel)
        {
            Domain.Models.User userModel = new Domain.Models.User();
            GetUser(sqlDataReader, userModel);
            listVehicleUserModel.Add(userModel);
        }

        private static void GetUser(SqlDataReader sqlDataReader, Domain.Models.User userModel)
        {
            userModel.Profile = new Domain.Models.Profile();
            userModel.Id = Convert.ToInt32(sqlDataReader["Id"]);
            userModel.Name = Convert.ToString(sqlDataReader["Name"]);
            userModel.Profile.ProfileId = Convert.ToInt32(sqlDataReader["IdProfile"]);
            userModel.Status = Convert.ToBoolean(sqlDataReader["Status"]);
            userModel.DateInsert = Convert.ToDateTime(sqlDataReader["DateInsert"]);
            userModel.DateUpdate = Convert.ToDateTime(sqlDataReader["DateUpdate"]);
        }

        private static void GetUserInsert(SqlCommand sqlCommand, Domain.Models.User entity)
        {
            sqlCommand.Parameters.AddWithValue("@Name", entity.Name);
            sqlCommand.Parameters.AddWithValue("@IdProfile", entity.Profile.ProfileId);
            sqlCommand.Parameters.AddWithValue("@Status", entity.Status);
            sqlCommand.Parameters.AddWithValue("@DateInsert", entity.DateInsert);
            sqlCommand.Parameters.AddWithValue("@DateUpdate", entity.DateUpdate);
        }

        private static void GetUserUpdate(SqlCommand sqlCommand, Domain.Models.User entity)
        {
            sqlCommand.Parameters.AddWithValue("@Id", entity.Id);
            sqlCommand.Parameters.AddWithValue("@Name", entity.Name);
            sqlCommand.Parameters.AddWithValue("@IdProfile", entity.Profile.ProfileId);
            sqlCommand.Parameters.AddWithValue("@Status", entity.Status);
            sqlCommand.Parameters.AddWithValue("@DateInsert", entity.DateInsert);
            sqlCommand.Parameters.AddWithValue("@DateUpdate", entity.DateUpdate);
        }

        private static void GetUserDelete(SqlCommand sqlCommand, int id)
        {
            sqlCommand.Parameters.AddWithValue("@Id", id);
        }

        #endregion

    }
}