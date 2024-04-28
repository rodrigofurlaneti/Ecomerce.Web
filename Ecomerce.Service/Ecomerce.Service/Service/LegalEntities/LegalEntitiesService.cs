using Ecomerce.Domain.SeedWork;
using Ecomerce.Infrastructure.Repository.Legal;

namespace Ecomerce.Service.Service.Legal
{
    public class LegalService : BaseService, ILegalService
    {
        #region Property

        public readonly ILegalRepository _legalRepository;


        #endregion

        #region Constructor

        public LegalService(ILogger logger, ILegalRepository LegalRepository) : base(logger)
        {
            _legalRepository = LegalRepository;
        }

        #endregion

        #region Methods

        public async Task DeleteAsync(int id)
        {
            try
            {
                this._logger.TraceEntry("Service_Legal_DeleteAsync");
                await _legalRepository.DeleteAsync(id);
                this._logger.TraceExit("Service_Legal_DeleteAsync");
            }
            catch (ArgumentNullException ex)
            {
                this._logger.TraceException("Service_Legal_Delete");
                string mensagemErro = "Erro ao consumir a camada Service, entidade Legal, método DeleteAsync, tipo assíncrono " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }
        }

        public async Task<List<Domain.Models.Legal>> GetAsync()
        {
            try
            {
                this._logger.TraceEntry("Service_Legal_GetAsync");
                var ret = await _legalRepository.GetAsync();
                this._logger.TraceExit("Service_Legal_GetAsync");
                return ret;
            }
            catch (ArgumentNullException ex)
            {
                this._logger.TraceException("Service_Legal_GetAsync");
                string mensagemErro = "Erro ao consumir a camada Service, entidade Legal, método GetAsync, tipo assíncrono " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }
        }

        public async Task<Domain.Models.Legal> GetByIdAsync(int id)
        {
            try
            {
                this._logger.TraceEntry("Service_Legal_GetByIdAsync");
                var ret = await _legalRepository.GetByIdAsync(id);
                this._logger.TraceExit("Service_Legal_GetByIdAsync");
                return ret;
            }
            catch (ArgumentNullException ex)
            {
                this._logger.TraceException("Service_Legal_GetByIdAsync");
                string mensagemErro = "Erro ao consumir a camada Service, entidade Legal, método GetByIdAsync, tipo assíncrono " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }
        }

        public async Task PostAsync(Domain.Models.Legal entity)
        {
            try
            {
                this._logger.TraceEntry("Service_Legal_PostAsync");
                await _legalRepository.PostAsync(entity);
                this._logger.TraceExit("Service_Legal_PostAsync");
            }
            catch (ArgumentNullException ex)
            {
                this._logger.TraceException("Service_Legal_PostAsync");
                string mensagemErro = "Erro ao consumir a camada Service, entidade Legal, método PostAsync, tipo assíncrono " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }
        }

        public async Task PutAsync(Domain.Models.Legal entity)
        {
            try
            {
                this._logger.TraceEntry("Service_Legal_PutAsync");
                await _legalRepository.PutAsync(entity);
                this._logger.TraceExit("Service_Legal_PutAsync");
            }
            catch (ArgumentNullException ex)
            {
                this._logger.TraceException("Service_Legal_PutAsync");
                string mensagemErro = "Erro ao consumir a camada Service, entidade Legal, método PutAsync, tipo assíncrono " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }
        }

        #endregion
    }
}