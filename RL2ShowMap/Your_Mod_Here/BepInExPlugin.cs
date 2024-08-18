using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using BepInEx;
using HarmonyLib;
using UnityEngine;
using Wob_Common;

namespace Pzw1 {
    [BepInPlugin("pzw1.ShowMap", "Show Map", "1.0.0" )]
    public partial class Pzw1_ShowMap : BaseUnityPlugin {
        // Main method that kicks everything off
        protected void Awake() {
            // Set up the logger and basic config items
            WobPlugin.Initialise( this, this.Logger );
            // Apply the patches if the mod is enabled
            WobPlugin.Patch();
        }

        //private static bool shouldDisplayAllRooms = false;

        //[HarmonyPatch(typeof(MapController), "CreateWorldMap")]
        //internal static class MapController_CreateWorldMap
        //{
        //    internal static void Postfix()
        //    {
        //        // use thread because this hangs forever in some situations
        //        Thread _thread;
        //        _thread = new Thread(new ThreadStart(DisplayAllRooms));
        //        _thread.Start();
        //        Timer timer = new Timer(TimeOut, _thread, 10000, Timeout.Infinite);
        //    }

        //    internal static void DisplayAllRooms()
        //    {
        //        shouldDisplayAllRooms = false;
        //        WobPlugin.Log("this is running MapController_CreateWorldMap");
        //        MapController.DisplayAllRooms();
        //        WobPlugin.Log("past MapController_CreateWorldMap");
        //        shouldDisplayAllRooms = true;
        //    }

        //    internal static void TimeOut(object state)
        //    {
        //        Thread _thread = (Thread)state;
        //        // Abort the thread - see the comments
        //        _thread.Abort();
        //        WobPlugin.Log("aborted thread for MapController_CreateWorldMap");
        //        shouldDisplayAllRooms = false;
        //    }
        //}

        //[HarmonyPatch(typeof(MapController), "OnBiomeEnter")]
        //internal static class MapController_OnBiomeEnter
        //{
        //    internal static void Postfix()
        //    {
        //        if (shouldDisplayAllRooms)
        //        {
        //            WobPlugin.Log("this is running MapController_OnBiomeEnter");
        //            MapController.DisplayAllRooms();
        //            shouldDisplayAllRooms = false;
        //        }
        //    }
        //}

        [HarmonyPatch(typeof(MapController), "OnBiomeEnter")]
        internal static class MapController_OnBiomeEnter
        {
            internal static void Postfix()
            {
                    WobPlugin.Log("this is running MapController_OnBiomeEnter");
                    MapController.SetAllBiomeVisibility(true, true, true);
            }
        }

        //[HarmonyPatch(typeof(MapController), "WasRoomVisited")]
        //internal static class MapController_WasRoomVisited
        //{
        //    internal static bool Postfix(bool originalResult)
        //    {
        //        WobPlugin.Log("this is running MapController_WasRoomVisited");
        //        return true;
        //    }
        //}

    }
}