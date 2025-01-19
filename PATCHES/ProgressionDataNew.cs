using DiskCardGame;
using HarmonyLib;
using System;

namespace Fuck_Dialog_Saving.PATCHES
{
    public static class ProgressionDataPatches
    {
        // Patch for SetAbilityLearned
        [HarmonyPrefix, HarmonyPatch(nameof(ProgressionData.SetAbilityLearned))]
        public static bool PrefixAbilityLearned(Ability ability)
        {
            if (!ProgressionData.Data.learnedAbilities.Contains(ability))
            {
                Console.WriteLine($"[ProgressionDataPatches] Skipping saving ability: {ability}");
            }
            return true;
        }

        // Patch for SetMechanicLearned
        [HarmonyPrefix, HarmonyPatch(nameof(ProgressionData.SetMechanicLearned))]
        public static bool PrefixMechanicLearned(MechanicsConcept mechanic)
        {
            if (!SaveFile.IsAscension && !ProgressionData.Data.learnedMechanics.Contains(mechanic))
            {
                Console.WriteLine($"[ProgressionDataPatches] Skipping saving mechanic: {mechanic}");
            }
            return true;
        }

        // Patch for SetCardLearned
        [HarmonyPrefix, HarmonyPatch(nameof(ProgressionData.SetCardLearned))]
        public static bool PrefixCardLearned(CardInfo card)
        {
            if (!ProgressionData.Data.learnedCards.Contains(card.name))
            {
                Console.WriteLine($"[ProgressionDataPatches] Skipping saving card: {card.name}");
            }
            return true;
        }

        // Patch for SetCardIntroduced
        [HarmonyPrefix, HarmonyPatch(nameof(ProgressionData.SetCardIntroduced))]
        public static bool PrefixCardIntroduced(CardInfo card)
        {
            if (!ProgressionData.Data.introducedCards.Contains(card.name))
            {
                Console.WriteLine($"[ProgressionDataPatches] Skipping saving introduced card: {card.name}");
            }
            return true;
        }

        // Patch for SetConsumableIntroduced (ItemData overload)
        [HarmonyPrefix, HarmonyPatch(nameof(ProgressionData.SetConsumableIntroduced))]
        public static bool PrefixItemIntroduced(ItemData item)
        {
            {
                Console.WriteLine($"[ProgressionDataPatches] Skipping saving introduced consumable: {item}");
            }
            return true;
        }

        // Patch for SetConsumableIntroduced (string overload)
        [HarmonyPrefix, HarmonyPatch(nameof(ProgressionData.SetConsumableIntroduced))]
        public static bool PrefixItemIntroduced(string name)
        {
            if (!ProgressionData.Data.introducedConsumables.Contains(name))
            {
                Console.WriteLine($"[ProgressionDataPatches] Skipping saving introduced consumable: {name}");
            }
            return true;
        }
    }
}