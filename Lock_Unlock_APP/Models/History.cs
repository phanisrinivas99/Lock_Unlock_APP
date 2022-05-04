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
        public string historyId { get; set; }
        public string division { get; set; }
        public string Profile { get; set; }
        public string lockUnlockStatus { get; set; }
        public DateTime dateTime { get; set; }
    }
}
