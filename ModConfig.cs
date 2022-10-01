using BepInEx.Configuration;

namespace TryFinger
{
    public class ModConfig
    {
        // Input
        public ConfigEntry<string> TryFinger;

        public ModConfig(ConfigFile c)
        {
            TryFinger = c.Bind<string>("Input", "TryFinger", "t", "Flip the bird");
        }
    }
}