using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public interface IRepository
    {
        IEnumerable<TestObject> GetAll();
        TestObject Get(int id);
        void Add(TestObject value);
        void Update(int id, TestObject value);
        void Remove(int id);
    }
}
