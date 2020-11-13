using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;
 
namespace OratiumMod.Items.Weapons.Throwing
{
    public class ThornPlate : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Teleportation Orb");
        }
        
        public override void SetDefaults()
        {
            item.damage = 30;           //this is the item damage
            item.thrown = true;             //this make the item do throwing damage
            item.noMelee = true;
            item.width = 20;
            item.height = 20;
            item.useTime = 10;       //this is how fast you use the item
            item.useAnimation = 11;   //this is how fast the animation when the item is used
            item.useStyle = 1;      
            item.knockBack = 6;
            item.value = 10;
            item.rare = 1;
            item.reuseDelay = 20;    //this is the item delay
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;       //this make the item auto reuse
            item.shoot = mod.ProjectileType("ThornPlateProjectile");  //javelin projectile
            item.shootSpeed = 10f;     //projectile speed
            item.useTurn = true;
            item.maxStack = 999;       //this is the max stack of this item
            item.consumable = true;  //this make the item consumable when used
            item.noUseGraphic = true;
                       
        }
        public override void AddRecipes()  //How to craft this item
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("DiviniteOre"), 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
