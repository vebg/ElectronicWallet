using AutoMapper;
using ElectronicWallet.Database.DTO;
using ElectronicWallet.Database.Entities;
using ElectronicWallet.Repositories.Contracts;
using ElectronicWallet.Services.Contracts;
using System;
using System.Threading.Tasks;

namespace ElectronicWallet.Services
{
    public class UserService: ManagementServiceBase<UserDto,User>,IUserService
    {
        public UserService(IUserRepository repository,IMapper mapper):base(repository,mapper)
        {

        }

        public async Task<UserDto> GetByEmailAndPassword(string email, string password)
        {
            UserDto user = null;
            try
            {
                var userSelected = await Repository.FindAsync(x => x.Email.ToLower() == email.ToLower());
                //var passwordHash = _enqcrytionUtils.EncryptPassword(password, userSelected.Salt);

                /*if(passwordHash.Equals(userSelected.PasswordHash))
                {
                    user = Mapper.Map<UserDto>(userSelected);
                }*/
                user = Mapper.Map<UserDto>(userSelected);


            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error finding the user. Exeption {ex}");
            }

            return user;
        }
    }
}
