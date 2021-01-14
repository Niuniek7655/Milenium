using System;
using System.Collections.Generic;
using System.Linq;

namespace Model
{
    public class Repository : IRepository
    {
        private readonly ITestContext _context;
        public Repository(ITestContext context)
        {
            _context = context;
        }

        public void Add(TestObject value)
        {
            _context.Collection.Add(value);
        }

        public TestObject Get(int id)
        {
            TestObject value = _context.Collection.Where(x => x.Id == id).FirstOrDefault();
            return value;
        }

        public IEnumerable<TestObject> GetAll()
        {
            return _context.Collection;
        }

        public void Remove(int id)
        {
            TestObject value = _context.Collection.Where(x => x.Id == id).FirstOrDefault();
            if(value != null)
            {
                _context.Collection.Remove(value);
            }
        }

        public void Update(int id, TestObject value)
        {
            TestObject objectToUpdate = _context.Collection.Where(x => x.Id == id).FirstOrDefault();
            if(objectToUpdate != null)
            {
                objectToUpdate = value;
            }
        }
    }
}
