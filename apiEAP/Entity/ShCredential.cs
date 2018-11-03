using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apiEAP.Entity
{
    public class ShCredential
    {
        [Key]

        public string Token { get; set; }

        public string AccessToken { get; set; }

        public long MemberId  { get; set; }

        public string RefreshToken { get; set; }

        public CredentialScope CredentialScope { get; set; }

        public DateTime CreatedAd { get; set; }

        public DateTime UpdatedAt { get; set; }

        public DateTime ExpriredAd { get; set; }

        public CredentialStatus Status { get; set; }

        public static ShCredential GenerateCredential(long memberId,CredentialScope scope )
        {
            var token = Guid.NewGuid().ToString();
            return new ShCredential()
            {
                Token =  token,
                AccessToken = token,
                RefreshToken = Guid.NewGuid().ToString(),
                MemberId = memberId,
                CredentialScope = scope,
                CreatedAd = DateTime.Now,
                ExpriredAd = DateTime.Now.AddDays(7),
                UpdatedAt = DateTime.Now,
                Status = CredentialStatus.Activated,
            };

        }

    }

    public enum CredentialStatus
    {
        Activated = 1,
        Deactivated = 0
    }

    public enum CredentialScope
    {
        Basic =1,
        SongApi =2,
        Gallery = 3,
        Contact = 4,
    }
}
