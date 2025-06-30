using Server.Targeting;
using System.Collections.Generic;

namespace Server.Mobiles
{
    public static class PlayerMobileFootsteps
    {
        private static readonly List<int> DefaultSounds = new List<int> { 0x12B, 0x12C };
        private static readonly List<int> BushesSounds = new List<int> { 0x33B, 0x33C };
        private static readonly List<int> DirtSounds = new List<int> { 0x33B, 0x33C };
        private static readonly List<int> GrassSounds = new List<int> { 0x339, 0x33A };
        private static readonly List<int> SandSounds = new List<int> { 0x33F, 0x340 };
        private static readonly List<int> SnowSounds = new List<int> { 0x341, 0x342 };
        private static readonly List<int> LightWoodSounds = new List<int> { 0x121, 0x122 };
        private static readonly List<int> DarkWoodSounds = new List<int> { 0x343, 0x344 };
        private static readonly List<int> HardStoneSounds = new List<int> { 0x33D, 0x33E };
        private static readonly List<int> ShallowWaterSounds = new List<int> { 0x131, 0x132 };
        private static readonly List<int> DeepWaterSounds = new List<int> { 0x133, 0x134 };

        /// <summary>
        /// Plays a footstep sound of the tile the player is currently standing on (stone, grass, wood, etc.).
        /// </summary>
        /// <param name="playerMobile"></param>
        public static void PlaySound(PlayerMobile playerMobile)
        {
            Point3D point = new Point3D(playerMobile.X, playerMobile.Y, playerMobile.Z);

            if (playerMobile.Z == 0)
            {
                // Play the sound of what the player is standing on
                PlayFootstepSound(playerMobile, point);
                return;
            }

            // Find the static tile to play sounds of since things can be stacked on top of each other
            object surface = playerMobile.Map.GetTopMobileSurface(point);
            if (surface is StaticTile)
            {
                StaticTile tile = (StaticTile)surface;
                StaticTarget target = new StaticTarget(point, tile.ID);
                
                int soundId = GetSoundId(target.Name, playerMobile);
                playerMobile.PlaySound(soundId);
            }
            else
            {
                PlayFootstepSound(playerMobile, point);
            }

            return;
        }

        /// <summary>
        /// Retrieves and plays the appropriate sound based on the position of the
        /// player and the tiles at the player's location.
        /// </summary>
        /// <param name="playerMobile">The player mobile</param>
        /// <param name="point">The position of the player</param>
        private static void PlayFootstepSound(PlayerMobile playerMobile, Point3D point)
        {
            StaticTile[] staticTiles = playerMobile.Map.Tiles.GetStaticTiles(playerMobile.X, playerMobile.Y);
            if (staticTiles.Length > 0)
            {
                for (int i = 0; i < staticTiles.Length; ++i)
                {
                    StaticTile tile = staticTiles[i];
                    StaticTarget target = new StaticTarget(point, tile.ID);

                    if (tile.Z == playerMobile.Z)
                    {
                        int soundId = GetSoundId(target.Name, playerMobile);

                        // Play the footstep sound if it is not the default
                        if(!DefaultSounds.Contains(soundId))
                        {
                            playerMobile.PlaySound(soundId);
                            return;
                        }
                    }
                }
            }

            // Check if this is a player drop or some other type of item
            IPooledEnumerable items = playerMobile.Map.GetItemsInRange(point, 0);
            foreach (Item item in items)
            {
                if (item == null || item.Z != playerMobile.Z)
                {
                    continue;
                }

                int soundId = GetSoundId(item.Name, playerMobile);
                playerMobile.PlaySound(soundId);
                items.Free();

                return;
            }
            items.Free();

            //Check if it is a land/terrain
            LandTile landTile = playerMobile.Map.Tiles.GetLandTile(playerMobile.X, playerMobile.Y);
            LandTarget landTarget = new LandTarget(point, playerMobile.Map);

            if (landTile.Z == playerMobile.Z)
            {
                int soundId = GetSoundId(landTarget.Name, playerMobile);
                playerMobile.PlaySound(soundId);
                return;
            }
        }

        /// <summary>
        /// Retrieves a sound identifier based on the player location and the tile name.
        /// </summary>
        /// <param name="tileName">The Name property of the tile the player is standing on</param>
        /// <param name="mobile">The player mobile</param>
        /// <returns></returns>
        private static int GetSoundId(string tileName, PlayerMobile mobile)
        {
            if (IsBushes(tileName))
            {
                return Utility.RandomList(BushesSounds.ToArray());
            }

            if (IsDirt(tileName))
            {
                return Utility.RandomList(DirtSounds.ToArray());
            }

            if (IsGrass(tileName))
            {
                return Utility.RandomList(GrassSounds.ToArray());
            }
            
            if (IsSand(tileName))
            {
                return Utility.RandomList(SandSounds.ToArray());
            }
            
            if (IsSnow(tileName))
            {
                return(Utility.RandomList(SnowSounds.ToArray()));
            }
            
            if (IsLightWood(tileName))
            {
                return Utility.RandomList(LightWoodSounds.ToArray());
            }
            
            if (IsDarkWood(tileName))
            {
                return Utility.RandomList(DarkWoodSounds.ToArray());
            }
            
            if (IsHardStone(tileName))
            {
                return Utility.RandomList(HardStoneSounds.ToArray());
            }
            
            if (IsShallowWater(tileName))
            {
                return Utility.RandomList(ShallowWaterSounds.ToArray());
            }

            if (IsDeepWater(tileName))
            {
                return Utility.RandomList(DeepWaterSounds.ToArray());
            }
            
            return Utility.RandomList(DefaultSounds.ToArray());
        }

        /// <summary>
        /// Determine if tile name contains text that indicates it is grass.
        /// </summary>
        /// <param name="tileName"></param>
        /// <returns></returns>
        private static bool IsGrass(string tileName)
        {
            List<string> grassNames = new List<string>
            {
                "carpet", 
                "grass", 
                "grasses", 
                "ground", 
                "hay", 
                "lion", 
                "mat", 
                "pillow", 
                "pampas grass", 
                "rope ladder", 
                "rug", 
                "sheets", 
                "tightrope"
            };

            foreach (string grassName in grassNames)
            {
                if (tileName.Contains(grassName))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Determine if tile name contains text that indicates it is bush.
        /// </summary>
        /// <param name="tileName"></param>
        /// <returns></returns>
        private static bool IsBushes(string tileName)
        {
            List<string> bushNames = new List<string>
            {
                "cactus",
                "corn stalk",
                "cotton",
                "fern",
                "flowers",
                "grasses",
                "glories",
                "leaves",
                "onions",
                "palm",
                "plant",
                "poppies",
                "reeds",
                "rushes",
                "sapling",
                "snowdrops",
                "turnip",
                "vine",
                "weed",
                "wheat"
            };

            foreach (string bushName in bushNames)
            {
                if (tileName.Contains(bushName))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Determine if tile name contains text that indicates it is dirt.
        /// </summary>
        /// <param name="tileName"></param>
        /// <returns></returns>
        private static bool IsDirt(string tileName)
        {
            List<string> dirtNames = new List<string>
            {
                "apple",
                "bark",
                "batwing",
                "beetle shell",
                "bitter root",
                "Black Pearl",
                "Blood Moss",
                "bone",
                "books",
                "brain",
                "brimstone",
                "butterfly wings",
                "canteloupe",
                "campfire",
                "carrot",
                "carrots",
                "carpet",
                "cave",
                "crumbling",
                "crystal",
                "debris",
                "dirt",
                "dried toad",
                "dung",
                "ear of corn",
                "eggshells",
                "embank",
                "floor cracks",
                "forest",
                "fungus",
                "furrows",
                "glass",
                "grapes",
                "grave",
                "ground",
                "jungle",
                "lava",
                "mushroom",
                "nails",
                "onion",
                "onions",
                "pumpkin",
                "rock",
                "skull",
                "swamp berries",
                "thorn",
                "trap",
                "tree"
            };

            foreach (string dirtName in dirtNames)
            {
                if (tileName.Contains(dirtName))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Determine if tile name contains text that indicates it is dark wood.
        /// Dark woods are hard woods - they do not move and are solid.
        /// </summary>
        /// <param name="tileName"></param>
        /// <returns></returns>
        private static bool IsDarkWood(string tileName)
        {
            List<string> darkWoodNames = new List<string>
            {
                "chair",
                "deck",
                "fallen log",
                "Galleon",
                "hold",
                "log",
                "piano",
                "planks",
                "ship",
                "stool",
                "track",
                "wooden bench",
                "wooden boards",
                "wooden floor",
                "wooden plank",
                "wooden planks",
                "wooden floor tile"
            };

            foreach (string darkWoodName in darkWoodNames)
            {
                if (tileName.Contains(darkWoodName))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Determine if tile name contains text that indicates it is light wood.
        /// Light woods are loosely held together and not hard. They have a distinct creaky sound.
        /// </summary>
        /// <param name="tileName"></param>
        /// <returns></returns>
        private static bool IsLightWood(string tileName)
        {
            List<string> lightWoodNames = new List<string>
            {
                "bridge",
                "ladder",
                "gang plank",
                "hatch",
                "gothic stairs",
                "pillory",
                "platform",
                "table",
                "trap door",
                "wood",
                "wooden",
                "wooden bridge",
                "wooden ramp",
                "wooden stairs",
                "wooden structure"
            };

            foreach (string lightWoodName in lightWoodNames)
            {
                if (tileName.Contains(lightWoodName))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Determine if tile name contains text that indicates it is hard stone.
        /// </summary>
        /// <param name="tileName"></param>
        /// <returns></returns>
        private static bool IsHardStone(string tileName)
        {
            List<string> hardStoneNames = new List<string>
            {
                "stone",
                "tile",
                "wooden floor tile",
                "marble",
                "alchemical symbol",
                "altar",
                "arcane circle",
                "arcane table",
                "block",
                "brick",
                "column",
                "dungeon ramp",
                "floor",
                "cave floor",
                "pentagram",
                "slate roof",
                "status base",
                "teleporter"
            };

            foreach (string hardStoneName in hardStoneNames)
            {
                if (tileName.Contains(hardStoneName))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Determine if tile name contains text that indicates it is sand.
        /// </summary>
        /// <param name="tileName"></param>
        /// <returns></returns>
        private static bool IsSand(string tileName)
        {
            List<string> sandNames = new List<string>
            {
                "sand",
                "sandstone"
            };

            foreach (string sandName in sandNames)
            {
                if (tileName.Contains(sandName))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Determine if tile name contains text that indicates it is snow.
        /// </summary>
        /// <param name="tileName"></param>
        /// <returns></returns>
        private static bool IsSnow(string tileName)
        {
            List<string> snowNames = new List<string>
            {
                "snow"
            };

            foreach (string snowName in snowNames)
            {
                if (tileName.Contains(snowName))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Determine if tile name contains text that indicates it is shallow water.
        /// </summary>
        /// <param name="tileName"></param>
        /// <returns></returns>
        private static bool IsShallowWater(string tileName)
        {
            List<string> shallowWaterNames = new List<string>
            {
                "liquid",
                "blood", 
                "Blood Moss"
            };

            foreach (string shallowWaterName in shallowWaterNames)
            {
                if (tileName.Contains(shallowWaterName))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Determine if tile name contains text that indicates it is deep water.
        /// </summary>
        /// <param name="tileName"></param>
        /// <returns></returns>
        private static bool IsDeepWater(string tileName)
        {
            List<string> deepWaterNames = new List<string>
            {
                "acid",
                "water",
                "swamp",
                "deep swamp"
            };

            foreach (string deepWaterName in deepWaterNames)
            {
                if (tileName.Contains(deepWaterName))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
