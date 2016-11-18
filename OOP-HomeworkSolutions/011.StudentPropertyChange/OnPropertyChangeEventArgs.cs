class OnPropertyChangeEventArgs : System.EventArgs
{
    private OnPropertyChangeEventArgs(string oldValue, string newValue)
    {
        OldValue = oldValue;
        NewPrice = newValue;
    }

    private string OldValue { get; set; }
    private string NewPrice { get; set; }
}
