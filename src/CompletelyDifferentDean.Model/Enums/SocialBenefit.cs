using System;

// ReSharper disable once CheckNamespace
namespace CompletelyDifferentDean.Model.Enums
{
    [Flags]
    public enum SocialBenefit
    {
        None = 0,
        Disabled = 2,
        Orphan = 4,
        Chernobyl = 8
    }
}
