using Ecomerce.Domain.Entities;
using Ecomerce.Domain.SeedWork;
using Ecomerce.Infrastructure.Repository.Profile;

namespace Ecomerce.Service.Service.Profile
{
    public class ProfileService : BaseService, IProfileService
    {
        #region Property

        public readonly IProfileRepository _profileRepository;


        #endregion

        #region Constructor

        public ProfileService(ILogger logger, IProfileRepository profileRepository) : base(logger)
        {
            _profileRepository = profileRepository;
        }

        #endregion

        #region Methods

        public async Task DeleteAsync(int id)
        {
            try
            {
                this._logger.TraceEntry("Service_Profile_DeleteAsync");
                await _profileRepository.DeleteAsync(id);
                this._logger.TraceExit("Service_Profile_DeleteAsync");
            }
            catch (ArgumentNullException ex)
            {
                this._logger.TraceException("Service_Profile_Delete");
                string mensagemErro = "Erro ao consumir a camada Service, entidade Profile, método DeleteAsync, tipo assíncrono " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }
        }

        public async Task<List<ProfileEntity>> GetAsync()
        {
            try
            {
                this._logger.TraceEntry("Service_Profile_GetAsync");
                var ret = await _profileRepository.GetAsync();
                this._logger.TraceExit("Service_Profile_GetAsync");
                return ret;
            }
            catch (ArgumentNullException ex)
            {
                this._logger.TraceException("Service_Profile_GetAsync");
                string mensagemErro = "Erro ao consumir a camada Service, entidade Profile, método GetAsync, tipo assíncrono " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }
        }

        public async Task<ProfileEntity> GetByIdAsync(int id)
        {
            try
            {
                this._logger.TraceEntry("Service_Profile_GetByIdAsync");
                var ret = await _profileRepository.GetByIdAsync(id);
                this._logger.TraceExit("Service_Profile_GetByIdAsync");
                return ret;
            }
            catch (ArgumentNullException ex)
            {
                this._logger.TraceException("Service_Profile_GetByIdAsync");
                string mensagemErro = "Erro ao consumir a camada Service, entidade Profile, método GetByIdAsync, tipo assíncrono " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }
        }

        public async Task PostAsync(ProfileEntity entity)
        {
            try
            {
                this._logger.TraceEntry("Service_Profile_PostAsync");
                await _profileRepository.PostAsync(entity);
                this._logger.TraceExit("Service_Profile_PostAsync");
            }
            catch (ArgumentNullException ex)
            {
                this._logger.TraceException("Service_Profile_PostAsync");
                string mensagemErro = "Erro ao consumir a camada Service, entidade Profile, método PostAsync, tipo assíncrono " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }
        }

        public async Task PutAsync(ProfileEntity entity)
        {
            try
            {
                this._logger.TraceEntry("Service_Profile_PutAsync");
                await _profileRepository.PutAsync(entity);
                this._logger.TraceExit("Service_Profile_PutAsync");
            }
            catch (ArgumentNullException ex)
            {
                this._logger.TraceException("Service_Profile_PutAsync");
                string mensagemErro = "Erro ao consumir a camada Service, entidade Profile, método PutAsync, tipo assíncrono " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }
        }

        #endregion
    }
}