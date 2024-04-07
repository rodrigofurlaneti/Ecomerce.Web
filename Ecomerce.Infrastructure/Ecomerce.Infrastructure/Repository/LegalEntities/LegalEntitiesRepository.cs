using Ecomerce.Domain.Entities;
using Ecomerce.Domain.SeedWork;
using System.Data.SqlClient;
using System.Data;

namespace Ecomerce.Infrastructure.Repository.LegalEntities
{
    public class LegalEntitiesRepository : BaseRepository, ILegalEntitiesRepository
    {
        public LegalEntitiesRepository(ILogger logger) : base(logger) { }

        public async Task DeleteAsync(int id)
        {
            try
            {
                _logger.TraceEntry("Infrastructure_LegalEntities_DeleteAsync");
                _commandText = "USP_Ecomerce_LegalEntities_Delete";
                SqlConnection sqlConnection = new SqlConnection(_connectionString);
                SqlCommand sqlCommand = new SqlCommand(_commandText, sqlConnection);
                GetLegalEntitiesDelete(sqlCommand, id);
                sqlConnection.Open();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                await sqlCommand.ExecuteNonQueryAsync();
                sqlConnection.Close();
                _logger.TraceExit("Infrastructure_LegalEntities_DeleteAsync");
            }
            catch (ArgumentNullException ex)
            {
                _logger.TraceException("Infrastructure_LegalEntities_DeleteAsync");
                string mensagemErro = "Erro ao consumir a procedure " + _commandText + " , está na camada Infrastructure, Repository, entidade LegalEntities, método DeleteAsync, tipo assíncrono. " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }
        }

        public async Task<List<LegalEntitiesEntity>> GetAsync()
        {
            List<LegalEntitiesEntity> list = new List<LegalEntitiesEntity>();
            try
            {
                _logger.TraceEntry("Infrastructure_LegalEntities_GetAsync");
                _commandText = "USP_Ecomerce_LegalEntities_Get";
                using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand(_commandText, sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();
                    while (sqlDataReader.Read())
                    {
                        GetListLegalEntities_LegalEntities(sqlDataReader, list);
                    }
                }
                _logger.TraceExit("Infrastructure_LegalEntities_GetAsync");

            }
            catch (ArgumentNullException ex)
            {
                _logger.TraceException("Infrastructure_LegalEntities_GetAsync");
                string mensagemErro = "Erro ao consumir a procedure " + _commandText + " , está na camada Infrastructure, Repository, entidade LegalEntities, método Get, tipo assíncrono. " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }
            return list;
        }

        public async Task<LegalEntitiesEntity> GetByIdAsync(int id)
        {
            LegalEntitiesEntity entity = new LegalEntitiesEntity();
            try
            {
                _logger.TraceEntry("Infrastructure_LegalEntities_GetByIdAsync");
                _commandText = "USP_Ecomerce_LegalEntities_GetById";
                using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand(_commandText, sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@Id", id);
                    sqlConnection.Open();
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();
                    while (sqlDataReader.Read())
                    {
                        GetLegalEntities_LegalEntities(sqlDataReader, entity);
                    }
                }
                _logger.TraceExit("Infrastructure_LegalEntities_GetByIdAsync");
            }
            catch (ArgumentNullException ex)
            {
                _logger.TraceException("Infrastructure_LegalEntities_GetByIdAsync");
                string mensagemErro = "Erro ao consumir a procedure " + _commandText + " , está na camada Infrastructure, Repository, entidade LegalEntities, método GetByIdAsync, tipo assíncrono. " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }
            return entity;
        }

        public async Task PostAsync(LegalEntitiesEntity entity)
        {
            try
            {
                _logger.TraceEntry("Infrastructure_LegalEntities_PostAsync");
                _commandText = "USP_Ecomerce_LegalEntities_Post";
                SqlConnection sqlConnection = new SqlConnection(_connectionString);
                SqlCommand sqlCommand = new SqlCommand(_commandText, sqlConnection);
                GetLegalEntitiesInsert_LegalEntities(sqlCommand, entity);
                sqlConnection.Open();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                await sqlCommand.ExecuteNonQueryAsync();
                sqlConnection.Close();
                _logger.TraceExit("Infrastructure_LegalEntities_PostAsync");
            }
            catch (ArgumentNullException ex)
            {
                _logger.TraceException("Infrastructure_LegalEntities_PostAsync");
                string mensagemErro = "Erro ao consumir a procedure " + _commandText + " , está na camada Infrastructure, Repository, entidade LegalEntities, método PostAsync, tipo síncrono. " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }
        }

        public async Task PutAsync(LegalEntitiesEntity entity)
        {
            try
            {
                _logger.TraceEntry("Infrastructure_LegalEntities_PutAsync");
                _commandText = "USP_Ecomerce_LegalEntities_Put";
                SqlConnection sqlConnection = new SqlConnection(_connectionString);
                SqlCommand sqlCommand = new SqlCommand(_commandText, sqlConnection);
                GetLegalEntitiesUpdate_LegalEntities(sqlCommand, entity);
                sqlConnection.Open();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                await sqlCommand.ExecuteNonQueryAsync();
                sqlConnection.Close();
                _logger.TraceExit("Infrastructure_LegalEntities_PutAsync");
            }
            catch (ArgumentNullException ex)
            {
                _logger.TraceException("Infrastructure_LegalEntities_PutAsync");
                string mensagemErro = "Erro ao consumir a procedure " + _commandText + " , está na camada Infrastructure, Repository, entidade LegalEntities, método PutAsync, tipo assíncrono. " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }
        }

        #region Helpers

        private static void GetListLegalEntities_LegalEntities(SqlDataReader sqlDataReader, List<LegalEntitiesEntity> listVehicleLegalEntitiesModel)
        {
            LegalEntitiesEntity legalEntitiesEntity = new LegalEntitiesEntity();
            GetLegalEntities_LegalEntities(sqlDataReader, legalEntitiesEntity);
            listVehicleLegalEntitiesModel.Add(legalEntitiesEntity);
        }

        private static void GetLegalEntities_LegalEntities(SqlDataReader sqlDataReader, LegalEntitiesEntity legalEntitiesEntity)
        {
            legalEntitiesEntity.Id = Convert.ToInt32(sqlDataReader["Id"]);
            legalEntitiesEntity.CorporateReason = Convert.ToString(sqlDataReader["CorporateReason"]);
            legalEntitiesEntity.FantasyName = Convert.ToString(sqlDataReader["FantasyName"]);
            legalEntitiesEntity.Members = Convert.ToString(sqlDataReader["Members"]);
            legalEntitiesEntity.Situation = Convert.ToString(sqlDataReader["Situation"]);
            legalEntitiesEntity.NationalRegisterOfLegalEntities = Convert.ToString(sqlDataReader["NationalRegisterOfLegalEntities"]);
            legalEntitiesEntity.Telephone = Convert.ToString(sqlDataReader["Telephone"]);
            legalEntitiesEntity.ZipCode = Convert.ToString(sqlDataReader["ZipCode"]);
            legalEntitiesEntity.Address = Convert.ToString(sqlDataReader["Address"]);
            legalEntitiesEntity.Number = Convert.ToString(sqlDataReader["Number"]);
            legalEntitiesEntity.Neighborhood = Convert.ToString(sqlDataReader["Neighborhood"]);
            legalEntitiesEntity.City = Convert.ToString(sqlDataReader["City"]);
            legalEntitiesEntity.State = Convert.ToString(sqlDataReader["State"]);
            legalEntitiesEntity.Email = Convert.ToString(sqlDataReader["Email"]);
            legalEntitiesEntity.Password = Convert.ToString(sqlDataReader["Password"]);
            legalEntitiesEntity.ConfirmedEmail = Convert.ToBoolean(sqlDataReader["ConfirmedEmail"]);
            legalEntitiesEntity.Status = Convert.ToBoolean(sqlDataReader["Status"]);
            legalEntitiesEntity.DateInsert = Convert.ToDateTime(sqlDataReader["DateInsert"]);
            legalEntitiesEntity.DateUpdate = Convert.ToDateTime(sqlDataReader["DateUpdate"]);
        }

        private static void GetLegalEntitiesInsert_LegalEntities(SqlCommand sqlCommand, LegalEntitiesEntity entity)
        {
            sqlCommand.Parameters.AddWithValue("@NationalRegisterOfLegalEntities", entity.NationalRegisterOfLegalEntities);
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

        private static void GetLegalEntitiesUpdate_LegalEntities(SqlCommand sqlCommand, LegalEntitiesEntity entity)
        {
            sqlCommand.Parameters.AddWithValue("@Id", entity.Id);
            sqlCommand.Parameters.AddWithValue("@NationalRegisterOfLegalEntities", entity.NationalRegisterOfLegalEntities);
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

        private static void GetLegalEntitiesDelete(SqlCommand sqlCommand, int id)
        {
            sqlCommand.Parameters.AddWithValue("@Id", id);
        }

        #endregion
    }
}