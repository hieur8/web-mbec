using System;

namespace MiBo.Domain.Common.Exceptions
{
    [Serializable]
    public class DataExistException : Exception
    {
        public DataExistException(string messageParam)
        {
            throw new ExecuteException("E_MSG_00003", messageParam);
        }
    }
}