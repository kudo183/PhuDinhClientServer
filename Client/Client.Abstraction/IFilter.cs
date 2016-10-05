using System;
using System.Linq.Expressions;

namespace Client.Abstraction
{
    public interface IFilter<T>
    {
        Expression<Func<T, bool>> Filter { get; }
        bool IsClearAllData { get; }
        void SetFilter(string key, object value, bool setFalse = false);
    }
}
