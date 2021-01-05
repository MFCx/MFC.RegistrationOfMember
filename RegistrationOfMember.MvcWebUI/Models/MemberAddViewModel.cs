using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using RegistrationOfMember.Entities.Concrete;

namespace RegistrationOfMember.MvcWebUI.Models
{
    public class MemberAddViewModel
    {
        public Member Member { get; set; }
    } 
}