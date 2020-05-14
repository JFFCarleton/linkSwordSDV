using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;
using StardewValley.Projectiles;
using StardewValley.Tools;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Xna.Framework;

namespace linkSword
{
    public class linkSword : Mod{
        private int linkSwordID;
        private IJsonAssetsApi JsonAssets;
        private Farmer player;

        //jsonAssets setup/////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        //borrowed from Cherry's code for now
        //when the game is launched, load up jsonAssets using SMapi to interact with files in the mod
        private void GameLoop_GameLaunched(object sender, GameLaunchedEventArgs e) {
            JsonAssets = Helper.ModRegistry.GetApi<IJsonAssetsApi>("spacechase0.JsonAssets");
            JsonAssets.LoadAssets(Path.Combine(Helper.DirectoryPath, "assets"));
        }

        //get the ID for the sword from JA into the game
        private void GameLoop_SaveLoaded (object sender, SaveLoadedEventArgs e){
            if (JsonAssets != null) { linkSwordID = JsonAssets.GetWeaponId("linkSword");}
            if (linkSwordID == -1) { Monitor.Log("jsonAssts linkSwordID failed", LogLevel.Warn); }
            this.player = Game1.player; //grab the player for calls later
        }

        //SMapi setup/////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public override void Entry(IModHelper helper) {

            helper.Events.GameLoop.GameLaunched += GameLoop_GameLaunched;
            helper.Events.GameLoop.SaveLoaded += GameLoop_SaveLoaded;
            helper.Events.Input.ButtonPressed += Input_ButtonPressed;

        }

        private void Input_ButtonPressed(object sender, ButtonPressedEventArgs e){
            //ensures that won't run unless the player is able to act, and they are using the "use tool" button.
            if (!Context.IsWorldReady || !Context.CanPlayerMove ||!e.Button.IsUseToolButton() ){ return; }

            /*ty kdau!
            //1. Check if the current item is a MeleeWeapon, stops nulls too! <3
            //2. Compare the current wep to make sure you're holding the right thing!
            //3. Check to see if player is at max HP
            */
            if (player.CurrentItem is MeleeWeapon heldWep && heldWep.InitialParentTileIndex == linkSwordID && player.health == player.maxHealth){
                
                //if yes, SHOOT SWORD BEAM!
                Game1.currentLocation.projectiles.Add(new SwordBeam(player));
                Monitor.Log("Pew Pew!", LogLevel.Warn);
           
            }else return;  
        }
    }//end of class linkSword

    //create interface for SMapi to use
    public interface IJsonAssetsApi{
        int GetWeaponId(string name);
        void LoadAssets(string path);
    }//end of interface IJasonAssetsApi
}//end of namespace


/*
//feeling like could need you, might delete later, IDK
Farmer player = Game1.player;
new BasicProjectile(
    0,                                                                  //int damageToFarmer
    1,                                                                  //int parentSheetIndex
    0,                                                                  //int bouncesTillDestruct
    0,                                                                  //int tailLength
    0.0f,                                                               //float rotationVelocity 
    -1.0f,                                                              //float xVelocity   
    -1.0f,                                                              //float yVelocity
    new Vector2(player.getStandingX()-16, player.getStandingY()-64-8),  //Vector2 startingPosition
    "",                                                                 //string collisionSound
    "",                                                                 //string firingSound
    false,                                                              //bool explode
    false,                                                              //bool damagesMonsters = false
    Game1.currentLocation,                                              //GameLocation location
    player,                                                             //Character firer
    false,                                                              //bool spriteFromObjectSheet
    null                                                                //onCollisionBehavior collisionBehavior
    )
    */
