using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class CastService : ICastService
    {
        private readonly ICastRepository _castService;

        public CastService(ICastRepository castService)
        {
            _castService = castService;
        }
        public async Task<CastResponseModel> GetCastDetails(int id)
        {
            var castDetail = await _castService.GetById(id);

            var castModels = new CastResponseModel();
            {
                castModels.Id = castDetail.Id;
                castModels.Name = castDetail.Name;
                castModels.Gender = castDetail.Gender;
                castModels.TmdbUrl = castDetail.TmdbUrl;
                castModels.ProfilePath = castDetail.ProfilePath;


//Gender
//TmdbUrl
//ProfilePath
            };

            
            return castModels;
        }

        Task<CastModel> ICastService.GetCastDetails(int id)
        {
            throw new NotImplementedException();
        }
    }

}