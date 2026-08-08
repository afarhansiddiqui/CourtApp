//using AutoMapper;
//using BusinessLayer.DTOs;
//using DataLayer.Entities;
//using DataLayer.Repositories;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace BusinessLayer.Services
//{
//    public class CASEntityService : ICASEntityService
//    {
//        private ICASEntityRepository _casEntityRepository;
//        private IMapper mapper;

//        public CASEntityService(ICASEntityRepository casEntityRepository, IMapper mapper)
//        {
//            _casEntityRepository = casEntityRepository;
//            this.mapper = mapper;
//        }

//        public Task<List<CASEntityGet>> ListAsync()
//        {
//            return Task.FromResult(mapper.Map<List<CASEntityGet>>(_casEntityRepository.List()));
//        }

//        public Task<CASEntityGet> GetByIdAsync(int id)
//        {
//            return Task.FromResult(mapper.Map<CASEntityGet>(_casEntityRepository.GetById(id)));
//        }

//        public Task<CASEntityGet> AddAsync(CASEntityCreate casEntityCreate)
//        {
//            return Task.FromResult(mapper.Map<CASEntityGet>(_casEntityRepository.Add(mapper.Map<CASEntity>(casEntityCreate))));
//        }

//        public Task<CASEntityGet> UpdateAsync(CASEntityUpdate casEntityUpdate)
//        {
//            return Task.FromResult(mapper.Map<CASEntityGet>(_casEntityRepository.Update(mapper.Map<CASEntity>(casEntityUpdate))));
//        }

//        public Task<int> DeleteAsync(int id)
//        {
//            return Task.FromResult((_casEntityRepository.Delete(id)));
//        }
//    }
//}
