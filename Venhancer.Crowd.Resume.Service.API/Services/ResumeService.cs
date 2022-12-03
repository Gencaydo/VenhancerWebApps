using AutoMapper;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Runtime.CompilerServices;
using Venhancer.Crowd.Identity.Shared.Dtos;
using Venhancer.Crowd.Resume.Service.API.AppSettings;
using Venhancer.Crowd.Resume.Service.API.Dtos;
using Venhancer.Crowd.Resume.Service.API.Models;

namespace Venhancer.Crowd.Resume.Service.API.Services
{
    public class ResumeService : IResumeService
    {
        private readonly IMongoCollection<ResumeEntity> _resumeCollection;
        private readonly IMapper _mapper;

        public ResumeService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DBName);

            _resumeCollection = database.GetCollection<ResumeEntity>(databaseSettings.ResumeCollection);
            _mapper = mapper;
        }
        public async Task<Response<NoDataDto>> CreateAsync(ResumeDto resumeDto)
        {
            try
            {
                var resume = _mapper.Map<ResumeEntity>(resumeDto);
                await _resumeCollection.InsertOneAsync(resume);
            }
            catch (Exception ex)
            {
                Response<NoDataDto>.Fail(ex.Message, 404, true);
            }
            return Response<NoDataDto>.Success(200);
        }

        public Task<Response<List<ResumeDto>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Response<ResumeDto>> GetByFirstNameAsync(string firstName)
        {
            var resumeobject = await _resumeCollection.Find(x => x.PersonelInformations.Any(t => t.FirstName == firstName)).ToListAsync();
            if (resumeobject == null) Response<ResumeDto>.Fail("", 404, true);
            return Response<ResumeDto>.Success(_mapper.Map<ResumeDto>(resumeobject), 200);
        }
    }
}
