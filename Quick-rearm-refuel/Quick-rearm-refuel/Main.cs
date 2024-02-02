using BepInEx;
using BepInEx.Configuration;
using Falcon.Game2;
using System.IO;
using UnityEngine;

namespace Quick_rearm_refuel
{
    [BepInPlugin("Quick_rearm_refuel", "Quick Rearm Refuel", "0.1.0.0")]
    class Main : BaseUnityPlugin
    {
        private ConfigFile _configFile;

        private ConfigEntry<KeyCode> _interactionKey;

        void Awake()
        {
            _configFile
                = new ConfigFile(Path.Combine(Paths.PluginPath, "QuickRearmRefuel\\settings.cfg"), true);

            _interactionKey
                = _configFile.Bind<KeyCode>(new ConfigDefinition("Interaction Key", "key"), KeyCode.R);
        }

        void Update()
        {
            if (FlightGame.Instance != null)
            {
                if (UnityInput.Current.GetKeyUp(_interactionKey.Value))
                {
                    FlightGame.Instance.SendMessage("StartRearmRefuelMenu");
                }
            }
        }
    }
}
