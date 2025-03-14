using UITraining.Models;
using UITraining.Models.DTO;

namespace UITraining.Interfaces
{
    public interface IUserAccess
    {
        public bool InsertUserAccess(UserAccsessDTO dto);
    }
}
