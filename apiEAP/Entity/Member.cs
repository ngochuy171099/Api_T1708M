using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiEAP.Entity
{
    public class Member
    {
        public long Id { get; set; }

        public String FirtName { get; set; }

        public String LastName { get; set; }

        public String Avatar { get; set; }

        public String Phone { get; set; }

        public String Address { get; set; }

        public String Introduction { get; set; }

        public int Gender { get; set; }

        public DateTime Birthday { get; set; }

        public String Email { get; set; }

        public String Password { get; set; }

        public String Salt { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public MemberStatus Status { get; set; }
        
      

        
        public Member()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
            Status = MemberStatus.Actived;
        }

       
    }
    public enum MemberStatus
    {
        Actived = 1,
        Deactivated = 0
    }

}
