using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

namespace Fuck_Dialouge_Saving
{
    [BepInPlugin(PluginGuid, PluginName, PluginVersion)]
    [BepInDependency("cyantist.inscryption.api", BepInDependency.DependencyFlags.HardDependency)]

    public class Fuck_Dialog_Saving : BaseUnityPlugin
    {
        // --------------------------------------------------------------------------------------------------------------------------------------------------



        // These are variables that exist everywhere in the entire class.
        public const string PluginGuid = "creator.FuckDialougeSaving";
        public const string PluginName = "Fuck Dialouge Saving";
        public const string PluginVersion = "1.0.0";
        public const string PluginPrefix = "Fuck_Dialog_Saving";

        // Define a Manual Log Source
        public static ManualLogSource Log = new ManualLogSource(PluginName);

        // Declare Harmony here for future Harmony patches. You'll use Harmony to patch the game's code outside of the scope of the API.
        readonly Harmony harmony = new(PluginGuid);

        public void Awake()
        {
            Logger.LogMessage($"{PluginGuid}: Loaded Mod: {PluginName} - {PluginVersion}");

        }
    }
}