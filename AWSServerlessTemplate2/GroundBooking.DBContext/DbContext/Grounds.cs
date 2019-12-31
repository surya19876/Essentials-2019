using Amazon.DynamoDBv2.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace GroundBooking.Repository.DbContext
{
    [DynamoDBTable("Grounds")]
    public class Grounds
    {
        [DynamoDBHashKey] //Partition key
        public int ID
        {
            get; set;
        }

        [DynamoDBRangeKey] //Sort key
        public string GroundName
        {
            get; set;
        }

    }
}
