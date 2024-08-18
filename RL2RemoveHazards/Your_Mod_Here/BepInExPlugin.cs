using System;
using System.Reflection;
using BepInEx;
using HarmonyLib;
using UnityEngine;
using Wob_Common;

namespace Pzw1 {
    [BepInPlugin("pzw1.RemoveHazards", "Remove Hazards", "1.0.0" )]
    public partial class Pzw1_RemoveHazards : BaseUnityPlugin {
        // Main method that kicks everything off
        protected void Awake() {
            // Set up the logger and basic config items
            WobPlugin.Initialise( this, this.Logger );
            // Create/read the mod specific configuration options
            // Example setting - delete or replace
            WobSettings.Add(new WobSettings.Boolean("Options", "RemoveBodies", "Remove the Bodies hazard - not sure what this is. Maybe harmless bodies laying around", false));
            WobSettings.Add(new WobSettings.Boolean("Options", "RemoveBuzzsaw", "Remove the Buzzsaws - saw blades that go back and forth that you kick off of", false));
            WobSettings.Add(new WobSettings.Boolean("Options", "RemoveBreakableSpike", "Remove the Breakable Spikes - the roots", false));
            WobSettings.Add(new WobSettings.Boolean("Options", "RemoveCurseRaycastTurret", "Remove the Curse Raycast Turrets - the traps that shoot out a little curse that tracks towards you", false));
            WobSettings.Add(new WobSettings.Boolean("Options", "RemoveFlameThrower", "Remove the Flame Throwers - the ones that turn off and on", false));
            WobSettings.Add(new WobSettings.Boolean("Options", "RemoveIceCrystal", "Remove the Ice Crystals - the ones that grow into a big snowflake", false));
            WobSettings.Add(new WobSettings.Boolean("Options", "RemoveOrbiter", "Remove the Orbiters - the spinning spiked fire ball on a chain", false));
            WobSettings.Add(new WobSettings.Boolean("Options", "RemovePressurePlate", "Remove the Pressure Plates - the long spears that pop up when you trigger them", false));
            WobSettings.Add(new WobSettings.Boolean("Options", "RemovePressurePlateTrigger", "Remove the trigger for Pressure Plates - the buttons that arm the trap of the long spears that pop up when you walk off of it", false));
            WobSettings.Add(new WobSettings.Boolean("Options", "RemoveProximityMine", "Remove the Proximity Mines - the scrolls that explode after a delay if you get close", false));
            WobSettings.Add(new WobSettings.Boolean("Options", "RemoveProximityProjectile", "Remove the Proximity Projectiles - the mushroom traps that shoot voids waves in all directions after getting too close", false));
            WobSettings.Add(new WobSettings.Boolean("Options", "RemoveRaycastTurret", "Remove the Raycast Turrets - the traps that shoot an electric arrow when you are in front of them", false));
            WobSettings.Add(new WobSettings.Boolean("Options", "RemoveTurret", "Remove the Turrets - the traps that shoot little fireballs", false));
            WobSettings.Add(new WobSettings.Boolean("Options", "RemoveSentry", "Remove Sentries - the eyeball traps that shoot an electric ball when you attack in their range", false));
            WobSettings.Add(new WobSettings.Boolean("Options", "RemoveSnowMound", "Remove Snow Mounds - snow on the ground that slows you down", false));
            WobSettings.Add(new WobSettings.Boolean("Options", "RemoveSpikeTrap", "Remove the Spike Traps - the spikes pop up when you are close after a delay", false));
            WobSettings.Add(new WobSettings.Boolean("Options", "RemoveTallSpike", "Remove the Tall Spikes - the normal static spikes", false));
            WobSettings.Add(new WobSettings.Boolean("Options", "RemoveTidalWave", "Remove the Tidal Waves - the tidal wave in dream boogie days", false));
            WobSettings.Add(new WobSettings.Boolean("Options", "RemoveWindmill", "Remove the Windmills - the spinning spike sticks that you kick off of in the sun tower", false));
            // Apply the patches if the mod is enabled
            WobPlugin.Patch();
        }


        [HarmonyPatch(typeof(Hazard), "SetRoom")]
        internal static class Hazard_SetRoom
        {
            private static BindingFlags eFlags = BindingFlags.Instance | BindingFlags.NonPublic;
            internal static void Postfix(Hazard __instance)
            {
                if (__instance.GetType() == typeof(Bodies_Hazard) && WobSettings.Get("Options", "RemoveBodies", false))
                {
                    //WobPlugin.Log("this is running Postfix_Hazard_SetRoom for instance of Bodies_Hazard");
                    MethodInfo mOnDisable = typeof(Bodies_Hazard).GetMethod("OnDisable", eFlags);
                    mOnDisable.Invoke(__instance, null);
                }
                else if (__instance.GetType() == typeof(Buzzsaw_Hazard) && WobSettings.Get("Options", "RemoveBuzzsaw", false))
                {
                    //WobPlugin.Log("this is running Postfix_Hazard_SetRoom for instance of Buzzsaw_Hazard");
                    MethodInfo mOnDisable = typeof(Buzzsaw_Hazard).GetMethod("OnDisable", eFlags);
                    mOnDisable.Invoke(__instance, null);
                }
                else if (__instance.GetType() == typeof(BreakableSpike_Hazard) && WobSettings.Get("Options", "RemoveBreakableSpike", false))
                {
                    //WobPlugin.Log("this is running Postfix_Hazard_SetRoom for instance of BreakableSpike_Hazard");
                    MethodInfo mOnDisable = typeof(BreakableSpike_Hazard).GetMethod("OnDisable", eFlags);
                    mOnDisable.Invoke(__instance, null);
                }
                else if (__instance.GetType() == typeof(CurseRaycastTurret_Hazard) && WobSettings.Get("Options", "RemoveCurseRaycastTurret", false))
                {
                    //WobPlugin.Log("this is running Postfix_Hazard_SetRoom for instance of CurseRaycastTurret_Hazard");
                    MethodInfo mOnDisable = typeof(CurseRaycastTurret_Hazard).GetMethod("OnDisable", eFlags);
                    mOnDisable.Invoke(__instance, null);
                }
                else if (__instance.GetType() == typeof(FlameThrower_Hazard) && WobSettings.Get("Options", "RemoveFlameThrower", false))
                {
                    //WobPlugin.Log("this is running Postfix_Hazard_SetRoom for instance of FlameThrower_Hazard");
                    MethodInfo mOnDisable = typeof(FlameThrower_Hazard).GetMethod("OnDisable", eFlags);
                    mOnDisable.Invoke(__instance, null);
                }
                else if (__instance.GetType() == typeof(IceCrystal_Hazard) && WobSettings.Get("Options", "RemoveIceCrystal", false))
                {
                    //WobPlugin.Log("this is running Postfix_Hazard_SetRoom for instance of IceCrystal_Hazard");
                    MethodInfo mOnDisable = typeof(IceCrystal_Hazard).GetMethod("OnDisable", eFlags);
                    mOnDisable.Invoke(__instance, null);
                }
                else if (__instance.GetType() == typeof(Orbiter_Hazard) && WobSettings.Get("Options", "RemoveOrbiter", false))
                {
                    //WobPlugin.Log("this is running Postfix_Hazard_SetRoom for instance of Orbiter_Hazard");
                    MethodInfo mOnDisable = typeof(Orbiter_Hazard).GetMethod("OnDisable", eFlags);
                    mOnDisable.Invoke(__instance, null);
                }
                else if (__instance.GetType() == typeof(PressurePlate_Hazard) && WobSettings.Get("Options", "RemovePressurePlate", false))
                {
                    //WobPlugin.Log("this is running Postfix_Hazard_SetRoom for instance of PressurePlate_Hazard");
                    MethodInfo mOnDisable = typeof(PressurePlate_Hazard).GetMethod("OnDisable", eFlags);
                    mOnDisable.Invoke(__instance, null);
                }
                else if (__instance.GetType() == typeof(PressurePlate_HazardTrigger) && WobSettings.Get("Options", "RemovePressurePlateTrigger", false))
                {
                    //WobPlugin.Log("this is running Postfix_Hazard_SetRoom for instance of PressurePlate_HazardTrigger");
                    MethodInfo mOnDisable = typeof(PressurePlate_HazardTrigger).GetMethod("OnDisable", eFlags);
                    mOnDisable.Invoke(__instance, null);
                }
                else if (__instance.GetType() == typeof(ProximityMine_Hazard) && WobSettings.Get("Options", "RemoveProximityMine", false))
                {
                    //WobPlugin.Log("this is running Postfix_Hazard_SetRoom for instance of ProximityMine_Hazard");
                    MethodInfo mOnDisable = typeof(ProximityMine_Hazard).GetMethod("OnDisable", eFlags);
                    mOnDisable.Invoke(__instance, null);
                }
                else if (__instance.GetType() == typeof(ProximityProjectile_Hazard) && WobSettings.Get("Options", "RemoveProximityProjectile", false))
                {
                    //WobPlugin.Log("this is running Postfix_Hazard_SetRoom for instance of ProximityProjectile_Hazard");
                    MethodInfo mOnDisable = typeof(ProximityProjectile_Hazard).GetMethod("OnDisable", eFlags);
                    mOnDisable.Invoke(__instance, null);
                }
                else if (__instance.GetType() == typeof(RaycastTurret_Hazard) && WobSettings.Get("Options", "RemoveRaycastTurret", false))
                {
                    //WobPlugin.Log("this is running Postfix_Hazard_SetRoom for instance of RaycastTurret_Hazard");
                    MethodInfo mOnDisable = typeof(RaycastTurret_Hazard).GetMethod("OnDisable", eFlags);
                    mOnDisable.Invoke(__instance, null);
                }
                else if (__instance.GetType() == typeof(Turret_Hazard) && WobSettings.Get("Options", "RemoveTurret", false))
                {
                    //WobPlugin.Log("this is running Postfix_Hazard_SetRoom for instance of Turret_Hazard");
                    MethodInfo mOnDisable = typeof(Turret_Hazard).GetMethod("OnDisable", eFlags);
                    mOnDisable.Invoke(__instance, null);
                }
                else if (__instance.GetType() == typeof(Sentry_Hazard) && WobSettings.Get("Options", "RemoveSentry", false))
                {
                    //WobPlugin.Log("this is running Postfix_Hazard_SetRoom for instance of Sentry_Hazard");
                    MethodInfo mOnDisable = typeof(Sentry_Hazard).GetMethod("OnDisable", eFlags);
                    mOnDisable.Invoke(__instance, null);
                }
                else if (__instance.GetType() == typeof(SnowMound_Hazard) && WobSettings.Get("Options", "RemoveSnowMound", false))
                {
                    //WobPlugin.Log("this is running Postfix_Hazard_SetRoom for instance of SnowMound_Hazard");
                    MethodInfo mOnDisable = typeof(SnowMound_Hazard).GetMethod("OnDisable", eFlags);
                    mOnDisable.Invoke(__instance, null);
                }
                else if (__instance.GetType() == typeof(SpikeTrap_Hazard) && WobSettings.Get("Options", "RemoveSpikeTrap", false))
                {
                    //WobPlugin.Log("this is running Postfix_Hazard_SetRoom for instance of RemoveSpikeTrap");
                    MethodInfo mOnDisable = typeof(SpikeTrap_Hazard).GetMethod("OnDisable", eFlags);
                    mOnDisable.Invoke(__instance, null);
                }
                else if (__instance.GetType() == typeof(TallSpike_Hazard) && WobSettings.Get("Options", "RemoveTallSpike", false))
                {
                    //WobPlugin.Log("this is running Postfix_Hazard_SetRoom for instance of TallSpike_Hazard");
                    MethodInfo mOnDisable = typeof(TallSpike_Hazard).GetMethod("OnDisable", eFlags);
                    mOnDisable.Invoke(__instance, null);
                }
                else if (__instance.GetType() == typeof(TidalWave_Hazard) && WobSettings.Get("Options", "RemoveTidalWave", false))
                {
                    //WobPlugin.Log("this is running Postfix_Hazard_SetRoom for instance of TidalWave_Hazard");
                    MethodInfo mOnDisable = typeof(TidalWave_Hazard).GetMethod("OnDisable", eFlags);
                    mOnDisable.Invoke(__instance, null);
                }
                else if (__instance.GetType() == typeof(Windmill_Hazard) && WobSettings.Get("Options", "RemoveWindmill", false))
                {
                    //WobPlugin.Log("this is running Postfix_Hazard_SetRoom for instance of Windmill_Hazard");
                    MethodInfo mOnDisable = typeof(Windmill_Hazard).GetMethod("OnDisable", eFlags);
                    mOnDisable.Invoke(__instance, null);
                }
                else
                {
                    WobPlugin.Log("this is skipping Postfix_Hazard_SetRoom for " + __instance.GetType());
                }
            }
        }

    }
}