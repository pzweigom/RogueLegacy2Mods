using System;
using System.Reflection;
using BepInEx;
using HarmonyLib;
using UnityEngine;
using Wob_Common;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;
using static UnityEngine.GraphicsBuffer;

namespace Pzw1 {
    [BepInPlugin("pzw1.RemoveEnemies", "Remove Enemies", "1.0.0" )]
    public partial class Pzw1_RemoveEnemies : BaseUnityPlugin {
        // Main method that kicks everything off
        protected void Awake() {
            // Set up the logger and basic config items
            WobPlugin.Initialise( this, this.Logger );
            // Create/read the mod specific configuration options
            // Example setting - delete or replace
            WobSettings.Add(new WobSettings.Boolean("Options", "RemoveSkeleton", "Remove the Skeletons", false));
            WobSettings.Add(new WobSettings.Boolean("Options", "RemoveWolf", "Remove the Wolfs", false));
            WobSettings.Add(new WobSettings.Boolean("Options", "RemoveFlyingSword", "Remove the Flying Swords", false));
            WobSettings.Add(new WobSettings.Boolean("Options", "RemoveFlyingShield", "Remove the Flying Shields", false));
            WobSettings.Add(new WobSettings.Boolean("Options", "RemoveFlyingAxe", "Remove the Flying Axes", false));
            WobSettings.Add(new WobSettings.Boolean("Options", "RemoveFlyingHammer", "Remove the Flying Hammers", false));
            WobSettings.Add(new WobSettings.Boolean("Options", "RemoveFlyingHunter", "Remove the Flying Hunters", false));
            WobSettings.Add(new WobSettings.Boolean("Options", "RemoveEggplant", "Remove the Eggplants", false));
            WobSettings.Add(new WobSettings.Boolean("Options", "RemoveZombie", "Remove the Zombies", false));
            WobSettings.Add(new WobSettings.Boolean("Options", "RemoveEyeball", "Remove the Eyeballs", false));
            WobSettings.Add(new WobSettings.Boolean("Options", "RemoveSpearKnight", "Remove the Spear Knights", false));
            WobSettings.Add(new WobSettings.Boolean("Options", "RemoveSwordKnight", "Remove the Sword Knights", false));
            WobSettings.Add(new WobSettings.Boolean("Options", "RemoveBouncySpike", "Remove the Bouncy Spikes - the invinicible spikes that bounce around", false));
            WobSettings.Add(new WobSettings.Boolean("Options", "RemoveStarburst", "Remove the Starbursts", false));
            WobSettings.Add(new WobSettings.Boolean("Options", "RemoveFlyingBurst", "Remove the FlyingBursts", false));
            WobSettings.Add(new WobSettings.Boolean("Options", "RemoveSlug", "Remove the Slugs", false));
            WobSettings.Add(new WobSettings.Boolean("Options", "RemoveRocketBox", "Remove the RocketBoxs", false));
            WobSettings.Add(new WobSettings.Boolean("Options", "RemoveNinja", "Remove the Ninjas", false));
            WobSettings.Add(new WobSettings.Boolean("Options", "RemoveFlamer", "Remove the Flamers", false));
            WobSettings.Add(new WobSettings.Boolean("Options", "RemoveArcThrower", "Remove the Arc Throwers", false));
            WobSettings.Add(new WobSettings.Boolean("Options", "RemoveMimicChest", "Remove the Mimic Chests", false));
            WobSettings.Add(new WobSettings.Boolean("Options", "RemoveVolcano", "Remove the Volcanos", false));
            WobSettings.Add(new WobSettings.Boolean("Options", "RemoveTarget", "Remove the Targets", false));
            WobSettings.Add(new WobSettings.Boolean("Options", "RemoveGhost", "Remove the Ghosts", false));
            WobSettings.Add(new WobSettings.Boolean("Options", "RemoveSniper", "Remove the Snipers", false));
            WobSettings.Add(new WobSettings.Boolean("Options", "RemoveRogueKnight", "Remove the Rogue Knights", false));
            WobSettings.Add(new WobSettings.Boolean("Options", "RemoveBlobFish", "Remove the Blob Fishs", false));
            WobSettings.Add(new WobSettings.Boolean("Options", "RemoveFlyingSkull", "Remove the Flying Skulls", false));
            WobSettings.Add(new WobSettings.Boolean("Options", "RemoveJumpWallStick", "Remove the Jump Wall Sticks", false));
            WobSettings.Add(new WobSettings.Boolean("Options", "RemoveSkeletonArcher", "Remove the Skeleton Archers", false));
            WobSettings.Add(new WobSettings.Boolean("Options", "RemovePlant", "Remove the Plants", false));
            WobSettings.Add(new WobSettings.Boolean("Options", "RemoveAxeKnight", "Remove the Axe Knights", false));
            WobSettings.Add(new WobSettings.Boolean("Options", "RemoveStealthAssassin", "Remove the Stealth Assassins", false));
            WobSettings.Add(new WobSettings.Boolean("Options", "RemoveTopShotHazard", "Remove the Top Shot Hazards", false));
            WobSettings.Add(new WobSettings.Boolean("Options", "RemoveFireball", "Remove the Fireballs", false));
            WobSettings.Add(new WobSettings.Boolean("Options", "RemoveElementalFire", "Remove the Elemental Fires", false));
            WobSettings.Add(new WobSettings.Boolean("Options", "RemoveElementalIce", "Remove the Elemental Ices", false));
            WobSettings.Add(new WobSettings.Boolean("Options", "RemoveElementalBounce", "Remove the Elemental Bounces", false));
            WobSettings.Add(new WobSettings.Boolean("Options", "RemoveElementalDash", "Remove the Elemental Dashs", false));
            WobSettings.Add(new WobSettings.Boolean("Options", "RemoveElementalCurse", "Remove the Elemental Curses", false));
            WobSettings.Add(new WobSettings.Boolean("Options", "RemoveSpellswordBoss", "Remove the Spellsword Boss", false));
            WobSettings.Add(new WobSettings.Boolean("Options", "RemoveWisp", "Remove the Wisps", false));
            WobSettings.Add(new WobSettings.Boolean("Options", "RemoveDummy", "Remove the Dummies", false));
            WobSettings.Add(new WobSettings.Boolean("Options", "RemoveDancingBoss", "Remove the Dancing Boss", false));
            WobSettings.Add(new WobSettings.Boolean("Options", "RemoveSkeletonBossA", "Remove the Skeleton Boss A", false));
            WobSettings.Add(new WobSettings.Boolean("Options", "RemoveSkeletonBossB", "Remove the Skeleton Boss B", false));
            WobSettings.Add(new WobSettings.Boolean("Options", "RemoveStudyBoss", "Remove the Study Bosses", false));
            WobSettings.Add(new WobSettings.Boolean("Options", "RemoveMimicChestBoss", "Remove the Mimic Chest Boss", false));
            WobSettings.Add(new WobSettings.Boolean("Options", "RemovePaintingEnemy", "Remove the Painting Enemies", false));
            WobSettings.Add(new WobSettings.Boolean("Options", "RemoveEyeballBoss_Left", "Remove the Eyeball Boss Left", false));
            WobSettings.Add(new WobSettings.Boolean("Options", "RemoveEyeballBoss_Right", "Remove the Eyeball Boss Right", false));
            WobSettings.Add(new WobSettings.Boolean("Options", "RemoveEyeballBoss_Bottom", "Remove the Eyeball Boss Bottom", false));
            WobSettings.Add(new WobSettings.Boolean("Options", "RemoveEyeballBoss_Middle", "Remove the Eyeball Boss Middle", false));
            WobSettings.Add(new WobSettings.Boolean("Options", "RemoveCaveBoss", "Remove the Cave Bosses", false));
            WobSettings.Add(new WobSettings.Boolean("Options", "RemoveTraitorBoss", "Remove the Traitor Boss", false));
            WobSettings.Add(new WobSettings.Boolean("Options", "RemoveFinalBoss", "Remove the Final Boss", false));
            WobSettings.Add(new WobSettings.Boolean("Options", "RemoveAny", "Remove slot that can be any enemy", false));

            // code generator
            //foreach (EnemyType enemyType in (EnemyType[])Enum.GetValues(typeof(EnemyType)))
            //{
            //    WobPlugin.Log("else if (EnemyType."+ enemyType+".Equals(enemyType) && WobSettings.Get(\"Options\", \"Remove"+ enemyType+"\", false))");
            //    WobPlugin.Log("{");
            //    WobPlugin.Log("return false;");
            //    WobPlugin.Log("}");
            //}

            // Apply the patches if the mod is enabled
            WobPlugin.Patch();
        }

        [HarmonyPatch(typeof(EnemyLibrary), "GetEnemyPrefab")]
        internal static class EnemyLibrary_GetEnemyPrefab
        {
            internal static bool Prefix(EnemyType enemyType)
            {
                //WobPlugin.Log("running Prefix_EnemyLibrary_GetEnemyPrefab for enemyType: " + enemyType);

                if (EnemyType.Skeleton.Equals(enemyType) && WobSettings.Get("Options", "RemoveSkeleton", false))
                {
                    return false;
                }
                else if (EnemyType.Wolf.Equals(enemyType) && WobSettings.Get("Options", "RemoveWolf", false))
                {
                    return false;
                }
                else if (EnemyType.FlyingSword.Equals(enemyType) && WobSettings.Get("Options", "RemoveFlyingSword", false))
                {
                    return false;
                }
                else if (EnemyType.FlyingShield.Equals(enemyType) && WobSettings.Get("Options", "RemoveFlyingShield", false))
                {
                    return false;
                }
                else if (EnemyType.FlyingAxe.Equals(enemyType) && WobSettings.Get("Options", "RemoveFlyingAxe", false))
                {
                    return false;
                }
                else if (EnemyType.FlyingHammer.Equals(enemyType) && WobSettings.Get("Options", "RemoveFlyingHammer", false))
                {
                    return false;
                }
                else if (EnemyType.FlyingHunter.Equals(enemyType) && WobSettings.Get("Options", "RemoveFlyingHunter", false))
                {
                    return false;
                }
                else if (EnemyType.Eggplant.Equals(enemyType) && WobSettings.Get("Options", "RemoveEggplant", false))
                {
                    return false;
                }
                else if (EnemyType.Zombie.Equals(enemyType) && WobSettings.Get("Options", "RemoveZombie", false))
                {
                    return false;
                }
                else if (EnemyType.Eyeball.Equals(enemyType) && WobSettings.Get("Options", "RemoveEyeball", false))
                {
                    return false;
                }
                else if (EnemyType.SpearKnight.Equals(enemyType) && WobSettings.Get("Options", "RemoveSpearKnight", false))
                {
                    return false;
                }
                else if (EnemyType.SwordKnight.Equals(enemyType) && WobSettings.Get("Options", "RemoveSwordKnight", false))
                {
                    return false;
                }
                else if (EnemyType.BouncySpike.Equals(enemyType) && WobSettings.Get("Options", "RemoveBouncySpike", false))
                {
                    //WobPlugin.Log("running Prefix_EnemyLibrary_GetEnemyPrefab for BouncySpike");
                    return false;
                }
                else if (EnemyType.Starburst.Equals(enemyType) && WobSettings.Get("Options", "RemoveStarburst", false))
                {
                    return false;
                }
                else if (EnemyType.FlyingBurst.Equals(enemyType) && WobSettings.Get("Options", "RemoveFlyingBurst", false))
                {
                    return false;
                }
                else if (EnemyType.Slug.Equals(enemyType) && WobSettings.Get("Options", "RemoveSlug", false))
                {
                    return false;
                }
                else if (EnemyType.RocketBox.Equals(enemyType) && WobSettings.Get("Options", "RemoveRocketBox", false))
                {
                    return false;
                }
                else if (EnemyType.Ninja.Equals(enemyType) && WobSettings.Get("Options", "RemoveNinja", false))
                {
                    return false;
                }
                else if (EnemyType.Flamer.Equals(enemyType) && WobSettings.Get("Options", "RemoveFlamer", false))
                {
                    return false;
                }
                else if (EnemyType.ArcThrower.Equals(enemyType) && WobSettings.Get("Options", "RemoveArcThrower", false))
                {
                    return false;
                }
                else if (EnemyType.MimicChest.Equals(enemyType) && WobSettings.Get("Options", "RemoveMimicChest", false))
                {
                    return false;
                }
                else if (EnemyType.Volcano.Equals(enemyType) && WobSettings.Get("Options", "RemoveVolcano", false))
                {
                    return false;
                }
                else if (EnemyType.Target.Equals(enemyType) && WobSettings.Get("Options", "RemoveTarget", false))
                {
                    return false;
                }
                else if (EnemyType.Ghost.Equals(enemyType) && WobSettings.Get("Options", "RemoveGhost", false))
                {
                    return false;
                }
                else if (EnemyType.Sniper.Equals(enemyType) && WobSettings.Get("Options", "RemoveSniper", false))
                {
                    return false;
                }
                else if (EnemyType.RogueKnight.Equals(enemyType) && WobSettings.Get("Options", "RemoveRogueKnight", false))
                {
                    return false;
                }
                else if (EnemyType.BlobFish.Equals(enemyType) && WobSettings.Get("Options", "RemoveBlobFish", false))
                {
                    return false;
                }
                else if (EnemyType.FlyingSkull.Equals(enemyType) && WobSettings.Get("Options", "RemoveFlyingSkull", false))
                {
                    return false;
                }
                else if (EnemyType.JumpWallStick.Equals(enemyType) && WobSettings.Get("Options", "RemoveJumpWallStick", false))
                {
                    return false;
                }
                else if (EnemyType.SkeletonArcher.Equals(enemyType) && WobSettings.Get("Options", "RemoveSkeletonArcher", false))
                {
                    return false;
                }
                else if (EnemyType.Plant.Equals(enemyType) && WobSettings.Get("Options", "RemovePlant", false))
                {
                    return false;
                }
                else if (EnemyType.AxeKnight.Equals(enemyType) && WobSettings.Get("Options", "RemoveAxeKnight", false))
                {
                    return false;
                }
                else if (EnemyType.StealthAssassin.Equals(enemyType) && WobSettings.Get("Options", "RemoveStealthAssassin", false))
                {
                    return false;
                }
                else if (EnemyType.TopShotHazard.Equals(enemyType) && WobSettings.Get("Options", "RemoveTopShotHazard", false))
                {
                    return false;
                }
                else if (EnemyType.Fireball.Equals(enemyType) && WobSettings.Get("Options", "RemoveFireball", false))
                {
                    return false;
                }
                else if (EnemyType.ElementalFire.Equals(enemyType) && WobSettings.Get("Options", "RemoveElementalFire", false))
                {
                    return false;
                }
                else if (EnemyType.ElementalIce.Equals(enemyType) && WobSettings.Get("Options", "RemoveElementalIce", false))
                {
                    return false;
                }
                else if (EnemyType.ElementalBounce.Equals(enemyType) && WobSettings.Get("Options", "RemoveElementalBounce", false))
                {
                    return false;
                }
                else if (EnemyType.ElementalDash.Equals(enemyType) && WobSettings.Get("Options", "RemoveElementalDash", false))
                {
                    return false;
                }
                else if (EnemyType.ElementalCurse.Equals(enemyType) && WobSettings.Get("Options", "RemoveElementalCurse", false))
                {
                    return false;
                }
                else if (EnemyType.SpellswordBoss.Equals(enemyType) && WobSettings.Get("Options", "RemoveSpellswordBoss", false))
                {
                    return false;
                }
                else if (EnemyType.Wisp.Equals(enemyType) && WobSettings.Get("Options", "RemoveWisp", false))
                {
                    return false;
                }
                else if (EnemyType.Dummy.Equals(enemyType) && WobSettings.Get("Options", "RemoveDummy", false))
                {
                    return false;
                }
                else if (EnemyType.DancingBoss.Equals(enemyType) && WobSettings.Get("Options", "RemoveDancingBoss", false))
                {
                    return false;
                }
                else if (EnemyType.SkeletonBossA.Equals(enemyType) && WobSettings.Get("Options", "RemoveSkeletonBossA", false))
                {
                    return false;
                }
                else if (EnemyType.SkeletonBossB.Equals(enemyType) && WobSettings.Get("Options", "RemoveSkeletonBossB", false))
                {
                    return false;
                }
                else if (EnemyType.StudyBoss.Equals(enemyType) && WobSettings.Get("Options", "RemoveStudyBoss", false))
                {
                    return false;
                }
                else if (EnemyType.MimicChestBoss.Equals(enemyType) && WobSettings.Get("Options", "RemoveMimicChestBoss", false))
                {
                    return false;
                }
                else if (EnemyType.PaintingEnemy.Equals(enemyType) && WobSettings.Get("Options", "RemovePaintingEnemy", false))
                {
                    return false;
                }
                else if (EnemyType.EyeballBoss_Left.Equals(enemyType) && WobSettings.Get("Options", "RemoveEyeballBoss_Left", false))
                {
                    return false;
                }
                else if (EnemyType.EyeballBoss_Right.Equals(enemyType) && WobSettings.Get("Options", "RemoveEyeballBoss_Right", false))
                {
                    return false;
                }
                else if (EnemyType.EyeballBoss_Bottom.Equals(enemyType) && WobSettings.Get("Options", "RemoveEyeballBoss_Bottom", false))
                {
                    return false;
                }
                else if (EnemyType.EyeballBoss_Middle.Equals(enemyType) && WobSettings.Get("Options", "RemoveEyeballBoss_Middle", false))
                {
                    return false;
                }
                else if (EnemyType.CaveBoss.Equals(enemyType) && WobSettings.Get("Options", "RemoveCaveBoss", false))
                {
                    return false;
                }
                else if (EnemyType.TraitorBoss.Equals(enemyType) && WobSettings.Get("Options", "RemoveTraitorBoss", false))
                {
                    return false;
                }
                else if (EnemyType.FinalBoss.Equals(enemyType) && WobSettings.Get("Options", "RemoveFinalBoss", false))
                {
                    return false;
                }
                else if (EnemyType.Any.Equals(enemyType) && WobSettings.Get("Options", "RemoveAny", false))
                {
                    return false;
                }

                return true;
            }
        }



















    }
}