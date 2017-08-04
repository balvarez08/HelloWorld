using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using HelloWorld.Data;
using System.Collections.Generic;
using System.Linq;
using HelloWorld.Web.Repository;

namespace HelloWorld.Test
{
    [TestClass]
    public class UnitTest1
    {
        private HelloWorldModel _db;
        [TestMethod]
        public void Check_If_Data_Exist_Table()
        {
            var testRequest = SetupTestRecord();
            var testId = testRequest.id;
            var HWRepo = new HelloWorldRepository();

            HWRepo.Add(testRequest);

            var hwdata = _db.DataInputs
               .Where(rr => rr.id == testRequest.id)
               .SingleOrDefault();
            Assert.IsNotNull(hwdata);

            CleanUpTestRecord(testId);
        }
        
        private DataInputs SetupTestRecord()
        {
            _db = new HelloWorldModel();
            
            var newData = new DataInputs
            {
               id = 1,
               DataInputText = "Hello World"
            };

            _db.DataInputs.Add(newData);
            _db.SaveChanges();

            return newData;
        }

        private void CleanUpTestRecord(int hwId)
        {
            var removeData = _db.DataInputs
                .Where(rr => rr.id == hwId)
                .SingleOrDefault();

            if (removeData != null)
            {
                _db.DataInputs.Remove(removeData);
                _db.SaveChanges();
            }
        }
    }
}
