using System;


namespace Lessons
{
    public class Resource : IResource
    {
        public event Action<int, int> Changed;
        public ResourseType ResourseType { get; }

        private int _amount;
        public int Amount
        {
            get => _amount;
            set
            {
                var oldValue = _amount;
                _amount = value;

                if (oldValue != _amount)
                {
                    Changed?.Invoke(oldValue, value);
                }
            }
        }

        public Resource(ResourseType resourseType, int amountByDefault = default)
        {
            ResourseType = resourseType;
            Amount = amountByDefault;
        }


    }
}

