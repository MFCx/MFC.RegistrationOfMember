using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RegistrationOfMember.Business.Abstract;
using RegistrationOfMember.Business.DependencyResolvers.Ninject;
using RegistrationOfMember.Entities.Concrete;

namespace RegistrationOfMember.ConsoleUI
{
    class Program
    {
        
        static void Main(string[] args)
        {

            var memberService = InstanceFactory.GetInstance<IMemberService>();
            memberService.Add(new Member
            {
                FirstName = "Derya",
                LastName = "Ünver",
                TcNo = "54400165046",
                DateOfBirth = new DateTime(1994, 5, 3),
                Email = "derya@derya.com"


            });
           
            Console.WriteLine("Eklendi");
            Console.ReadLine();
        }
    }
}
