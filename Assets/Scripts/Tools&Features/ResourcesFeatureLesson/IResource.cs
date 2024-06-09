using System;

namespace Lessons
{
    public interface IResource
    {
        event Action<int, int> Changed;
        ResourceType ResourseType { get; }
        int Amount { get; }
    }
}

