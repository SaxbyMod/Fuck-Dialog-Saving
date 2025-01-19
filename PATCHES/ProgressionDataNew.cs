using DiskCardGame;
using HarmonyLib;
using System;

namespace Fuck_Dialouge_Saving.PATCHES
{
    [HarmonyPatch(nameof(ProgressionData))]
    public static class ProgressionDataNew
    {
        [HarmonyPrefix]
        public static void SetAbilityLearned(Ability ability)
        {
            if (!ProgressionData.Data.learnedAbilities.Contains(ability))
            {
                Console.WriteLine($"{Fuck_Dialog_Saving.PluginGuid}: I was told not to save the Ability: {ability.ToString()}");
            }
        }
        [HarmonyPrefix]
        public static void SetMechanicLearned(MechanicsConcept mechanic)
        {
            if (!SaveFile.IsAscension && !ProgressionData.Data.learnedMechanics.Contains(mechanic))
            {
                Console.WriteLine($"{Fuck_Dialog_Saving.PluginGuid}: I was told not to save the Mechanic: {mechanic.ToString()}");
            }
        }
        [HarmonyPrefix]
        public static void SetCardLearned(CardInfo card)
        {
            if (!ProgressionData.Data.learnedCards.Contains(card.name))
            {
                Console.WriteLine($"{Fuck_Dialog_Saving.PluginGuid}: I was told not to save the Card: {card.ToString()}");
            }
        }
        [HarmonyPrefix]
        public static void SetCardIntroduced(CardInfo card)
        {
            if (!ProgressionData.Data.introducedCards.Contains(card.name))
            {
                Console.WriteLine($"{Fuck_Dialog_Saving.PluginGuid}: I was told not to save the Introduced Card: {card.name.ToString()}");
            }
        }
        [HarmonyPrefix]
        public static void SetConsumableIntroduced(ItemData item)
        {
            Console.WriteLine($"{Fuck_Dialog_Saving.PluginGuid}: I was told not to save the Introduced Cosnsumable: {item.ToString()}");
        }
        [HarmonyPrefix]
        public static void SetConsumableIntroduced(string name)
        {
            if (!ProgressionData.Data.introducedConsumables.Contains(name))
            {
                Console.WriteLine($"{Fuck_Dialog_Saving.PluginGuid}: I was told not to save the Introduced Consumable: {name.ToString()}");
            }
        }
    }
}
