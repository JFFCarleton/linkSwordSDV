using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;

namespace linkSword
{
    public class linkSword : Mod{
        private int linkSwordID;
        private IJsonAssetsApi JsonAssets;

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
        }

        //SMapi setup/////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public override void Entry(IModHelper helper) {

            helper.Events.GameLoop.GameLaunched += GameLoop_GameLaunched;
            helper.Events.GameLoop.SaveLoaded += GameLoop_SaveLoaded;
        }

    }//end of class linkSword

    //create interface for SMapi to use
    public interface IJsonAssetsApi{
        int GetWeaponId(string name);
        void LoadAssets(string path);
    }//end of interface IJasonAssetsApi
}//end of namespace
