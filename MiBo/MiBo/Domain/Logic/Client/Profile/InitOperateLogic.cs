﻿using MiBo.Domain.Common.Logic;
using MiBo.Domain.Web.Client.Profile;

namespace MiBo.Domain.Logic.Client.Profile
{
    public class InitOperateLogic : IOperateLogic<InitResponseModel>
    {
        public InitResponseModel Invoke(object obj)
        {
            var logic = new InitLogic();

            return logic.Invoke((InitRequestModel)obj);
        }
    }
}