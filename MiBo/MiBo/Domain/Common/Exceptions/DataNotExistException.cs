using System;

namespace MiBo.Domain.Common.Exceptions
{
    [Serializable]
    public class DataNotExistException : Exception
    {
        public DataNotExistException(string messageParam)
        {
            throw new ExecuteException("E_MSG_00002", messageParam);
        }
    }
}