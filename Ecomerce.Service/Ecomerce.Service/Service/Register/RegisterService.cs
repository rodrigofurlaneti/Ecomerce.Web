using Ecomerce.Domain.Entities;
using Ecomerce.Domain.SeedWork;
using Ecomerce.Infrastructure.Repository.Register;

namespace Ecomerce.Service.Service.Register
{
    public class RegisterService : BaseService, IRegisterService
    {
        #region Property

        public readonly IRegisterRepository _registerRepository;


        #endregion

        #region Constructor

        public RegisterService(ILogger logger, IRegisterRepository registerRepository) : base(logger)
        {
            _registerRepository = registerRepository;
        }

        #endregion

        #region Methods

        public async Task DeleteAsync(int id)
        {
            try
            {
                this._logger.TraceEntry("Service_Register_DeleteAsync");
                await _registerRepository.DeleteAsync(id);
                this._logger.TraceExit("Service_Register_DeleteAsync");
            }
            catch (ArgumentNullException ex)
            {
                this._logger.TraceException("Service_Register_Delete");
                string mensagemErro = "Erro ao consumir a camada Service, entidade Register, método DeleteAsync, tipo assíncrono " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }
        }

        public async Task<List<RegisterEntity>> GetAsync()
        {
            try
            {
                this._logger.TraceEntry("Service_Register_GetAsync");
                var ret = await _registerRepository.GetAsync();
                this._logger.TraceExit("Service_Register_GetAsync");
                return ret;
            }
            catch (ArgumentNullException ex)
            {
                this._logger.TraceException("Service_Register_GetAsync");
                string mensagemErro = "Erro ao consumir a camada Service, entidade Register, método GetAsync, tipo assíncrono " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }
        }

        public async Task<RegisterEntity> GetByIdAsync(int id)
        {
            try
            {
                this._logger.TraceEntry("Service_Register_GetByIdAsync");
                var ret = await _registerRepository.GetByIdAsync(id);
                this._logger.TraceExit("Service_Register_GetByIdAsync");
                return ret;
            }
            catch (ArgumentNullException ex)
            {
                this._logger.TraceException("Service_Register_GetByIdAsync");
                string mensagemErro = "Erro ao consumir a camada Service, entidade Register, método GetByIdAsync, tipo assíncrono " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }
        }

        public async Task PostAsync(RegisterEntity entity)
        {
            try
            {
                this._logger.TraceEntry("Service_Register_PostAsync");
                await _registerRepository.PostAsync(entity);
                this._logger.TraceExit("Service_Register_PostAsync");
            }
            catch (ArgumentNullException ex)
            {
                this._logger.TraceException("Service_Register_PostAsync");
                string mensagemErro = "Erro ao consumir a camada Service, entidade Register, método PostAsync, tipo assíncrono " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }
        }

        public async Task PutAsync(RegisterEntity entity)
        {
            try
            {
                this._logger.TraceEntry("Service_Register_PutAsync");
                await _registerRepository.PutAsync(entity);
                this._logger.TraceExit("Service_Register_PutAsync");
            }
            catch (ArgumentNullException ex)
            {
                this._logger.TraceException("Service_Register_PutAsync");
                string mensagemErro = "Erro ao consumir a camada Service, entidade Register, método PutAsync, tipo assíncrono " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }
        }

        #endregion
    }
}