using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using GroundBooking.Repository.DbContext;
using GroundBooking.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace GroundBooking.Repository.Repository
{
    public class GroundRepository : IGroundRepository
    {
        private AmazonDynamoDBClient client;
        private DynamoDBContext context;
        public GroundRepository()
        {
            client = new AmazonDynamoDBClient("Add Access Key", "Add Secret", Amazon.RegionEndpoint.APSouth1);
            context = new DynamoDBContext(client);
        }
        public Grounds GetGroundById(int id)
        {
            throw new NotImplementedException();
        }


        public List<Grounds> GetGrounds()
        {
            var conditions = new List<ScanCondition>();
            return context.ScanAsync<Grounds>(conditions).GetRemainingAsync().Result;
        }

        public void AddGround(Grounds ground)
        {
            Table grounds = Table.LoadTable(client, "Grounds");
            var newGround = new Document();
            newGround["ID"] = ground.ID;
            newGround["GroundName"] = ground.GroundName;
            grounds.PutItemAsync(newGround).Wait();
        }
    }
}
