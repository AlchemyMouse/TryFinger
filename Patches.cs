using HarmonyLib;
using UnityEngine;

namespace TryFinger
{
    // add a finger manager
    [HarmonyPatch(typeof(GunControl))]
    class GiveGun 
    {
        [HarmonyPatch("Start")]
        static void Postfix(GunControl __instance)
        {
            __instance.gameObject.AddComponent<FingerManager>();
        }
    }

    // grant the finger whenever the guns list updates
    [HarmonyPatch(typeof(GunSetter))]
    class ResetCheck
    {
        [HarmonyPatch("ResetWeapons")]
        public static void Postfix()
        {
            if (MonoSingleton<FingerManager>.Instance)
            {
                MonoSingleton<FingerManager>.Instance.GrantFinger();
            }
        }
    }

    // disable cybergrind score submissions
    [HarmonyPatch(typeof(SteamController))]
    class DisableSubmission
    {
        [HarmonyPatch("SubmitCyberGrindScore")]
        static bool Prefix(int difficulty, float wave, int kills, int style, float seconds)
        {
            return false;
        }
    }

    // disable cybergrind high score saving
    [HarmonyPatch(typeof(GameProgressSaver))]
    class DisableSaving
    {
        [HarmonyPatch("SetBestCyber")]
        static bool Prefix(FinalCyberRank fcr)
        {
            return false;
        }
    }

    // put an instance of ModInput as a sibling to InputManager
    [HarmonyPatch(typeof(global::InputManager))]
    class InputInjection
    {
        [HarmonyPatch("Awake")]
        static protected void Postfix(InputManager __instance)
        {
            __instance.gameObject.AddComponent<ModInput>();
        }
    }
}