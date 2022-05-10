using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lock_Unlock_APP.Models
{
    public class History
    {
        public string Id { get; set; }
        public string User { get; set; }
        public string LockUnlock { get; set; }
        public DateTime Date { get; set; }
    }
    public class Details
    {
        public string Id { get; set; }
        public string LockUnlock_Id { get; set; }
        public string Division { get; set; }
        public string ProfileName { get; set; }
        public string LockUnlock_Status { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
