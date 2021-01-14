using System.Collections.Generic;

namespace Model
{
    public interface ITestContext
    {
        List<TestObject> Collection { get; }
    }
}