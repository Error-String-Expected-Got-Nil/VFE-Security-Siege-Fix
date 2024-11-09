using System.Reflection;
using HarmonyLib;
using Verse;

namespace VFESecuritySiegeFix;

[StaticConstructorOnStartup]
public static class Startup
{
    static Startup()
    {
        Harmony.DEBUG = false;
        var harmony = new Harmony("VFESecuritySiegeFix");
        harmony.PatchAll(Assembly.GetExecutingAssembly());
    }
}