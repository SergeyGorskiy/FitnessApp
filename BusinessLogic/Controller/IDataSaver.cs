using System.Collections.Generic;

namespace BusinessLogic.Controller
{
    public interface IDataSaver<T> where T : class
    {
        void Save(T item);
        List<T> Load();
    }
}