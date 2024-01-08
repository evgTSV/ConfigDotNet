namespace ConfigDotNet
{
    /// <summary>
    /// Defines properties that provides access to Key and Value
    /// </summary>
    public interface ISection<out TKey, out TValue>
    {
        TKey Key { get; }
        TValue Value { get; }
    }
}
