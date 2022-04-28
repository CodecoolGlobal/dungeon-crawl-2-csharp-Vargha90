using Assets.Source.Actors.Characters;
using Assets.Source.Actors.Static;
using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Actors.Static;
using System;
using System.Text.RegularExpressions;
using UnityEngine;
using Tree = Assets.Source.Actors.Static.Tree;

namespace DungeonCrawl.Core
{
    /// <summary>
    ///     MapLoader is used for constructing maps from txt files
    /// </summary>
    public static class MapLoader
    {
        private static (int x, int y, int z) _playerPosition;
        public static int MapId;
        /// <summary>
        ///     Constructs map from txt file and spawns actors at appropriate positions
        /// </summary>
        /// <param name="id"></param>
        public static void LoadMap(int id)
        {
            AudioManager.StopBGMusic();
            AudioManager.PlayActionSound("transfer");
            if (id == 1)
            {
                AudioManager.PlayBGM("level_1");
            }
            else if (id == 2)
            {
                AudioManager.PlayBGM("level_2");
                AudioManager.PlayAmbiante("birds");
                AudioManager.PlayAmbiante("river");
            }
            var lines = Regex.Split(Resources.Load<TextAsset>($"map_{id}").text, "\r\n|\r|\n");

            // Read map size from the first line
            var split = lines[0].Split(' ');
            var width = int.Parse(split[0]);
            var height = int.Parse(split[1]);

            // Create actors
            for (var y = 0; y < height; y++)
            {
                var line = lines[y + 1];
                for (var x = 0; x < width; x++)
                {
                    var character = line[x];
                    if (id == 1)
                    {
                        SpawnActor(character, (x, -y, 0));
                    }

                    else
                    {
                        SpawnActor2(character, (x, -y, 0));
                    }
                }
            }
            SetMapId(id);
            // Set default camera size and position
            CameraController.Singleton.Size = 6;
            CameraController.Singleton.Position = (_playerPosition.x, _playerPosition.y, _playerPosition.z);
        }

        private static void SetMapId(int id)
        {
            MapId = id;
        }

        private static void SpawnActor(char c, (int x, int y, int z) position)
        {
            switch (c)
            {
                case '#':
                    position.z = Wall.getZ;
                    ActorManager.Singleton.Spawn<Wall>(position);
                    break;
                case '.':
                    position.z = Floor.getZ;
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;
                case 'p':
                    position.z = Player.getZ;
                    ActorManager.Singleton.Spawn<Player>(position);
                    _playerPosition = position;
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;
                case 's':
                    position.z = Skeleton.getZ;
                    ActorManager.Singleton.Spawn<Skeleton>(position);
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;
                case 'b':
                    position.z = Spider.getZ;
                    ActorManager.Singleton.Spawn<Spider>(position);
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;
                case 'k':
                    position.z = Key.getZ;
                    ActorManager.Singleton.Spawn<Key>(position);
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;
                case 'd':
                    ActorManager.Singleton.Spawn<Door>(position);
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;
                case 'm':
                    position.z = Meat.getZ;
                    ActorManager.Singleton.Spawn<Meat>(position);
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;
                case 'g':
                    position.z = Stairs.getZ;
                    ActorManager.Singleton.Spawn<Stairs>(position);
                    break;
                case ' ':
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private static void SpawnActor2(char c, (int x, int y, int z) position)
        {
            switch (c)
            {
                case '.':
                    position.z = Grass.getZ;
                    ActorManager.Singleton.Spawn<Grass>(position);
                    break;
                case '#':
                    position.z = Wall.getZ;
                    ActorManager.Singleton.Spawn<Wall>(position);
                    break;
                case '+':
                    position.z = Tree.getZ;
                    ActorManager.Singleton.Spawn<Tree>(position);
                    //ActorManager.Singleton.Spawn<Grass>(position);
                    break;
                case '|':
                    position.z = Road.getZ;
                    ActorManager.Singleton.Spawn<Road>(position);
                    break;
                case '*':
                    position.z = Flower.getZ;
                    ActorManager.Singleton.Spawn<Flower>(position);
                    //ActorManager.Singleton.Spawn<Grass>(position);
                    break;
                case '=':
                    position.z = Bridge.getZ;
                    ActorManager.Singleton.Spawn<Bridge>(position);
                    break;
                case '~':
                    position.z = River.getZ;
                    ActorManager.Singleton.Spawn<River>(position);
                    break;
                case 'p':
                    position.z = Player.getZ;
                    ActorManager.Singleton.Spawn<Player>(position);
                    _playerPosition = position;
                    ActorManager.Singleton.Spawn<Grass>(position);
                    break;
                case 'b':
                    position.z = Boss.getZ;
                    ActorManager.Singleton.Spawn<Boss>(position);
                    ActorManager.Singleton.Spawn<Grass>(position);
                    break;
                case '&':
                    position.z = Gate.getZ;
                    ActorManager.Singleton.Spawn<Gate>(position);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
