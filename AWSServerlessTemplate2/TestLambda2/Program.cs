using GroundBooking.Repository.DbContext;
using GroundBooking.Repository.IRepository;
using GroundBooking.Repository.Repository;
using System;

namespace TestLambda2
{
    class Program
    {
        static void Main(string[] args)
        {
            IGroundRepository groundRepository = new GroundRepository();
            groundRepository.AddGround(new Grounds
            {
                ID = 4,
                GroundName = "Royal Grass"
            });
        }
    }
}
