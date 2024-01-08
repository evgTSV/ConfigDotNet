namespace ConfigDotNet
{
    /// <summary>
    /// Represent a struct storing a key and value of section in <see cref="Configuration{T}"/>
    /// </summary>
    /// <typeparam name="T">Type of value of section</typeparam>
    public readonly struct Section<T>(string key, T value) : ISection<string, T>
    {
        public string Key => key;
        public T Value => value;
    }
}
