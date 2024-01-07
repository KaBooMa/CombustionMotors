using System;
using System.Reflection;
using BepInEx;
using BepInEx.Logging;
using BepInEx.Unity.IL2CPP;
using GearLib.Links;
using UnityEngine;

namespace CombustionMotors;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
[BepInDependency("GearLib")]
public class Plugin : BasePlugin
{
    internal static new ManualLogSource Log;
    public override void Load()
    {
        Log = base.Log;

        // create our own combustion data link type
        new LinkType("Combustion", Color.yellow);
        new LinkType("Electronics", Color.green);

        // Checks for all classes inside our CombustionMotors.Parts namespace and instances them
        // Using for easier new part addition w/ organization
        Assembly asm = Assembly.GetExecutingAssembly();
        foreach (Type type in asm.GetTypes())
        {
            if (type.Namespace.StartsWith("CombustionMotors.Parts")) Activator.CreateInstance(type);
        }

        Log.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} is loaded!");
    }
}