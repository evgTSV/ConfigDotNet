// Licensed to the HardDriveS under one or more agreements.
// The HardDriveS licenses this file to you under the MIT license.

namespace ConfigDotNet
{
    internal static class Constants
    {
        /// <summary>
        /// Threshold when we switch from ReadOnly to Frozen Dictionary
        /// </summary>
        /// <remarks>
        /// Useful only on .NET 8 or greater.
        /// </remarks>
        public const int MaxSectionsInSmallConfig = 1000;
    }
}
