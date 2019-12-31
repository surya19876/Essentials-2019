using GroundBooking.Repository.DbContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace GroundBooking.Repository.IRepository
{
    public interface IGroundRepository
    {
        List<Grounds> GetGrounds();
        Grounds GetGroundById(int id);
        void AddGround(Grounds ground);
    }
}
