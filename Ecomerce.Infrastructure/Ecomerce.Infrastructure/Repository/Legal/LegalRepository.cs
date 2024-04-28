using Ecomerce.Domain.Model;
using Ecomerce.Domain.SeedWork;
using System.Data.SqlClient;
using System.Data;

namespace Ecomerce.Infrastructure.Repository.Legal
{
    public class LegalRepository : BaseRepository, ILegalRepository
    {
        public LegalRepository(ILogger logger) : base(logger) { }

        public async Task DeleteAsync(int id)
        {
            try
            {
                _logger.TraceEntry("Infrastructure_Legal_DeleteAsync");
                _commandText = "USP_Ecomerce_Legal_Delete";
                SqlConnection sqlConnection = new SqlConnection(_connectionString);
                SqlCommand sqlCommand = new SqlCommand(_commandText, sqlConnection);
                GetLegalDelete(sqlCommand, id);
                sqlConnection.Open();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                await sqlCommand.ExecuteNonQueryAsync();
                sqlConnection.Close();
                _logger.TraceExit("Infrastructure_Legal_DeleteAsync");
            }
            catch (ArgumentNullException ex)
            {
                _logger.TraceException("Infrastructure_Legal_DeleteAsync");
                string mensagemErro = "Erro ao consumir a procedure " + _commandText + " , está na camada Infrastructure, Repository, entidade Legal, método DeleteAsync, tipo assíncrono. " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }
        }

        public async Task<List<Domain.Model.Legal>> GetAsync()
        {
            List<Domain.Model.Legal> list = new List<Domain.Model.Legal>();
            try
            {
                _logger.TraceEntry("Infrastructure_Legal_GetAsync");
                _commandText = "USP_Ecomerce_Legal_Get";
                using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand(_commandText, sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();
                    while (sqlDataReader.Read())
                    {
                        GetListLegal_Legal(sqlDataReader, list);
                    }
                }
                _logger.TraceExit("Infrastructure_Legal_GetAsync");

            }
            catch (ArgumentNullException ex)
            {
                _logger.TraceException("Infrastructure_Legal_GetAsync");
                string mensagemErro = "Erro ao consumir a procedure " + _commandText + " , está na camada Infrastructure, Repository, entidade Legal, método Get, tipo assíncrono. " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }
            return list;
        }

        public async Task<Domain.Model.Legal> GetByIdAsync(int id)
        {
            Domain.Model.Legal entity = new Domain.Model.Legal();
            try
            {
                _logger.TraceEntry("Infrastructure_Legal_GetByIdAsync");
                _commandText = "USP_Ecomerce_Legal_GetById";
                using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand(_commandText, sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@Id", id);
                    sqlConnection.Open();
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();
                    while (sqlDataReader.Read())
                    {
                        GetLegal_Legal(sqlDataReader, entity);
                    }
                }
                _logger.TraceExit("Infrastructure_Legal_GetByIdAsync");
            }
            catch (ArgumentNullException ex)
            {
                _logger.TraceException("Infrastructure_Legal_GetByIdAsync");
                string mensagemErro = "Erro ao consumir a procedure " + _commandText + " , está na camada Infrastructure, Repository, entidade Legal, método GetByIdAsync, tipo assíncrono. " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }
            return entity;
        }

        public async Task PostAsync(Domain.Model.Legal entity)
        {
            try
            {
                _logger.TraceEntry("Infrastructure_Legal_PostAsync");
                _commandText = "USP_Ecomerce_Legal_Post";
                SqlConnection sqlConnection = new SqlConnection(_connectionString);
                SqlCommand sqlCommand = new SqlCommand(_commandText, sqlConnection);
                GetLegalInsert_Legal(sqlCommand, entity);
                sqlConnection.Open();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                await sqlCommand.ExecuteNonQueryAsync();
                sqlConnection.Close();
                _logger.TraceExit("Infrastructure_Legal_PostAsync");
            }
            catch (ArgumentNullException ex)
            {
                _logger.TraceException("Infrastructure_Legal_PostAsync");
                string mensagemErro = "Erro ao consumir a procedure " + _commandText + " , está na camada Infrastructure, Repository, entidade Legal, método PostAsync, tipo síncrono. " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }
        }

        public async Task PutAsync(Domain.Model.Legal entity)
        {
            try
            {
                _logger.TraceEntry("Infrastructure_Legal_PutAsync");
                _commandText = "USP_Ecomerce_Legal_Put";
                SqlConnection sqlConnection = new SqlConnection(_connectionString);
                SqlCommand sqlCommand = new SqlCommand(_commandText, sqlConnection);
                GetLegalUpdate_Legal(sqlCommand, entity);
                sqlConnection.Open();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                await sqlCommand.ExecuteNonQueryAsync();
                sqlConnection.Close();
                _logger.TraceExit("Infrastructure_Legal_PutAsync");
            }
            catch (ArgumentNullException ex)
            {
                _logger.TraceException("Infrastructure_Legal_PutAsync");
                string mensagemErro = "Erro ao consumir a procedure " + _commandText + " , está na camada Infrastructure, Repository, entidade Legal, método PutAsync, tipo assíncrono. " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }
        }

        #region Helpers

        private static void GetListLegal_Legal(SqlDataReader sqlDataReader, List<Domain.Model.Legal> listVehicleLegal)
        {
            Domain.Model.Legal LegalEntity = new Domain.Model.Legal();
            GetLegal_Legal(sqlDataReader, LegalEntity);
            listVehicleLegal.Add(LegalEntity);
        }

        private static void GetLegal_Legal(SqlDataReader sqlDataReader, Domain.Model.Legal LegalEntity)
        {
            LegalEntity.LegalId = Convert.ToInt32(sqlDataReader["Id"]);
            LegalEntity.CorporateReason = Convert.ToString(sqlDataReader["CorporateReason"]);
            LegalEntity.FantasyName = Convert.ToString(sqlDataReader["FantasyName"]);
            LegalEntity.Members = Convert.ToString(sqlDataReader["Members"]);
            LegalEntity.Situation = Convert.ToString(sqlDataReader["Situation"]);
            LegalEntity.NationalRegisterOfLegal = Convert.ToString(sqlDataReader["NationalRegisterOfLegal"]);
            LegalEntity.Telephone = Convert.ToString(sqlDataReader["Telephone"]);
            LegalEntity.ZipCode = Convert.ToString(sqlDataReader["ZipCode"]);
            LegalEntity.Address = Convert.ToString(sqlDataReader["Address"]);
            LegalEntity.Number = Convert.ToString(sqlDataReader["Number"]);
            LegalEntity.Neighborhood = Convert.ToString(sqlDataReader["Neighborhood"]);
            LegalEntity.City = Convert.ToString(sqlDataReader["City"]);
            LegalEntity.State = Convert.ToString(sqlDataReader["State"]);
            LegalEntity.Email = Convert.ToString(sqlDataReader["Email"]);
            LegalEntity.Password = Convert.ToString(sqlDataReader["Password"]);
            LegalEntity.ConfirmedEmail = Convert.ToBoolean(sqlDataReader["ConfirmedEmail"]);
            LegalEntity.Status = Convert.ToBoolean(sqlDataReader["Status"]);
            LegalEntity.DateInsert = Convert.ToDateTime(sqlDataReader["DateInsert"]);
            LegalEntity.DateUpdate = Convert.ToDateTime(sqlDataReader["DateUpdate"]);
        }

        private static void GetLegalInsert_Legal(SqlCommand sqlCommand, Domain.Model.Legal entity)
        {
            sqlCommand.Parameters.AddWithValue("@NationalRegisterOfLegal", entity.NationalRegisterOfLegal);
            sqlCommand.Parameters.AddWithValue("@Situation", entity.Situation);
            sqlCommand.Parameters.AddWithValue("@CorporateReason", entity.CorporateReason);
            sqlCommand.Parameters.AddWithValue("@FantasyName", entity.FantasyName);
            sqlCommand.Parameters.AddWithValue("@Members", entity.Members);
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

        private static void GetLegalUpdate_Legal(SqlCommand sqlCommand, Domain.Model.Legal entity)
        {
            sqlCommand.Parameters.AddWithValue("@Id", entity.LegalId);
            sqlCommand.Parameters.AddWithValue("@NationalRegisterOfLegal", entity.NationalRegisterOfLegal);
            sqlCommand.Parameters.AddWithValue("@Situation", entity.Situation);
            sqlCommand.Parameters.AddWithValue("@CorporateReason", entity.CorporateReason);
            sqlCommand.Parameters.AddWithValue("@FantasyName", entity.FantasyName);
            sqlCommand.Parameters.AddWithValue("@Members", entity.Members);
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

        private static void GetLegalDelete(SqlCommand sqlCommand, int id)
        {
            sqlCommand.Parameters.AddWithValue("@Id", id);
        }

        #endregion
    }
}