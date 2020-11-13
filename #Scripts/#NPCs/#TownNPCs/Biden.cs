using System;
using OratiumMod.Items.Dusts;
using OratiumMod.Items;
using OratiumMod.Items.Bars;
using OratiumMod.Items.Weapons.Spears;
using OratiumMod.Items.Projectiles;
using OratiumMod.Items.Tiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace OratiumMod.Items.NPCs.TownNPCs
{
	// [AutoloadHead] and npc.townNPC are extremely important and absolutely both necessary for any Town NPC to work at all.
	[AutoloadHead]
	public class Biden : ModNPC
	{
		public override string Texture => "OratiumMod/Items/NPCs/TownNPCs/Biden";

		public override string[] AltTextures => new[] { "OratiumMod/Items/NPCs/TownNPCs/Biden_Alt_1" };

		public override bool Autoload(ref string name) {
			name = "President";
			return mod.Properties.Autoload;
		}

		public override void SetStaticDefaults() {
			// DisplayName automatically assigned from .lang files, but the commented line below is the normal approach.
			// DisplayName.SetDefault("Example Person");
			Main.npcFrameCount[npc.type] = 25;
			NPCID.Sets.ExtraFramesCount[npc.type] = 9;
			NPCID.Sets.AttackFrameCount[npc.type] = 4;
			NPCID.Sets.DangerDetectRange[npc.type] = 700;
			NPCID.Sets.AttackType[npc.type] = 0;
			NPCID.Sets.AttackTime[npc.type] = 90;
			NPCID.Sets.AttackAverageChance[npc.type] = 30;
			NPCID.Sets.HatOffsetY[npc.type] = 4;
		}

		public override void SetDefaults() {
			npc.townNPC = true;
			npc.friendly = true;
			npc.width = 18;
			npc.height = 40;
			npc.aiStyle = 7;
			npc.damage = 10;
			npc.defense = 15;
			npc.lifeMax = 250;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.knockBackResist = 0.5f;
			animationType = NPCID.Guide;
		}

		public override void HitEffect(int hitDirection, double damage) {
			int num = npc.life > 0 ? 1 : 5;
			for (int k = 0; k < num; k++) {
				Dust.NewDust(npc.position, npc.width, npc.height, ModContent.DustType<Sparkle>());
			}
		}

	 public override bool CanTownNPCSpawn(int numTownNPCs, int money) //Whether or not the conditions have been met for this town NPC to be able to move into town.
        {
            if (NPC.downedBoss1)  //so after the EoC is killed
            {
                return true;
            }
            return false;
        }
		  public override bool CheckConditions(int left, int right, int top, int bottom)    //Allows you to define special conditions required for this town NPC's house
        {
            return true;  //so when a house is available the npc will  spawn
        }
		public override void SetChatButtons(ref string button, ref string button2)
        {
            button = Language.GetTextValue("LegacyInterface.28");
            button2 = "Button Name";
        }
	
		public override void OnChatButtonClicked(bool firstButton, ref bool shop)
        {
            if (firstButton)
            {
                shop = true;
            }
            else
            {
                Main.npcChatText = "Hmm Vad Ska Stå Här?";
            }
        }
        public override void SetupShop(Chest shop, ref int nextSlot)
        {
            shop.item[nextSlot].SetDefaults(mod.ItemType("BlisterBar"));
            nextSlot++;
			shop.item[nextSlot].SetDefaults(mod.ItemType("BlisterPickaxe"));
            nextSlot++;
        }

/*
		// Example Person needs a house built out of OratiumMod tiles. You can delete this whole method in your townNPC for the regular house conditions.
		public override bool CheckConditions(int left, int right, int top, int bottom) {
			int score = 0;
			for (int x = left; x <= right; x++) {
				for (int y = top; y <= bottom; y++) {
					int type = Main.tile[x, y].type;
					if (type == ModContent.TileType<ExampleBlock>() || type == ModContent.TileType<ExampleChair>() || type == ModContent.TileType<ExampleWorkbench>() || type == ModContent.TileType<ExampleBed>() || type == ModContent.TileType<ExampleDoorOpen>() || type == ModContent.TileType<ExampleDoorClosed>()) {
						score++;
					}
					if (Main.tile[x, y].wall == ModContent.WallType<ExampleWall>()) {
						score++;
					}
				}
			}
			return score >= (right - left) * (bottom - top) / 2;
		}
*/
		public override string TownNPCName() {
			switch (WorldGen.genRand.Next(4)) {
				case 0:
					return "Biden";
				case 1:
					return "Biden";
				case 2:
					return "Biden";
				default:
					return "Biden";
			}
		}

		public override void FindFrame(int frameHeight) {
			/*npc.frame.Width = 40;
			if (((int)Main.time / 10) % 2 == 0)
			{
				npc.frame.X = 40;
			}
			else
			{
				npc.frame.X = 0;
			}*/
		}

		public override string GetChat() 
        {
			int partyGirl = NPC.FindFirstNPC(NPCID.PartyGirl);
			if (partyGirl >= 0 && Main.rand.NextBool(4)) {
				return "Can you please tell " + Main.npc[partyGirl].GivenName + " to stop decorating my house with colors?";
			} 
			switch (Main.rand.Next(4)) {
				case 0:
					return "Sometimes I feel like I'm different from everyone else here.";
				case 1:
					return "What's your favorite color? My favorite colors are white and black.";
				/*
                case 2:
					{
						// Main.npcChatCornerItem shows a single item in the corner, like the Angler Quest chat.
						Main.npcChatCornerItem = ItemID.HiveBackpack;
						return $"Hey, if you find a [i:{ItemID.HiveBackpack}], I can upgrade it for you.";
					}
                    */
				default:
					return "Will you shut up man.";
			}
		}

		/* 
		// Consider using this alternate approach to choosing a random thing. Very useful for a variety of use cases.
		// The WeightedRandom class needs "using Terraria.Utilities;" to use
		public override string GetChat()
		{
			WeightedRandom<string> chat = new WeightedRandom<string>();
			int partyGirl = NPC.FindFirstNPC(NPCID.PartyGirl);
			if (partyGirl >= 0 && Main.rand.NextBool(4))
			{
				chat.Add("Can you please tell " + Main.npc[partyGirl].GivenName + " to stop decorating my house with colors?");
			}
			chat.Add("Sometimes I feel like I'm different from everyone else here.");
			chat.Add("What's your favorite color? My favorite colors are white and black.");
			chat.Add("What? I don't have any arms or legs? Oh, don't be ridiculous!");
			chat.Add("This message has a weight of 5, meaning it appears 5 times more often.", 5.0);
			chat.Add("This message has a weight of 0.1, meaning it appears 10 times as rare.", 0.1);
			return chat; // chat is implicitly cast to a string. You can also do "return chat.Get();" if that makes you feel better
		}
		*/

/*
		public override void SetChatButtons(ref string button, ref string button2) {
			button = Language.GetTextValue("LegacyInterface.28");
			button2 = "Awesomeify";
			if (Main.LocalPlayer.HasItem(ItemID.HiveBackpack))
				button = "Upgrade " + Lang.GetItemNameValue(ItemID.HiveBackpack);
		}
        */
        /*
		public override void OnChatButtonClicked(bool firstButton, ref bool shop) 
        {
			if (firstButton) {
				// We want 3 different functionalities for chat buttons, so we use HasItem to change button 1 between a shop and upgrade action.
				if (Main.LocalPlayer.HasItem(ItemID.HiveBackpack))
				{
					Main.PlaySound(SoundID.Item37); // Reforge/Anvil sound
					Main.npcChatText = $"I upgraded your {Lang.GetItemNameValue(ItemID.HiveBackpack)} to a {Lang.GetItemNameValue(ModContent.ItemType<Items.Accessories.WaspNest>())}";
					int hiveBackpackItemIndex = Main.LocalPlayer.FindItem(ItemID.HiveBackpack);
					Main.LocalPlayer.inventory[hiveBackpackItemIndex].TurnToAir();
					Main.LocalPlayer.QuickSpawnItem(ModContent.ItemType<Items.Accessories.WaspNest>());
					return;
				}
				shop = false;
			}
			else {
				// If the 2nd button is pressed, open the inventory...
				Main.playerInventory = true;
				// remove the chat window...
				Main.npcChatText = "";
				// and start an instance of our UIState.
				ModContent.GetInstance<OratiumMod>().BidenUserInterface.SetState(new UI.BidenUI());
				// Note that even though we remove the chat window, Main.LocalPlayer.talkNPC will still be set correctly and we are still technically chatting with the npc.
			}
                
		}
/*
		public override void SetupShop(Chest shop, ref int nextSlot) 
        {
            
			shop.item[nextSlot].SetDefaults(ModContent.ItemType<ExampleItem>());
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ModContent.ItemType<EquipMaterial>());
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ModContent.ItemType<BossItem>());
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Placeable.ExampleWorkbench>());
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Placeable.ExampleChair>());
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Placeable.ExampleDoor>());
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Placeable.ExampleBed>());
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Placeable.ExampleChest>());
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ModContent.ItemType<ExamplePickaxe>());
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ModContent.ItemType<ExampleHamaxe>());
			nextSlot++;
			if (Main.LocalPlayer.HasBuff(BuffID.Lifeforce)) {
				shop.item[nextSlot].SetDefaults(ModContent.ItemType<ExampleHealingPotion>());
				nextSlot++;
			}
			if (Main.LocalPlayer.GetModPlayer<ExamplePlayer>().ZoneExample && !ModContent.GetInstance<ExampleConfigServer>().DisableExampleWings) {
				shop.item[nextSlot].SetDefaults(ModContent.ItemType<ExampleWings>());
				nextSlot++;
			}
			if (Main.moonPhase < 2) {
				shop.item[nextSlot].SetDefaults(ModContent.ItemType<ExampleSword>());
				nextSlot++;
			}
			else if (Main.moonPhase < 4) {
				shop.item[nextSlot].SetDefaults(ModContent.ItemType<ExampleGun>());
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Weapons.ExampleBullet>());
				nextSlot++;
			}
			else if (Main.moonPhase < 6) {
				shop.item[nextSlot].SetDefaults(ModContent.ItemType<ExampleStaff>());
				nextSlot++;
			}
			else {
			}
			// Here is an example of how your npc can sell items from other mods.
			var modSummonersAssociation = ModLoader.GetMod("SummonersAssociation");
			if (modSummonersAssociation != null) {
				shop.item[nextSlot].SetDefaults(modSummonersAssociation.ItemType("BloodTalisman"));
				nextSlot++;
			}

			if (!Main.LocalPlayer.GetModPlayer<ExamplePlayer>().BidenGiftReceived && ModContent.GetInstance<ExampleConfigServer>().BidenFreeGiftList != null)
			{
				foreach (var item in ModContent.GetInstance<ExampleConfigServer>().BidenFreeGiftList)
				{
					if (item.IsUnloaded)
						continue;
					shop.item[nextSlot].SetDefaults(item.Type);
					shop.item[nextSlot].shopCustomPrice = 0;
					shop.item[nextSlot].GetGlobalItem<ExampleInstancedGlobalItem>().BidenFreeGift = true;
					nextSlot++;
					// TODO: Have tModLoader handle index issues.
				}	
			}
            
		}
*/
		public override void NPCLoot() {
			Item.NewItem(npc.getRect(), ModContent.ItemType<Items.Accessories.AmmoBag>());
		}

/*
		public override void TownNPCAttackStrength(ref int damage, ref float knockback) {
			damage = 20;
			knockback = 4f;
		}

		public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown) {
			cooldown = 10;
			randExtraCooldown = 10;
		}

		public override void TownNPCAttackProj(ref int projType, ref int attackDelay) {
			projType = ModContent.ProjectileType<Sparkle>();
			attackDelay = 1;
		}

		public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset) {
			multiplier = 12f;
			randomOffset = 2f;
		}
        */
	}
}