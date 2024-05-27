using System.Reflection;

namespace Project.WebAPI;

public static class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}