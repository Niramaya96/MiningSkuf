using System;

namespace Lessons
{
    public interface IResource
    {
        event Action<int, int> Changed;
        ResourseType ResourseType { get; }
        int Amount { get; }
    }
}

