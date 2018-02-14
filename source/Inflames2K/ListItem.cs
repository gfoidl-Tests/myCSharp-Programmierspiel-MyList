using System.Diagnostics;

namespace Inflames2K
{
    [DebuggerDisplay("Value = {Value}")]
    internal class ListItem<T>
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
        //---------------------------------------------------------------------
        public static implicit operator T(ListItem<T> listItem) => listItem.Value;
        public static implicit operator ListItem<T>(T value) => new ListItem<T>(value);
    }
}
