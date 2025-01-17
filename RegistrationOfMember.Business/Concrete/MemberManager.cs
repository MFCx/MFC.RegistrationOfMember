﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Core.Aspects.Postsharp.LogAspects;
using DevFramework.Core.Aspects.Postsharp.ValidationAspects;
using DevFramework.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using RegistrationOfMember.Business.Abstract;
using RegistrationOfMember.Business.ServiceAdapters.Abstract;
using RegistrationOfMember.Business.ValidationRules.FluentValidation;
using RegistrationOfMember.DataAccess.Abstract;
using RegistrationOfMember.Entities.Concrete;


namespace RegistrationOfMember.Business.Concrete
{
    public class MemberManager : IMemberService
    {
        private IMemberDal _memberDal;
        private IKpsService _kpsService;

        public MemberManager(IMemberDal memberDal, IKpsService kpsService)
        {
            _memberDal = memberDal;
            _kpsService = kpsService;
        }


        [FluentValidationAspect(typeof(MemberValidator))]
        [LogAspect(typeof(DatabaseLogger))]
        [LogAspect(typeof(FileLogger))]
        public void Add(Member member)
        {
            CheckIfMemberExists(member);
            CheckIfUserValidFromKps(member);
        }

        private void CheckIfUserValidFromKps(Member member)
        {
            if (_kpsService.ValidateUser(member))
            {
                _memberDal.Add(member);
            }
            else
            {
                throw new Exception("Kullanıcı doğrulanamadı.");
            }
        }

        private void CheckIfMemberExists(Member member)
        {
            if (_memberDal.Get(m => m.TcNo == member.TcNo) != null)
            {
                throw new Exception("Kullanıcı sisteme daha önce kayıt olmustur..");
            }
        }
    }
}
