﻿using System;
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
    class SwordBeam: BasicProjectile
    {
        public SwordBeam(Farmer player, Vector2 aimDir) //TODO: Make it shoot in the direction the player is slashing.
            : base(     
                    10,                                                                         //int damageToFarmer
                    9,                                                                          //int parentSheetIndex
                    0,                                                                          //int bouncesTillDestruct
                    0,                                                                          //int tailLength
                    0.0f,                                                                       //float rotationVelocity 
                    aimDir.X,                                                                   //float xVelocity   
                    aimDir.Y,                                                                   //float yVelocity
                    new Vector2(player.getStandingX() + 30, player.getStandingY() + 30),        //Vector2 startingPosition
                    "",                                                                         //string collisionSound
                    "",                                                                         //string firingSound
                    false,                                                                      //bool explode
                    false,                                                                      //bool damagesMonsters = false
                    Game1.currentLocation,                                                      //GameLocation location
                    player,                                                                     //Character firer
                    false,                                                                      //bool spriteFromObjectSheet
                    null                                                                        //onCollisionBehavior collisionBehavior
                    )//end of base (or super) constructor 
        {
            /*
             * Logic for animations will **probably** go here. Most everything else will **probably** be handeled by the BaiscProjectile part
             *      -Tho that being said, maybe I should have the sprites tied to to this class?
             *      -I supposed it'd be more modular if I had an assets file, and people could play with it.
            */
        }
    }
}
