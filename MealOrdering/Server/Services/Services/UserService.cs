using AutoMapper;
using AutoMapper.QueryableExtensions;
using MealOrdering.Server.Data.Contexts;
using MealOrdering.Server.Data.Models;
using MealOrdering.Server.Services.Infrastructure;
using MealOrdering.Shared.DTOs;
using Microsoft.EntityFrameworkCore;

namespace MealOrdering.Server.Services.Services
{
    public class UserService : IUserService
    {
        private IMapper _mapper;
        private MealOrderingDbContext _context;
        public UserService(IMapper mapper, MealOrderingDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<UserDTO> CreateUser(UserDTO userDTO)
        {
            User user = await _context.Users.Where(u => u.Id == userDTO.Id).FirstOrDefaultAsync();

            if (user != null)
                throw new Exception("İlgili Kayıt Zaten Mevcut");

            user = _mapper.Map<User>(userDTO);

            await _context.Users.AddAsync(user);
            int result = await _context.SaveChangesAsync();
            return _mapper.Map<UserDTO>(user);
        }

        public async Task<bool> DeleteUserById(Guid id)
        {
            User user = await _context.Users.Where(u => u.Id == id).FirstOrDefaultAsync();

            if (user == null)
                throw new Exception("Kullanıcı Bulunamadı");

            _context.Users.Remove(user);
            int result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<UserDTO> GetUserById(Guid id)
        {
            return await _context.Users
                        .Where(u => u.Id == id)
                        .ProjectTo<UserDTO>(_mapper.ConfigurationProvider)
                        .FirstOrDefaultAsync();
        }

        public async Task<List<UserDTO>> GetUsers()
        {
            return await _context.Users
                         .Where(u => u.IsActive)
                         .ProjectTo<UserDTO>(_mapper.ConfigurationProvider)
                         .ToListAsync();
        }

        public async Task<UserDTO> UpdateUser(UserDTO userDTO)
        {
            User user = await _context.Users.Where(u => u.Id == userDTO.Id).FirstOrDefaultAsync();

            if (user == null)
                throw new Exception("İlgili Kayıt Bulunamadı");

            //user = _mapper.Map<User>(userDTO);
            _mapper.Map(userDTO, user);
            int result = await _context.SaveChangesAsync();
            return _mapper.Map<UserDTO>(user);
        }
    }
}
