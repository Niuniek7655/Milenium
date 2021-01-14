using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class TestContext : ITestContext
    {
        public List<TestObject> Collection { get; } = new List<TestObject>()
        {
            new TestObject()
            {
                Id = 1,
                Name = "Ania",
            },
            new TestObject()
            {
                Id = 2,
                Name = "Jan",
            },
            new TestObject()
            {
                Id = 3,
                Name = "Piotek",
            },
            new TestObject()
            {
                Id = 4,
                Name = "Monika"
            },
        };
    }
}
