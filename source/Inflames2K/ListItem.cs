using System.Diagnostics;

namespace Inflames2K
{
    [DebuggerDisplay("Value = {Value}")]
    public class ListItem<T>
    {
        public T Value              { get; set; }
        public ListItem<T> Previous { get; set; }
        public ListItem<T> Next     { get; set; }
        //---------------------------------------------------------------------
        public ListItem(T value)
        {
            // null as value is allowed -> consumer has to handle this
            this.Value = value;
        }
    }
}