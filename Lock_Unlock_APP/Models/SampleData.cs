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
        //public static List<Details> GetDetails(string id)
        //{
        //    List<Details> detailsList = new List<Details>();
        //    Details details = new Details();
        //    details.Id = "1234";
        //    details.historyId = "343554";
        //    details.division = "Asdll";
        //    details.Profile = "Diyna";
        //    details.lockUnlockStatus = "Lock";
        //    details.dateTime= DateTime.Now.AddDays(-80);
        //    detailsList.Add(details);
        //    details = new Details();
        //    details.Id = "1235";
        //    details.historyId = "343555";
        //    details.division = "Zone";
        //    details.Profile = "Alisa";
        //    details.lockUnlockStatus = "UnLock";
        //    details.dateTime = DateTime.Now.AddDays(-70);
        //    detailsList.Add(details);
        //    details = new Details();
        //    details.Id = "1236";
        //    details.historyId = "343556";
        //    details.division = "Canada";
        //    details.Profile = "Diya";
        //    details.lockUnlockStatus = "Active";
        //    details.dateTime = DateTime.Now.AddDays(-60);
        //    detailsList.Add(details);
        //    details = new Details();
        //    details.Id = "1237";
        //    details.historyId = "343556";
        //    details.division = "france";
        //    details.Profile = "Sophi";
        //    details.lockUnlockStatus = "Active";
        //    details.dateTime = DateTime.Now.AddDays(-50);
        //    detailsList.Add(details);
        //    details = new Details();
        //    details.Id = "1238";
        //    details.historyId = "343557";
        //    details.division = "Canada";
        //    details.Profile = "shophiya";
        //    details.lockUnlockStatus = "Active";
        //    details.dateTime = DateTime.Now.AddDays(-40);
        //    detailsList.Add(details);
        //    details = new Details();
        //    details.Id = "1238";
        //    details.historyId = "343558";
        //    details.division = "Japan";
        //    details.Profile = "Andri";
        //    details.lockUnlockStatus = "UnLock";
        //    details.dateTime = DateTime.Now.AddDays(-80);
        //    detailsList.Add(details);
        //    detailsList = detailsList.Where(m => m.historyId == id).ToList();
        //    return detailsList;



        //}
        public static class Macro
        {
            public static List<History> GetHeaders()
            {
                var connectionString = "Data Source=LAPTOP-OD0O0KPE\\SQLEXPRESS;Initial Catalog=Profile;Integrated Security=true;";
                string query = "select * from LockUnlock";
                using (var db = new SqlConnection(connectionString))
                    return db.Query<History>(query).AsList();
            }
            public static List<Details> GetDetailsById(int id)
            {
                var connectionString = "Data Source=LAPTOP-OD0O0KPE\\SQLEXPRESS;Initial Catalog=Profile;Integrated Security=true;";
                string query = "select * from LockUnlockDetails where LockUnlock_Id=" + id;
                using (var db = new SqlConnection(connectionString))
                    return db.Query<Details>(query).AsList();
            }
            public static string UpdateStatus(int id)
            {
                var details = GetDetailsById(id);
                foreach (var detail in details)
                {
                    var columnvalue = detail.LockUnlock_Status == "Lock" ? "UnLock" : detail.LockUnlock_Status;
                    var connectionString = "Data Source=LAPTOP-OD0O0KPE\\SQLEXPRESS;Initial Catalog=Profile;Integrated Security=true;";
                    string query = "UPDATE LockUnlockDetails SET  LockUnlock_Status ='" + columnvalue + "' WHERE Id =" + detail.Id;
                    using (var db = new SqlConnection(connectionString))
                        db.Query<int>(query).AsList();

                }
                return "Succes";
            }
            public static async Task<int> CreateHeader(string status, string userName)
            {
                int id = 0;
                var connectionString = "Data Source=LAPTOP-OD0O0KPE\\SQLEXPRESS;Initial Catalog=Profile;Integrated Security=true;";
                using (var db = new SqlConnection(connectionString))
                {
                    string insertUserSql = @"INSERT INTO dbo.[LockUnlock](UserName, Lock_Unlock, CreateDate)
                        OUTPUT INSERTED.[Id]
                        VALUES(@Username, @Lock_Unlock, @CreateDate);";

                    id = db.QuerySingle<int>(
                                                    insertUserSql,
                                                    new
                                                    {
                                                        Username = userName,
                                                        Lock_Unlock = status,
                                                        CreateDate = DateTime.Now
                                                    });
                }
                return id;
            }
            public static async Task<int> CreateDetails(string status, string ProfileName, string division, int headerId)
            {
                int id = 0;
                var connectionString = "Data Source=LAPTOP-OD0O0KPE\\SQLEXPRESS;Initial Catalog=Profile;Integrated Security=true;";
                using (var db = new SqlConnection(connectionString))
                {
                    string insertUserSql = @"INSERT INTO dbo.[LockUnlockDetails](LockUnlock_Id, Division, ProfileName,LockUnlock_Status,CreateDate)
                        OUTPUT INSERTED.[Id]
                        VALUES(@LockUnlock_Id, @Division, @ProfileName,@LockUnlock_Status,@CreateDate);";

                    id = db.QuerySingle<int>(
                                                   insertUserSql,
                                                   new
                                                   {
                                                       LockUnlock_Id = headerId,
                                                       Division = division,
                                                       ProfileName = ProfileName,
                                                       LockUnlock_Status = status,
                                                       CreateDate = DateTime.Now
                                                   });
                }
                return id;
            }
        }
    }
}
