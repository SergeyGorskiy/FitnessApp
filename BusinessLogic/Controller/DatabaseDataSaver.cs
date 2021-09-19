using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using BusinessLogic.Model;

namespace BusinessLogic.Controller
{
    public class DatabaseDataSaver<T> : IDataSaver<T> where T : class
    {

        public void Save(T item)
        {
            using (var db = new FitnessContext())
            {
                db.Set<T>().Add(item);
                db.SaveChanges();
            }
        }

        public List<T> Load()
        {
            using (var db = new FitnessContext())
            {
                var result = db.Set<T>().Where(l => true).ToList();
                return result;
            }
        }

    }
}