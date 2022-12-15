namespace ClassLibrary1
{
    // delegate type
    public delegate void MyDelegateType(int a, int b);

    // publisher
    public class Publisher
    {
        // private delegate
        // this syntax is not necessary when using auto-implemented events
        //private MyDelegateType myDelegate;

        // step 1: create event
        public event MyDelegateType myEvent;
        // this syntax is not necessary when using auto-implemented events
        //{
        //    add
        //    {
        //        myDelegate += value;
        //    }
        //    remove
        //    {
        //        myDelegate -= value;
        //    }
        //}

        public void RaiseEvent(int a, int b)
        {
            // step 2: raise event
            // in the case of auto-implement events, myEvent is used rather than myDelegate
            if (this.myEvent != null)
            {
                myEvent(a, b);
            }

            // step 2: raise event
            //if (this.myDelegate != null)
            //{
            //    this.myDelegate(a, b);
            //}
        }
    }
}
