using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using BusinessLogic.Model;

namespace BusinessLogic.Controller
{
    public class DatabaseSaver : IDataSaver
    {

        public void Save<T>(List<T> item) where T : class
        {
            using (var db = new FitnessContext())
            {
                db.Set<T>().AddRange(item);
                db.SaveChanges();
            }
        }

        public List<T> Load<T>() where T : class
        {
            using (var db = new FitnessContext())
            {
                var result = db.Set<T>().Where(t => true).ToList();
                return result;
            }
        }

    }
}