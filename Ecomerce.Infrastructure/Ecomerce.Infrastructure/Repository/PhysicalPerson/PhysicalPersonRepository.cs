using Ecomerce.Domain.SeedWork;
using System.Data.SqlClient;
using System.Data;

namespace Ecomerce.Infrastructure.Repository.PhysicalPerson
{
    public class PhysicalPersonRepository : BaseRepository, IPhysicalPersonRepository
    {
        public PhysicalPersonRepository(ILogger logger) : base(logger) { }

        public async Task DeleteAsync(int id)
        {
            try
            {
                _logger.TraceEntry("Infrastructure_PhysicalPerson_DeleteAsync");
                _commandText = "USP_Ecomerce_PhysicalPerson_Delete";
                SqlConnection sqlConnection = new SqlConnection(_connectionString);
                SqlCommand sqlCommand = new SqlCommand(_commandText, sqlConnection);
                GetPhysicalPersonDelete(sqlCommand, id);
                sqlConnection.Open();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                await sqlCommand.ExecuteNonQueryAsync();
                sqlConnection.Close();
                _logger.TraceExit("Infrastructure_PhysicalPerson_DeleteAsync");
            }
            catch (ArgumentNullException ex)
            {
                _logger.TraceException("Infrastructure_PhysicalPerson_DeleteAsync");
                string mensagemErro = "Erro ao consumir a procedure " + _commandText + " , está na camada Infrastructure, Repository, entidade PhysicalPerson, método DeleteAsync, tipo assíncrono. " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }
        }

        public async Task<List<Domain.Models.PhysicalPerson>> GetAsync()
        {
            List<Domain.Models.PhysicalPerson> list = new List<Domain.Models.PhysicalPerson>();
            try
            {
                _logger.TraceEntry("Infrastructure_PhysicalPerson_GetAsync");
                _commandText = "USP_Ecomerce_PhysicalPerson_Get";
                using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand(_commandText, sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();
                    while (sqlDataReader.Read())
                    {
                        GetListPhysicalPerson_PhysicalPerson(sqlDataReader, list);
                    }
                }
                _logger.TraceExit("Infrastructure_PhysicalPerson_GetAsync");

            }
            catch (ArgumentNullException ex)
            {
                _logger.TraceException("Infrastructure_PhysicalPerson_GetAsync");
                string mensagemErro = "Erro ao consumir a procedure " + _commandText + " , está na camada Infrastructure, Repository, entidade PhysicalPerson, método Get, tipo assíncrono. " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }
            return list;
        }

        public async Task<Domain.Models.PhysicalPerson> GetByIdAsync(int id)
        {
            Domain.Models.PhysicalPerson entity = new Domain.Models.PhysicalPerson();
            try
            {
                _logger.TraceEntry("Infrastructure_PhysicalPerson_GetByIdAsync");
                _commandText = "USP_Ecomerce_PhysicalPerson_GetById";
                using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand(_commandText, sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@Id", id);
                    sqlConnection.Open();
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();
                    while (sqlDataReader.Read())
                    {
                        GetPhysicalPerson_PhysicalPerson(sqlDataReader, entity);
                    }
                }
                _logger.TraceExit("Infrastructure_PhysicalPerson_GetByIdAsync");
            }
            catch (ArgumentNullException ex)
            {
                _logger.TraceException("Infrastructure_PhysicalPerson_GetByIdAsync");
                string mensagemErro = "Erro ao consumir a procedure " + _commandText + " , está na camada Infrastructure, Repository, entidade PhysicalPerson, método GetByIdAsync, tipo assíncrono. " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }
            return entity;
        }

        public async Task PostAsync(Domain.Models.PhysicalPerson entity)
        {
            try
            {
                _logger.TraceEntry("Infrastructure_PhysicalPerson_PostAsync");
                _commandText = "USP_Ecomerce_PhysicalPerson_Post";
                SqlConnection sqlConnection = new SqlConnection(_connectionString);
                SqlCommand sqlCommand = new SqlCommand(_commandText, sqlConnection);
                GetPhysicalPersonInsert_PhysicalPerson(sqlCommand, entity);
                sqlConnection.Open();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                await sqlCommand.ExecuteNonQueryAsync();
                sqlConnection.Close();
                _logger.TraceExit("Infrastructure_PhysicalPerson_PostAsync");
            }
            catch (ArgumentNullException ex)
            {
                _logger.TraceException("Infrastructure_PhysicalPerson_PostAsync");
                string mensagemErro = "Erro ao consumir a procedure " + _commandText + " , está na camada Infrastructure, Repository, entidade PhysicalPerson, método PostAsync, tipo síncrono. " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }
        }

        public async Task PutAsync(Domain.Models.PhysicalPerson entity)
        {
            try
            {
                _logger.TraceEntry("Infrastructure_PhysicalPerson_PutAsync");
                _commandText = "USP_Ecomerce_PhysicalPerson_Put";
                SqlConnection sqlConnection = new SqlConnection(_connectionString);
                SqlCommand sqlCommand = new SqlCommand(_commandText, sqlConnection);
                GetPhysicalPersonUpdate_PhysicalPerson(sqlCommand, entity);
                sqlConnection.Open();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                await sqlCommand.ExecuteNonQueryAsync();
                sqlConnection.Close();
                _logger.TraceExit("Infrastructure_PhysicalPerson_PutAsync");
            }
            catch (ArgumentNullException ex)
            {
                _logger.TraceException("Infrastructure_PhysicalPerson_PutAsync");
                string mensagemErro = "Erro ao consumir a procedure " + _commandText + " , está na camada Infrastructure, Repository, entidade PhysicalPerson, método PutAsync, tipo assíncrono. " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }
        }

        #region Helpers

        private static void GetListPhysicalPerson_PhysicalPerson(SqlDataReader sqlDataReader, List<Domain.Models.PhysicalPerson> listVehiclePhysicalPersonModel)
        {
            Domain.Models.PhysicalPerson physicalPersonEntity = new Domain.Models.PhysicalPerson();
            GetPhysicalPerson_PhysicalPerson(sqlDataReader, physicalPersonEntity);
            listVehiclePhysicalPersonModel.Add(physicalPersonEntity);
        }

        private static void GetPhysicalPerson_PhysicalPerson(SqlDataReader sqlDataReader, Domain.Models.PhysicalPerson physicalPersonEntity)
        {
            physicalPersonEntity.PhysicalPersonId = Convert.ToInt32(sqlDataReader["Id"]);
            physicalPersonEntity.FullName = Convert.ToString(sqlDataReader["FullName"]);
            physicalPersonEntity.Gender = Convert.ToString(sqlDataReader["Gender"]);
            physicalPersonEntity.DateOfBirth = Convert.ToString(sqlDataReader["DateOfBirth"]);
            physicalPersonEntity.RegistrationOfIndividuals = Convert.ToString(sqlDataReader["RegistrationOfIndividuals"]);
            physicalPersonEntity.Telephone = Convert.ToString(sqlDataReader["Telephone"]);
            physicalPersonEntity.ZipCode = Convert.ToString(sqlDataReader["ZipCode"]);
            physicalPersonEntity.Address = Convert.ToString(sqlDataReader["Address"]);
            physicalPersonEntity.Number = Convert.ToString(sqlDataReader["Number"]);
            physicalPersonEntity.Neighborhood = Convert.ToString(sqlDataReader["Neighborhood"]);
            physicalPersonEntity.City = Convert.ToString(sqlDataReader["City"]);
            physicalPersonEntity.State = Convert.ToString(sqlDataReader["State"]);
            physicalPersonEntity.Email = Convert.ToString(sqlDataReader["Email"]);
            physicalPersonEntity.Password = Convert.ToString(sqlDataReader["Password"]);
            physicalPersonEntity.ConfirmedEmail = Convert.ToBoolean(sqlDataReader["ConfirmedEmail"]);
            physicalPersonEntity.Status = Convert.ToBoolean(sqlDataReader["Status"]);
            physicalPersonEntity.DateInsert = Convert.ToDateTime(sqlDataReader["DateInsert"]);
            physicalPersonEntity.DateUpdate = Convert.ToDateTime(sqlDataReader["DateUpdate"]);
        }

        private static void GetPhysicalPersonInsert_PhysicalPerson(SqlCommand sqlCommand, Domain.Models.PhysicalPerson entity)
        {
            sqlCommand.Parameters.AddWithValue("@FullName", entity.FullName);
            sqlCommand.Parameters.AddWithValue("@Gender", entity.Gender);
            sqlCommand.Parameters.AddWithValue("@DateOfBirth", entity.DateOfBirth);
            sqlCommand.Parameters.AddWithValue("@RegistrationOfIndividuals", entity.RegistrationOfIndividuals);
            sqlCommand.Parameters.AddWithValue("@Telephone", entity.Telephone);
            sqlCommand.Parameters.AddWithValue("@ZipCode", entity.ZipCode);
            sqlCommand.Parameters.AddWithValue("@Address", entity.Address);
            sqlCommand.Parameters.AddWithValue("@Number", entity.Number);
            sqlCommand.Parameters.AddWithValue("@Neighborhood", entity.Neighborhood);
            sqlCommand.Parameters.AddWithValue("@City", entity.City);
            sqlCommand.Parameters.AddWithValue("@State", entity.State);
            sqlCommand.Parameters.AddWithValue("@Email", entity.Email);
            sqlCommand.Parameters.AddWithValue("@Password", entity.Password);
            sqlCommand.Parameters.AddWithValue("@ConfirmedEmail", entity.ConfirmedEmail);
            sqlCommand.Parameters.AddWithValue("@Status", entity.Status);
            sqlCommand.Parameters.AddWithValue("@DateInsert", entity.DateInsert);
            sqlCommand.Parameters.AddWithValue("@DateUpdate", entity.DateUpdate);
        }

        private static void GetPhysicalPersonUpdate_PhysicalPerson(SqlCommand sqlCommand, Domain.Models.PhysicalPerson entity)
        {
            sqlCommand.Parameters.AddWithValue("@Id", entity.PhysicalPersonId);
            sqlCommand.Parameters.AddWithValue("@FullName", entity.FullName);
            sqlCommand.Parameters.AddWithValue("@Gender", entity.Gender);
            sqlCommand.Parameters.AddWithValue("@DateOfBirth", entity.DateOfBirth);
            sqlCommand.Parameters.AddWithValue("@RegistrationOfIndividuals", entity.RegistrationOfIndividuals);
            sqlCommand.Parameters.AddWithValue("@Telephone", entity.Telephone);
            sqlCommand.Parameters.AddWithValue("@ZipCode", entity.ZipCode);
            sqlCommand.Parameters.AddWithValue("@Address", entity.Address);
            sqlCommand.Parameters.AddWithValue("@Number", entity.Number);
            sqlCommand.Parameters.AddWithValue("@Neighborhood", entity.Neighborhood);
            sqlCommand.Parameters.AddWithValue("@City", entity.City);
            sqlCommand.Parameters.AddWithValue("@State", entity.State);
            sqlCommand.Parameters.AddWithValue("@Email", entity.Email);
            sqlCommand.Parameters.AddWithValue("@Password", entity.Password);
            sqlCommand.Parameters.AddWithValue("@ConfirmedEmail", entity.ConfirmedEmail);
            sqlCommand.Parameters.AddWithValue("@Status", entity.Status);
            sqlCommand.Parameters.AddWithValue("@DateInsert", entity.DateInsert);
            sqlCommand.Parameters.AddWithValue("@DateUpdate", entity.DateUpdate);
        }

        private static void GetPhysicalPersonDelete(SqlCommand sqlCommand, int id)
        {
            sqlCommand.Parameters.AddWithValue("@Id", id);
        }

        #endregion
    }
}