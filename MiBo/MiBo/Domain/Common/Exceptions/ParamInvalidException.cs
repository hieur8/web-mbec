﻿using System;
using Resources;

namespace MiBo.Domain.Common.Exceptions
{
    [Serializable]
    public class ParamInvalidException : Exception
    {
        public ParamInvalidException()
        {
            throw new ExecuteException("E_MSG_00001", "Tham số");
        }
    }
}