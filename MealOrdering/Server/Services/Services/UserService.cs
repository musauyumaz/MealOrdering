using AutoMapper;
using AutoMapper.QueryableExtensions;
using MealOrdering.Server.Data.Contexts;
using MealOrdering.Server.Data.Models;
using MealOrdering.Server.Services.Infrastructure;
using MealOrdering.Shared.DTO;
using Microsoft.EntityFrameworkCore;

namespace MealOrdering.Server.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly MealOrderingDbContext _context;

        public UserService(IMapper mapper, MealOrderingDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<UserDTO> CreateUser(UserDTO userDTO)
        {
            var user = _mapper.Map<User>(userDTO);
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return _mapper.Map<UserDTO>(user);
        }

        public async Task<bool> DeleteUserById(Guid id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
                throw new Exception("Kullanıcı Bulunamadı");
            _context.Users.Remove(user);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<UserDTO> GetUserById(Guid id)
        {
            return await _context.Users.ProjectTo<UserDTO>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<List<UserDTO>> GetUsers()
        {
            return await _context.Users.Where(u => u.IsActive).ProjectTo<UserDTO>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<UserDTO> UpdateUser(UserDTO userDTO)
        {
            var user = await _context.Users.FindAsync(userDTO.Id);
            if (user == null)
                throw new Exception("İlgili Kayıt Bulunamadı");

            _mapper.Map(userDTO, user);
            await _context.SaveChangesAsync();
            return _mapper.Map<UserDTO>(user);
        }
    }
}
