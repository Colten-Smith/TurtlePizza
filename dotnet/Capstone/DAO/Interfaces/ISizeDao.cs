using Capstone.Models;
using System.Collections.Generic;
using System.IO.Compression;

namespace Capstone.DAO.Interfaces
{
    public interface ISizeDao
    {
        //Create
        public Size AddNewSize(NewSize sizeToAdd);
        //Retrieve
        public Size GetSizeByID(int id);
        public List<Size> GetAllSizes();
        public Size UpdateSize(Size sizeToUpdate);
        public Size MakeAvailable(int id);
        public Size MakeUnavailable(int id);
        //Delete
        //Helper
    }
}
