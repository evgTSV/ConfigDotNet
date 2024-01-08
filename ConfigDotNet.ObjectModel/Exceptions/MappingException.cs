namespace ConfigDotNet.ObjectModel.Exceptions
{
    /// <summary>
    /// Represents class, that have info about members, who participated in mapping
    /// </summary>
    /// <remarks>
    /// Have From (mapped from) and To (mapped to)
    /// </remarks>
    public class MappingException(string mapFrom, string mapTo, string remarks, Exception? inner)
        : Exception($"Mapping {mapFrom} to {mapTo} exception ({remarks})", innerException: inner)
    {
        public MappingException(string mapFrom, string mapTo, string remarks)
            :this(mapFrom, mapFrom, remarks, null) {}

        /// <summary>
        /// Mapped From
        /// </summary>
        public string From { get; init; } = mapFrom;

        /// <summary>
        /// Mapped To
        /// </summary>
        public string To { get; init; } = mapTo;
    }
}
