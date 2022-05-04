using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Lock_Unlock_APP.Models
{
    public static class SampleData
    {
        public static List<History> GetHistories()
        {
            List<History> historyList = new List<History>();
            History History = new History();
            History.Id = "343554";
            History.LockUnlock = "Lock";
            History.User = "Jaya";
            History.Date = DateTime.Now.AddDays(-30);
            historyList.Add(History);
            History = new History();
            History.Id = "3355s";
            History.LockUnlock = "Lock";
            History.User = "Roy";
            History.Date = DateTime.Now.AddDays(-20);
            historyList.Add(History);
            History = new History();
            History.Id = "33555";
            History.LockUnlock = "UnLock";
            History.User = "Jafar";
            History.Date = DateTime.Now.AddDays(-10);
            historyList.Add(History);
            History = new History();
            History.Id = "33556";
            History.LockUnlock = "UnLock";
            History.User = "Freniol";
            History.Date = DateTime.Now.AddDays(-50);
            historyList.Add(History);
            History = new History();
            History.Id = "33557";
            History.LockUnlock = "UnLock";
            History.User = "Danial";
            History.Date = DateTime.Now.AddDays(-60);
            historyList.Add(History);
            History = new History();
            History.Id = "33558";
            History.LockUnlock = "Lock";
            History.User = "Syam";
            History.Date = DateTime.Now.AddDays(-70);
            historyList.Add(History);
            History = new History();
            History.Id = "33559";
            History.LockUnlock = "UnLock";
            History.User = "Diyana";
            History.Date = DateTime.Now.AddDays(-80);
            historyList.Add(History);
            History = new History();
            History.Id = "33560";
            History.LockUnlock = "Lock";
            History.User = "Lisa";
            History.Date = DateTime.Now.AddDays(-90);
            historyList.Add(History);


            return historyList;
        }
        public static List<Details> GetDetails(string id)
        {
            List<Details> detailsList = new List<Details>();
            Details details = new Details();
            details.Id = "1234";
            details.historyId = "343554";
            details.division = "Asdll";
            details.Profile = "Diyna";
            details.lockUnlockStatus = "Lock";
            details.dateTime= DateTime.Now.AddDays(-80);
            detailsList.Add(details);
            details = new Details();
            details.Id = "1235";
            details.historyId = "343555";
            details.division = "Zone";
            details.Profile = "Alisa";
            details.lockUnlockStatus = "UnLock";
            details.dateTime = DateTime.Now.AddDays(-70);
            detailsList.Add(details);
            details = new Details();
            details.Id = "1236";
            details.historyId = "343556";
            details.division = "Canada";
            details.Profile = "Diya";
            details.lockUnlockStatus = "Active";
            details.dateTime = DateTime.Now.AddDays(-60);
            detailsList.Add(details);
            details = new Details();
            details.Id = "1237";
            details.historyId = "343556";
            details.division = "france";
            details.Profile = "Sophi";
            details.lockUnlockStatus = "Active";
            details.dateTime = DateTime.Now.AddDays(-50);
            detailsList.Add(details);
            details = new Details();
            details.Id = "1238";
            details.historyId = "343557";
            details.division = "Canada";
            details.Profile = "shophiya";
            details.lockUnlockStatus = "Active";
            details.dateTime = DateTime.Now.AddDays(-40);
            detailsList.Add(details);
            details = new Details();
            details.Id = "1238";
            details.historyId = "343558";
            details.division = "Japan";
            details.Profile = "Andri";
            details.lockUnlockStatus = "UnLock";
            details.dateTime = DateTime.Now.AddDays(-80);
            detailsList.Add(details);
            detailsList = detailsList.Where(m => m.historyId == id).ToList();
            return detailsList;



        }
        public static class Macro
        {
            public static List<History> GetHeaders()
            {
                var connectionString = "Data Source=LAPTOP-OD0O0KPE\\SQLEXPRESS;Initial Catalog=Profile;Integrated Security=true;";
                string query = "select * from LockUnlock";
                using (var db = new SqlConnection(connectionString))
                    return db.Query<History>(query).AsList();
            }
        }
    }
}
