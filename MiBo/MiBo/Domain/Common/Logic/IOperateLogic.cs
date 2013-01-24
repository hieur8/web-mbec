namespace MiBo.Domain.Common.Logic
{
    public interface IOperateLogic<T> where T : class
    {
        T Invoke(object obj);
    }
}