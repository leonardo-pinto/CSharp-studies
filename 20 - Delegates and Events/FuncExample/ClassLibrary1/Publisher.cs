using System;

namespace ClassLibrary1
{
    public class Publisher
    {
        public event Func<int, int, int> MyEvent;

        public int RaiseEvent(int a, int b)
        {
            if (MyEvent != null)
            {
                return MyEvent.Invoke(a, b);
            }
            else
            {
                return 0;
            }
        }
    }
}
