using HarmonyLib;
using RimWorld;
using Verse;
using VFESecurity;

namespace VFESecuritySiegeFix.Patches;

// ReSharper disable InconsistentNaming

[HarmonyPatch(typeof(LordToil_Siege_SetAsBuilder_Patch))]
public class Patch_LordToil_Siege_SetAsBuilder_Patch
{
    // Have to use __args injection because the argument we want from the original is __instance
    [HarmonyPatch(nameof(LordToil_Siege_SetAsBuilder_Patch.SetMinLevels))]
    [HarmonyPrefix]
    public static bool SetMinLevels_Prefix(object[] __args)
    {
        var __instance = (LordToil_Siege)__args[1];

        // Bug in the original is, quite literally, just not checking to see if there are actually any blueprints
        // before trying to find the max construction requirement of them.
        if (((LordToilData_Siege)__instance.data).blueprints.EnumerableNullOrEmpty()) return false;

        return true;
    }
}