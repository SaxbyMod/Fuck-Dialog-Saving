using DiskCardGame;
using HarmonyLib;
using System;

namespace Fuck_Dialog_Saving.PATCHES
{
    [HarmonyPatch]
    internal static class ProgressionDataNew
    {
        // Patch for SetAbilityLearned
        [HarmonyPrefix, HarmonyPatch(typeof(ProgressionData), nameof(ProgressionData.SetAbilityLearned))]
        public static bool PrefixAbilityLearned(Ability ability)
        {
            if (!ProgressionData.Data.learnedAbilities.Contains(ability))
            {
                Console.WriteLine($"[ProgressionDataPatches] Skipping saving ability: {ability}");
            }
            return false;
        }

        // Patch for SetMechanicLearned
        [HarmonyPrefix, HarmonyPatch(typeof(ProgressionData), nameof(ProgressionData.SetMechanicLearned))]
        public static bool PrefixMechanicLearned(MechanicsConcept mechanic)
        {
            if (!SaveFile.IsAscension && !ProgressionData.Data.learnedMechanics.Contains(mechanic))
            {
                Console.WriteLine($"[ProgressionDataPatches] Skipping saving mechanic: {mechanic}");
            }
            return false;
        }

        // Patch for SetCardLearned
        [HarmonyPrefix, HarmonyPatch(typeof(ProgressionData), nameof(ProgressionData.SetCardLearned))]
        public static bool PrefixCardLearned(CardInfo card)
        {
            if (!ProgressionData.Data.learnedCards.Contains(card.name))
            {
                Console.WriteLine($"[ProgressionDataPatches] Skipping saving card: {card.name}");
            }
            return false;
        }

        // Patch for SetCardIntroduced
        [HarmonyPrefix, HarmonyPatch(typeof(ProgressionData), nameof(ProgressionData.SetCardIntroduced))]
        public static bool PrefixCardIntroduced(CardInfo card)
        {
            if (!ProgressionData.Data.introducedCards.Contains(card.name))
            {
                Console.WriteLine($"[ProgressionDataPatches] Skipping saving introduced card: {card.name}");
            }
            return false;
        }

        // Patch for SetConsumableIntroduced (ItemData overload)
        [HarmonyPrefix, HarmonyPatch(typeof(ProgressionData), nameof(ProgressionData.SetConsumableIntroduced), new Type[] {typeof(ItemData)})]
        public static bool PrefixItemIntroduced(ItemData item)
        {
            {
                Console.WriteLine($"[ProgressionDataPatches] Skipping saving introduced consumable: {item}");
            }
            return false;
        }

        // Patch for SetConsumableIntroduced (string overload)
        [HarmonyPrefix, HarmonyPatch(typeof(ProgressionData), nameof(ProgressionData.SetConsumableIntroduced), new Type[] { typeof(string) })]
        public static bool PrefixItemIntroduced(string name)
        {
            if (!ProgressionData.Data.introducedConsumables.Contains(name))
            {
                Console.WriteLine($"[ProgressionDataPatches] Skipping saving introduced consumable: {name}");
            }
            return false;
        }
    }
}