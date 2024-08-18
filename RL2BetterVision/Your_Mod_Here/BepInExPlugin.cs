using System;
using System.Reflection;
using BepInEx;
using HarmonyLib;
using UnityEngine;
using Wob_Common;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;
using static UnityEngine.GraphicsBuffer;

namespace Pzw1 {
    [BepInPlugin("pzw1.BetterVision", "Better Vision", "1.0.0" )]
    public partial class Pzw1_BetterVision : BaseUnityPlugin {
        // Main method that kicks everything off
        protected void Awake() {
            // Set up the logger and basic config items
            WobPlugin.Initialise( this, this.Logger );

            // Apply the patches if the mod is enabled
            WobPlugin.Patch();
        }

        // this didn't do anything
        //[HarmonyPatch(typeof(MobilePostProcessOverrideController), "OnEnable")]
        //internal static class MobilePostProcessOverrideController_OnEnable
        //{
        //    private static BindingFlags eFlags = BindingFlags.Instance | BindingFlags.NonPublic;
        //    private static MethodInfo mOnDisable = typeof(MobilePostProcessOverrideController).GetMethod("OnDisable", eFlags);

        //    internal static void Postfix(MobilePostProcessOverrideController __instance)
        //    {
        //        WobPlugin.Log("running MobilePostProcessOverrideController_OnEnable");
        //        mOnDisable.Invoke(__instance, null);
        //    }
        //}

        //[HarmonyPatch(typeof(MobilePostProcessing), "ApplyProfileBlur")]
        //internal static class MobilePostProcessing_ApplyProfileBlur
        //{
        //    internal static void Postfix()
        //    {
        //        WobPlugin.Log("running MobilePostProcessing_ApplyProfileBlur");
        //    }
        //}

        //[HarmonyPatch(typeof(MobilePostProcessing), "ApplyShaderBlur")]
        //internal static class MobilePostProcessing_ApplyShaderBlur
        //{
        //    internal static void Postfix()
        //    {
        //        WobPlugin.Log("running MobilePostProcessing_ApplyShaderBlur");
        //    }
        //}

        //[HarmonyPatch(typeof(MobilePostProcessing), "ApplyProfileBloom")]
        //internal static class MobilePostProcessing_ApplyProfileBloom
        //{
        //    internal static void Postfix()
        //    {
        //        WobPlugin.Log("running MobilePostProcessing_ApplyProfileBloom");
        //    }
        //}

        //[HarmonyPatch(typeof(MobilePostProcessing), "ApplyShaderBloom")]
        //internal static class MobilePostProcessing_ApplyShaderBloom
        //{
        //    internal static void Postfix()
        //    {
        //        WobPlugin.Log("running MobilePostProcessing_ApplyShaderBloom");
        //    }
        //}

        //[HarmonyPatch(typeof(MobilePostProcessing), "ApplyProfileLut")]
        //internal static class MobilePostProcessing_ApplyProfileLut
        //{
        //    internal static void Postfix()
        //    {
        //        WobPlugin.Log("running MobilePostProcessing_ApplyProfileLut");
        //    }
        //}

        //[HarmonyPatch(typeof(MobilePostProcessing), "ApplyShaderLut")]
        //internal static class MobilePostProcessing_ApplyShaderLut
        //{
        //    internal static void Postfix()
        //    {
        //        WobPlugin.Log("running MobilePostProcessing_ApplyShaderLut");
        //    }
        //}

        //[HarmonyPatch(typeof(MobilePostProcessing), "ApplyProfileImageFiltering")]
        //internal static class MobilePostProcessing_ApplyProfileImageFiltering
        //{
        //    internal static void Postfix()
        //    {
        //        WobPlugin.Log("running MobilePostProcessing_ApplyProfileImageFiltering");
        //    }
        //}

        //[HarmonyPatch(typeof(MobilePostProcessing), "ApplyShaderImageFiltering")]
        //internal static class MobilePostProcessing_ApplyShaderImageFiltering
        //{
        //    internal static void Postfix()
        //    {
        //        WobPlugin.Log("running MobilePostProcessing_ApplyShaderImageFiltering");
        //    }
        //}

        //[HarmonyPatch(typeof(MobilePostProcessing), "ApplyProfileGradientMap")]
        //internal static class MobilePostProcessing_ApplyProfileGradientMap
        //{
        //    internal static void Postfix()
        //    {
        //        WobPlugin.Log("running MobilePostProcessing_ApplyProfileGradientMap");
        //    }
        //}

        //[HarmonyPatch(typeof(MobilePostProcessing), "ApplyShaderGradientMap")]
        //internal static class MobilePostProcessing_ApplyShaderGradientMap
        //{
        //    internal static void Postfix()
        //    {
        //        WobPlugin.Log("running MobilePostProcessing_ApplyShaderGradientMap");
        //    }
        //}

        //[HarmonyPatch(typeof(MobilePostProcessing), "ApplyProfileOverlayGradient")]
        //internal static class MobilePostProcessing_ApplyProfileOverlayGradient
        //{
        //    internal static void Postfix()
        //    {
        //        WobPlugin.Log("running MobilePostProcessing_ApplyProfileOverlayGradient");
        //    }
        //}

        //[HarmonyPatch(typeof(MobilePostProcessing), "ApplyShaderOverlayGradient")]
        //internal static class MobilePostProcessing_ApplyShaderOverlayGradient
        //{
        //    internal static void Postfix()
        //    {
        //        WobPlugin.Log("running MobilePostProcessing_ApplyShaderOverlayGradient");
        //    }
        //}

        //[HarmonyPatch(typeof(MobilePostProcessing), "ApplyProfileClampBlack")]
        //internal static class MobilePostProcessing_ApplyProfileClampBlack
        //{
        //    internal static void Postfix()
        //    {
        //        WobPlugin.Log("running MobilePostProcessing_ApplyProfileClampBlack");
        //    }
        //}

        //[HarmonyPatch(typeof(MobilePostProcessing), "ApplyShaderClampBlack")]
        //internal static class MobilePostProcessing_ApplyShaderClampBlack
        //{
        //    internal static void Postfix()
        //    {
        //        WobPlugin.Log("running MobilePostProcessing_ApplyShaderClampBlack");
        //    }
        //}

        //[HarmonyPatch(typeof(MobilePostProcessing), "ApplyProfileTint")]
        //internal static class MobilePostProcessing_ApplyProfileTint
        //{
        //    internal static void Postfix()
        //    {
        //        WobPlugin.Log("running MobilePostProcessing_ApplyProfileTint");
        //    }
        //}

        //[HarmonyPatch(typeof(MobilePostProcessing), "ApplyShaderTint")]
        //internal static class MobilePostProcessing_ApplyShaderTint
        //{
        //    internal static void Postfix()
        //    {
        //        WobPlugin.Log("running MobilePostProcessing_ApplyShaderTint");
        //    }
        //}


        //[HarmonyPatch(typeof(MobilePostProcessing), "ApplyShaderChromaticAbberation")]
        //internal static class MobilePostProcessing_ApplyShaderChromaticAbberation
        //{
        //    internal static void Postfix()
        //    {
        //        WobPlugin.Log("running MobilePostProcessing_ApplyShaderChromaticAbberation");
        //    }
        //}

        //[HarmonyPatch(typeof(MobilePostProcessing), "ApplyProfileDistortion")]
        //internal static class MobilePostProcessing_ApplyProfileDistortion
        //{
        //    internal static void Postfix()
        //    {
        //        WobPlugin.Log("running MobilePostProcessing_ApplyProfileDistortion");
        //    }
        //}

        //[HarmonyPatch(typeof(MobilePostProcessing), "ApplyShaderDistortion")]
        //internal static class MobilePostProcessing_ApplyShaderDistortion
        //{
        //    internal static void Postfix()
        //    {
        //        WobPlugin.Log("running MobilePostProcessing_ApplyShaderDistortion");
        //    }
        //}

        //[HarmonyPatch(typeof(MobilePostProcessing), "ApplyProfileVignette")]
        //internal static class MobilePostProcessing_ApplyProfileVignette
        //{
        //    internal static void Postfix()
        //    {
        //        WobPlugin.Log("running MobilePostProcessing_ApplyProfileVignette");
        //    }
        //}

        //[HarmonyPatch(typeof(MobilePostProcessing), "ApplyShaderVignette")]
        //internal static class MobilePostProcessing_ApplyShaderVignette
        //{
        //    internal static void Postfix()
        //    {
        //        WobPlugin.Log("running MobilePostProcessing_ApplyShaderVignette");
        //    }
        //}

        //[HarmonyPatch(typeof(MobilePostProcessing), "ApplyShaderMist")]
        //internal static class MobilePostProcessing_ApplyShaderMist
        //{
        //    internal static void Postfix()
        //    {
        //        WobPlugin.Log("running MobilePostProcessing_ApplyShaderMist");
        //    }
        //}

        [HarmonyPatch(typeof(MobilePostProcessing), "ApplyProfileCircularDarkness")]
        internal static class MobilePostProcessing_ApplyProfileCircularDarkness
        {
            internal static bool Prefix()
            {
                //WobPlugin.Log("skipping MobilePostProcessing_ApplyProfileCircularDarkness");
                return false;
            }
        }

    }
}