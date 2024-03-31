using Ecomerce.Domain.Entities;
using Ecomerce.Domain.SeedWork;
using System.Data.SqlClient;
using System.Data;

namespace Ecomerce.Infrastructure.Repository.Register
{
    public class RegisterRepository : BaseRepository, IRegisterRepository
    {
        public RegisterRepository(ILogger logger) : base(logger) { }

        public async Task DeleteAsync(int id)
        {
            try
            {
                _logger.TraceEntry("Infrastructure_Register_DeleteAsync");
                _commandText = "USP_Restaurant_Register_Delete";
                SqlConnection sqlConnection = new SqlConnection(_connectionString);
                SqlCommand sqlCommand = new SqlCommand(_commandText, sqlConnection);
                GetRegisterDelete(sqlCommand, id);
                sqlConnection.Open();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                await sqlCommand.ExecuteNonQueryAsync();
                sqlConnection.Close();
                _logger.TraceExit("Infrastructure_Register_DeleteAsync");
            }
            catch (ArgumentNullException ex)
            {
                _logger.TraceException("Infrastructure_Register_DeleteAsync");
                string mensagemErro = "Erro ao consumir a procedure " + _commandText + " , está na camada Infrastructure, Repository, entidade Register, método DeleteAsync, tipo assíncrono. " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }
        }

        public async Task<List<RegisterEntity>> GetAsync()
        {
            List<RegisterEntity> list = new List<RegisterEntity>();
            try
            {
                _logger.TraceEntry("Infrastructure_Register_GetAsync");
                _commandText = "USP_Restaurant_Register_Get";
                using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand(_commandText, sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();
                    while (sqlDataReader.Read())
                    {
                        GetListRegister(sqlDataReader, list);
                    }
                }
                _logger.TraceExit("Infrastructure_Register_GetAsync");

            }
            catch (ArgumentNullException ex)
            {
                _logger.TraceException("Infrastructure_Register_GetAsync");
                string mensagemErro = "Erro ao consumir a procedure " + _commandText + " , está na camada Infrastructure, Repository, entidade Register, método Get, tipo assíncrono. " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }
            return list;
        }

        public async Task<RegisterEntity> GetByIdAsync(int id)
        {
            RegisterEntity entity = new RegisterEntity();
            try
            {
                _logger.TraceEntry("Infrastructure_Register_GetByIdAsync");
                _commandText = "USP_Restaurant_Register_GetById";
                using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand(_commandText, sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@Id", id);
                    sqlConnection.Open();
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();
                    while (sqlDataReader.Read())
                    {
                        GetRegister(sqlDataReader, entity);
                    }
                }
                _logger.TraceExit("Infrastructure_Register_GetByIdAsync");
            }
            catch (ArgumentNullException ex)
            {
                _logger.TraceException("Infrastructure_Register_GetByIdAsync");
                string mensagemErro = "Erro ao consumir a procedure " + _commandText + " , está na camada Infrastructure, Repository, entidade Register, método GetByIdAsync, tipo assíncrono. " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }
            return entity;
        }

        public async Task PostAsync(RegisterEntity entity)
        {
            try
            {
                _logger.TraceEntry("Infrastructure_Register_PostAsync");
                _commandText = "USP_Restaurant_Register_Post";
                SqlConnection sqlConnection = new SqlConnection(_connectionString);
                SqlCommand sqlCommand = new SqlCommand(_commandText, sqlConnection);
                GetRegisterInsert(sqlCommand, entity);
                sqlConnection.Open();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                await sqlCommand.ExecuteNonQueryAsync();
                sqlConnection.Close();
                _logger.TraceExit("Infrastructure_Register_PostAsync");
            }
            catch (ArgumentNullException ex)
            {
                _logger.TraceException("Infrastructure_Register_PostAsync");
                string mensagemErro = "Erro ao consumir a procedure " + _commandText + " , está na camada Infrastructure, Repository, entidade Register, método PostAsync, tipo síncrono. " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }
        }

        public async Task PutAsync(RegisterEntity entity)
        {
            try
            {
                _logger.TraceEntry("Infrastructure_Register_PutAsync");
                _commandText = "USP_Restaurant_Register_Put";
                SqlConnection sqlConnection = new SqlConnection(_connectionString);
                SqlCommand sqlCommand = new SqlCommand(_commandText, sqlConnection);
                GetRegisterUpdate(sqlCommand, entity);
                sqlConnection.Open();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                await sqlCommand.ExecuteNonQueryAsync();
                sqlConnection.Close();
                _logger.TraceExit("Infrastructure_Register_PutAsync");
            }
            catch (ArgumentNullException ex)
            {
                _logger.TraceException("Infrastructure_Register_PutAsync");
                string mensagemErro = "Erro ao consumir a procedure " + _commandText + " , está na camada Infrastructure, Repository, entidade Register, método PutAsync, tipo assíncrono. " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }
        }

        #region Helpers

        private static void GetListRegister(SqlDataReader sqlDataReader, List<RegisterEntity> listVehicleRegisterModel)
        {
            RegisterEntity registerEntity = new RegisterEntity();
            GetRegister(sqlDataReader, registerEntity);
            listVehicleRegisterModel.Add(registerEntity);
        }

        private static void GetRegister(SqlDataReader sqlDataReader, RegisterEntity registerEntity)
        {
            registerEntity.Id = Convert.ToInt32(sqlDataReader["Id"]);
            registerEntity.FullName = Convert.ToString(sqlDataReader["FullName"]);
            registerEntity.Gender = Convert.ToString(sqlDataReader["Gender"]);
            registerEntity.DateOfBirth = Convert.ToString(sqlDataReader["DateOfBirth"]);
            registerEntity.RegistrationOfIndividuals = Convert.ToString(sqlDataReader["RegistrationOfIndividuals"]);
            registerEntity.Telephone = Convert.ToString(sqlDataReader["Telephone"]);
            registerEntity.ZipCode = Convert.ToString(sqlDataReader["ZipCode"]);
            registerEntity.Address = Convert.ToString(sqlDataReader["Address"]);
            registerEntity.Number = Convert.ToString(sqlDataReader["Number"]);
            registerEntity.City = Convert.ToString(sqlDataReader["City"]);
            registerEntity.State = Convert.ToString(sqlDataReader["State"]);
            registerEntity.Email = Convert.ToString(sqlDataReader["Email"]);
            registerEntity.Password = Convert.ToString(sqlDataReader["Password"]);
            registerEntity.ConfirmedEmail = Convert.ToBoolean(sqlDataReader["ConfirmedEmail"]);
            registerEntity.Status = Convert.ToBoolean(sqlDataReader["Status"]);
            registerEntity.DateInsert = Convert.ToDateTime(sqlDataReader["DateInsert"]);
            registerEntity.DateUpdate = Convert.ToDateTime(sqlDataReader["DateUpdate"]);
        }

        private static void GetRegisterInsert(SqlCommand sqlCommand, RegisterEntity entity)
        {
            sqlCommand.Parameters.AddWithValue("@FullName", entity.FullName);
            sqlCommand.Parameters.AddWithValue("@Gender", entity.Gender);
            sqlCommand.Parameters.AddWithValue("@DateOfBirth", entity.DateOfBirth);
            sqlCommand.Parameters.AddWithValue("@RegistrationOfIndividuals", entity.RegistrationOfIndividuals);
            sqlCommand.Parameters.AddWithValue("@Telephone", entity.Telephone);
            sqlCommand.Parameters.AddWithValue("@ZipCode", entity.ZipCode);
            sqlCommand.Parameters.AddWithValue("@Address", entity.Address);
            sqlCommand.Parameters.AddWithValue("@Number", entity.Number);
            sqlCommand.Parameters.AddWithValue("@City", entity.City);
            sqlCommand.Parameters.AddWithValue("@State", entity.State);
            sqlCommand.Parameters.AddWithValue("@Email", entity.Email);
            sqlCommand.Parameters.AddWithValue("@Password", entity.Password);
            sqlCommand.Parameters.AddWithValue("@ConfirmedEmail", entity.ConfirmedEmail);
            sqlCommand.Parameters.AddWithValue("@Status", entity.Status);
            sqlCommand.Parameters.AddWithValue("@DateInsert", entity.DateInsert);
            sqlCommand.Parameters.AddWithValue("@DateUpdate", entity.DateUpdate);
        }

        private static void GetRegisterUpdate(SqlCommand sqlCommand, RegisterEntity entity)
        {
            sqlCommand.Parameters.AddWithValue("@Id", entity.Id);
            sqlCommand.Parameters.AddWithValue("@FullName", entity.FullName);
            sqlCommand.Parameters.AddWithValue("@Gender", entity.Gender);
            sqlCommand.Parameters.AddWithValue("@DateOfBirth", entity.DateOfBirth);
            sqlCommand.Parameters.AddWithValue("@RegistrationOfIndividuals", entity.RegistrationOfIndividuals);
            sqlCommand.Parameters.AddWithValue("@Telephone", entity.Telephone);
            sqlCommand.Parameters.AddWithValue("@ZipCode", entity.ZipCode);
            sqlCommand.Parameters.AddWithValue("@Address", entity.Address);
            sqlCommand.Parameters.AddWithValue("@Number", entity.Number);
            sqlCommand.Parameters.AddWithValue("@City", entity.City);
            sqlCommand.Parameters.AddWithValue("@State", entity.State);
            sqlCommand.Parameters.AddWithValue("@Email", entity.Email);
            sqlCommand.Parameters.AddWithValue("@Password", entity.Password);
            sqlCommand.Parameters.AddWithValue("@ConfirmedEmail", entity.ConfirmedEmail);
            sqlCommand.Parameters.AddWithValue("@Status", entity.Status);
            sqlCommand.Parameters.AddWithValue("@DateInsert", entity.DateInsert);
            sqlCommand.Parameters.AddWithValue("@DateUpdate", entity.DateUpdate);
        }

        private static void GetRegisterDelete(SqlCommand sqlCommand, int id)
        {
            sqlCommand.Parameters.AddWithValue("@Id", id);
        }

        #endregion

    }
}