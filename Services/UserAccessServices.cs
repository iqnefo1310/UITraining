using UITraining.Models.Db;
using UITraining.Models.DTO;
using UITraining.Models;
using UITraining.Interfaces;

namespace UITraining.Services
{
    public class UserAccessServices : IUserAccess
    {
        private readonly ApplicationContext _conteks;


        public UserAccessServices(ApplicationContext conteks)
        {
            _conteks = conteks;
        }

        public bool InsertUserAccess(UserAccsessDTO dto)
        {
            var user = new UserAccess
            {
                Name = dto.Name,
                Username = dto.Username,
                Password = dto.Password,
                AccessDate = DateTime.Now,
                UserStatus = GeneralStatus.GeneralStatusData.published,
            };

            _conteks.Add(user);
            _conteks.SaveChanges();

            return true;
        }

    }
}
