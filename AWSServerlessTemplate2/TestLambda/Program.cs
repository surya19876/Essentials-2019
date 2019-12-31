using GroundBooking.Repository.DbContext;
using GroundBooking.Repository.IRepository;
using GroundBooking.Repository.Repository;
using System;

namespace TestLambda
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                IGroundRepository groundRepository = new GroundRepository();
                groundRepository.AddGround(new Grounds
                {
                    ID = "4",
                    GroundName = "Royal Grass"
                });
            }
            catch(Exception e)
            {

            }
        }
    }
}
