using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

namespace TryFinger
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        // bepin stuff
        internal static ModConfig conf;
        internal static ManualLogSource Log;
        
        internal static UnityEngine.AssetBundle fingerbundle;

        private void Awake()
        {
            conf = new ModConfig(Config);
            Log = base.Logger;

            fingerbundle = UnityEngine.AssetBundle.LoadFromMemory(Resource1.try_finger);
            if (fingerbundle == null)
            {
                Logger.LogError("fingerbundle failed to load :(");
            }
            fingerbundle.LoadAllAssets();
            new Harmony(PluginInfo.PLUGIN_GUID).PatchAll();

            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
        }
    }
}
