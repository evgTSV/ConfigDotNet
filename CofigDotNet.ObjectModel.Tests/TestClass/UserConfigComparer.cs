using System.Diagnostics.CodeAnalysis;

namespace ConfigDotNet.ObjectModel.Tests.TestClass;

internal class UserConfigComparer : IEqualityComparer<UserConfig>
{
    public bool Equals(UserConfig? x, UserConfig? y)
    {
        if (x == null || y == null) return false;
        if (x.Equals(y)) return true;
        
        if (x.Email != y.Email) return false;
        if (x.Name != y.Name) return false;
        return x.Password == y.Password;
    }

    public int GetHashCode([DisallowNull] UserConfig obj)
    {
        throw new NotImplementedException();
    }
}