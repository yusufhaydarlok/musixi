using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using musixi_core.DTOs;
using musixi_core.Models;
using musixi_core.Repositories;
using musixi_core.Services;
using musixi_core.UnitOfWorks;
using musixi_service.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace musixi_caching
{
    public class UserServiceWithCaching : IUserService
    {
        private const string CacheUserKey = "usersCache";
        private readonly IMapper _mapper;
        private readonly IMemoryCache _memoryCache;
        private readonly IUserRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public UserServiceWithCaching(IUnitOfWork unitOfWork, IUserRepository repository, IMemoryCache memoryCache, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _memoryCache = memoryCache;
            _mapper = mapper;

            if (!_memoryCache.TryGetValue(CacheUserKey, out _))
            {
                _memoryCache.Set(CacheUserKey, _repository.GetUsersWithRole().Result);
            }


        }

        public async Task<User> AddAsync(User entity)
        {
            await _repository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
            await CacheAllUsersAsync();
            return entity;
        }

        public async Task<IEnumerable<User>> AddRangeAsync(IEnumerable<User> entities)
        {
            await _repository.AddRangeAsync(entities);
            await _unitOfWork.CommitAsync();
            await CacheAllUsersAsync();
            return entities;
        }

        public Task<bool> AnyAsync(Expression<Func<User, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAllAsync()
        {
            var users = _memoryCache.Get<IEnumerable<User>>(CacheUserKey);
            return Task.FromResult(users); throw new NotImplementedException();
        }

        public Task<User> GetByIdAsync(int id)
        {
            var user = _memoryCache.Get<List<User>>(CacheUserKey).FirstOrDefault(x => x.Id == id);

            if (user == null)
            {
                throw new NotFoundExcepiton($"{typeof(User).Name}({id}) not found");
            }

            return Task.FromResult(user);
        }

        public Task<CustomResponseDto<List<UserWithRoleDto>>> GetUsersWithRole()
        {
            var users = _memoryCache.Get<IEnumerable<User>>(CacheUserKey);

            var usersWithCategoryDto = _mapper.Map<List<UserWithRoleDto>>(users);

            return Task.FromResult(CustomResponseDto<List<UserWithRoleDto>>.Success(200, usersWithCategoryDto));
        }

        public async Task RemoveAsync(User entity)
        {
            _repository.Remove(entity);
            await _unitOfWork.CommitAsync();
            await CacheAllUsersAsync();
        }

        public async Task RemoveRangeAsync(IEnumerable<User> entities)
        {
            _repository.RemoveRange(entities);
            await _unitOfWork.CommitAsync();
            await CacheAllUsersAsync();
        }

        public async Task UpdateAsync(User entity)
        {
            _repository.Update(entity);
            await _unitOfWork.CommitAsync();
            await CacheAllUsersAsync();
        }

        public IQueryable<User> Where(Expression<Func<User, bool>> expression)
        {
            return _memoryCache.Get<List<User>>(CacheUserKey).Where(expression.Compile()).AsQueryable();
        }

        public async Task CacheAllUsersAsync()
        {
            _memoryCache.Set(CacheUserKey, await _repository.GetAll().ToListAsync());
        }
    }
}
