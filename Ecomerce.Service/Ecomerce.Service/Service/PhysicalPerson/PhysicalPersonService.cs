using Ecomerce.Domain.Entities;
using Ecomerce.Domain.SeedWork;
using Ecomerce.Infrastructure.Repository.PhysicalPerson;

namespace Ecomerce.Service.Service.PhysicalPerson
{
    public class PhysicalPersonService : BaseService, IPhysicalPersonService
    {
        #region Property

        public readonly IPhysicalPersonRepository _physicalPersonRepository;


        #endregion

        #region Constructor

        public PhysicalPersonService(ILogger logger, IPhysicalPersonRepository physicalPersonRepository) : base(logger)
        {
            _physicalPersonRepository = physicalPersonRepository;
        }

        #endregion

        #region Methods

        public async Task DeleteAsync(int id)
        {
            try
            {
                this._logger.TraceEntry("Service_PhysicalPerson_DeleteAsync");
                await _physicalPersonRepository.DeleteAsync(id);
                this._logger.TraceExit("Service_PhysicalPerson_DeleteAsync");
            }
            catch (ArgumentNullException ex)
            {
                this._logger.TraceException("Service_PhysicalPerson_Delete");
                string mensagemErro = "Erro ao consumir a camada Service, entidade PhysicalPerson, método DeleteAsync, tipo assíncrono " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }
        }

        public async Task<List<PhysicalPersonEntity>> GetAsync()
        {
            try
            {
                this._logger.TraceEntry("Service_PhysicalPerson_GetAsync");
                var ret = await _physicalPersonRepository.GetAsync();
                this._logger.TraceExit("Service_PhysicalPerson_GetAsync");
                return ret;
            }
            catch (ArgumentNullException ex)
            {
                this._logger.TraceException("Service_PhysicalPerson_GetAsync");
                string mensagemErro = "Erro ao consumir a camada Service, entidade PhysicalPerson, método GetAsync, tipo assíncrono " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }
        }

        public async Task<PhysicalPersonEntity> GetByIdAsync(int id)
        {
            try
            {
                this._logger.TraceEntry("Service_PhysicalPerson_GetByIdAsync");
                var ret = await _physicalPersonRepository.GetByIdAsync(id);
                this._logger.TraceExit("Service_PhysicalPerson_GetByIdAsync");
                return ret;
            }
            catch (ArgumentNullException ex)
            {
                this._logger.TraceException("Service_PhysicalPerson_GetByIdAsync");
                string mensagemErro = "Erro ao consumir a camada Service, entidade PhysicalPerson, método GetByIdAsync, tipo assíncrono " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }
        }

        public async Task PostAsync(PhysicalPersonEntity entity)
        {
            try
            {
                this._logger.TraceEntry("Service_PhysicalPerson_PostAsync");
                await _physicalPersonRepository.PostAsync(entity);
                this._logger.TraceExit("Service_PhysicalPerson_PostAsync");
            }
            catch (ArgumentNullException ex)
            {
                this._logger.TraceException("Service_PhysicalPerson_PostAsync");
                string mensagemErro = "Erro ao consumir a camada Service, entidade PhysicalPerson, método PostAsync, tipo assíncrono " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }
        }

        public async Task PutAsync(PhysicalPersonEntity entity)
        {
            try
            {
                this._logger.TraceEntry("Service_PhysicalPerson_PutAsync");
                await _physicalPersonRepository.PutAsync(entity);
                this._logger.TraceExit("Service_PhysicalPerson_PutAsync");
            }
            catch (ArgumentNullException ex)
            {
                this._logger.TraceException("Service_PhysicalPerson_PutAsync");
                string mensagemErro = "Erro ao consumir a camada Service, entidade PhysicalPerson, método PutAsync, tipo assíncrono " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }
        }

        #endregion
    }
}