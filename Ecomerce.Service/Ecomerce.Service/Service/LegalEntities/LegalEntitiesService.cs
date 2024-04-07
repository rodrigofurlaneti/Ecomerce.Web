using Ecomerce.Domain.Entities;
using Ecomerce.Domain.SeedWork;
using Ecomerce.Infrastructure.Repository.LegalEntities;

namespace Ecomerce.Service.Service.LegalEntities
{
    public class LegalEntitiesService : BaseService, ILegalEntitiesService
    {
        #region Property

        public readonly ILegalEntitiesRepository _legalEntitiesRepository;


        #endregion

        #region Constructor

        public LegalEntitiesService(ILogger logger, ILegalEntitiesRepository legalEntitiesRepository) : base(logger)
        {
            _legalEntitiesRepository = legalEntitiesRepository;
        }

        #endregion

        #region Methods

        public async Task DeleteAsync(int id)
        {
            try
            {
                this._logger.TraceEntry("Service_LegalEntities_DeleteAsync");
                await _legalEntitiesRepository.DeleteAsync(id);
                this._logger.TraceExit("Service_LegalEntities_DeleteAsync");
            }
            catch (ArgumentNullException ex)
            {
                this._logger.TraceException("Service_LegalEntities_Delete");
                string mensagemErro = "Erro ao consumir a camada Service, entidade LegalEntities, método DeleteAsync, tipo assíncrono " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }
        }

        public async Task<List<LegalEntitiesEntity>> GetAsync()
        {
            try
            {
                this._logger.TraceEntry("Service_LegalEntities_GetAsync");
                var ret = await _legalEntitiesRepository.GetAsync();
                this._logger.TraceExit("Service_LegalEntities_GetAsync");
                return ret;
            }
            catch (ArgumentNullException ex)
            {
                this._logger.TraceException("Service_LegalEntities_GetAsync");
                string mensagemErro = "Erro ao consumir a camada Service, entidade LegalEntities, método GetAsync, tipo assíncrono " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }
        }

        public async Task<LegalEntitiesEntity> GetByIdAsync(int id)
        {
            try
            {
                this._logger.TraceEntry("Service_LegalEntities_GetByIdAsync");
                var ret = await _legalEntitiesRepository.GetByIdAsync(id);
                this._logger.TraceExit("Service_LegalEntities_GetByIdAsync");
                return ret;
            }
            catch (ArgumentNullException ex)
            {
                this._logger.TraceException("Service_LegalEntities_GetByIdAsync");
                string mensagemErro = "Erro ao consumir a camada Service, entidade LegalEntities, método GetByIdAsync, tipo assíncrono " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }
        }

        public async Task PostAsync(LegalEntitiesEntity entity)
        {
            try
            {
                this._logger.TraceEntry("Service_LegalEntities_PostAsync");
                await _legalEntitiesRepository.PostAsync(entity);
                this._logger.TraceExit("Service_LegalEntities_PostAsync");
            }
            catch (ArgumentNullException ex)
            {
                this._logger.TraceException("Service_LegalEntities_PostAsync");
                string mensagemErro = "Erro ao consumir a camada Service, entidade LegalEntities, método PostAsync, tipo assíncrono " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }
        }

        public async Task PutAsync(LegalEntitiesEntity entity)
        {
            try
            {
                this._logger.TraceEntry("Service_LegalEntities_PutAsync");
                await _legalEntitiesRepository.PutAsync(entity);
                this._logger.TraceExit("Service_LegalEntities_PutAsync");
            }
            catch (ArgumentNullException ex)
            {
                this._logger.TraceException("Service_LegalEntities_PutAsync");
                string mensagemErro = "Erro ao consumir a camada Service, entidade LegalEntities, método PutAsync, tipo assíncrono " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }
        }

        #endregion
    }
}