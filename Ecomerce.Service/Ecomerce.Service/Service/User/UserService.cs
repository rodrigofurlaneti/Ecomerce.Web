using Ecomerce.Domain.SeedWork;
using Ecomerce.Infrastructure.Repository.User;

namespace Ecomerce.Service.Service.User
{
    public class UserService : BaseService, IUserService
    {
        #region Property

        public readonly IUserRepository _userRepository;


        #endregion

        #region Constructor

        public UserService(ILogger logger, IUserRepository userRepository) : base(logger)
        {
            _userRepository = userRepository;
        }

        #endregion

        #region Methods

        public async Task DeleteAsync(int id)
        {
            try
            {
                this._logger.TraceEntry("Service_User_DeleteAsync");
                await _userRepository.DeleteAsync(id);
                this._logger.TraceExit("Service_User_DeleteAsync");
            }
            catch (ArgumentNullException ex)
            {
                this._logger.TraceException("Service_User_Delete");
                string mensagemErro = "Erro ao consumir a camada Service, entidade User, método DeleteAsync, tipo assíncrono " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }
        }

        public async Task<List<Domain.Models.User>> GetAsync()
        {
            try
            {
                this._logger.TraceEntry("Service_User_GetAsync");
                var ret = await _userRepository.GetAsync();
                this._logger.TraceExit("Service_User_GetAsync");
                return ret;
            }
            catch (ArgumentNullException ex)
            {
                this._logger.TraceException("Service_User_GetAsync");
                string mensagemErro = "Erro ao consumir a camada Service, entidade User, método GetAsync, tipo assíncrono " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }
        }

        public async Task<Domain.Models.User> GetByIdAsync(int id)
        {
            try
            {
                this._logger.TraceEntry("Service_User_GetByIdAsync");
                var ret = await _userRepository.GetByIdAsync(id);
                this._logger.TraceExit("Service_User_GetByIdAsync");
                return ret;
            }
            catch (ArgumentNullException ex)
            {
                this._logger.TraceException("Service_User_GetByIdAsync");
                string mensagemErro = "Erro ao consumir a camada Service, entidade User, método GetByIdAsync, tipo assíncrono " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }
        }

        public async Task PostAsync(Domain.Models.User entity)
        {
            try
            {
                this._logger.TraceEntry("Service_User_PostAsync");
                await _userRepository.PostAsync(entity);
                this._logger.TraceExit("Service_User_PostAsync");
            }
            catch (ArgumentNullException ex)
            {
                this._logger.TraceException("Service_User_PostAsync");
                string mensagemErro = "Erro ao consumir a camada Service, entidade User, método PostAsync, tipo assíncrono " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }
        }

        public async Task PutAsync(Domain.Models.User entity)
        {
            try
            {
                this._logger.TraceEntry("Service_User_PutAsync");
                await _userRepository.PutAsync(entity);
                this._logger.TraceExit("Service_User_PutAsync");
            }
            catch (ArgumentNullException ex)
            {
                this._logger.TraceException("Service_User_PutAsync");
                string mensagemErro = "Erro ao consumir a camada Service, entidade User, método PutAsync, tipo assíncrono " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }
        }

        #endregion
    }
}