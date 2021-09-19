using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace BusinessLogic.Controller
{
    public abstract class ControllerBase<T> where T : class
    {
        protected IDataSaver<T> manager = new DatabaseDataSaver<T>();
        protected void Save(T item)
        {
            manager.Save(item);
        }
        protected List<T> Load()
        {
            return manager.Load();
        }
    }
}