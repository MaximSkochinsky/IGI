using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace WEB_953506_Skochinsky.Entities
{
    public class ApplicationUser: IdentityUser
    {
        public byte[] AvatarImage { get; set; }
    }
}
