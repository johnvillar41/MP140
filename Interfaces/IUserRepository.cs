using MP140.Models;
using System.Collections.Generic;

namespace MP140.Interfaces
{
    public interface IUserRepository
    {
        List<UserModel> FetchAllUsersInAGivenRoom(int roomID);
    }
}