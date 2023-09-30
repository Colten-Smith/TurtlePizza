using Capstone.Models;
using System.Collections.Generic;

namespace Capstone.DAO.Interfaces
{
    public interface ISideDao
    {
        //Create
        public Side AddNewSide(NewSide sideToAdd);
        //Retrieve
        public List<Side> GetSidesByOrderId(int orderId);
        public Side GetSideByID(int id);
        public List<Side> GetAllSides(bool isWing);
        //Update
        public Side UpdateSide(Side sideToUpdate);
        public Side MakeSideAvailable(int id);
        public Side MakeSideUnavailable(int id);
        //Delete
        public int DeleteSideByID(int id);
    }
}
