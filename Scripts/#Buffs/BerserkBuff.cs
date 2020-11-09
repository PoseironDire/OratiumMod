using OratiumMod.Items.Npcs;
using Terraria;
using Terraria.ModLoader;

namespace OratiumMod.Items.Buffs
{
    // Ethereal Flames is an example of a buff that causes constant loss of life.
    // See ExamplePlayer.UpdateBadLifeRegen and ExampleGlobalNPC.UpdateLifeRegen for more information.
    public class BerserkBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Berserk");
            Description.SetDefault("Lose all defence in exchange for tripled damage");
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
            longerExpertDebuff = true;
        }
    }
}