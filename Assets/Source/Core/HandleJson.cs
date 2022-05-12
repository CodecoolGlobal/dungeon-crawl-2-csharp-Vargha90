using System;
using System.Collections.Generic;
using System.IO;
using DungeonCrawl.Actors;
using DungeonCrawl.Core;
using UnityEngine;

namespace Assets.Source.Core
{
    public class HandleJson : MonoBehaviour
    {
        public static int MapId;
        public static int X;
        public static int Y;
        public static int Z;
        public static char ActorSymbol;

        public static void GetEachActor()
        {
            ArrayOfData ActorList = new ArrayOfData();
            foreach (Actor actor in ActorManager.Singleton.GetAllActors())
            {
                X = actor.Position.x;
                Y = actor.Position.y;
                Z = actor.Position.z;
                ActorSymbol = actor.Symbol;

                Data data = new Data();
                ActorList.ActorList.Add(data);
            }
            WriteToFile(ActorList);
        }

        [System.Serializable]
        public class Data
        {
            public int MapId = MapLoader.MapId;
            public int x = X;
            public int y = Y;
            public int z = Z;
            public char symbol = ActorSymbol;
        }

        [System.Serializable]
        public class ArrayOfData
        {
            public List<Data> ActorList;

            public ArrayOfData()
            {
                ActorList = new List<Data>();
            }
        }

        private static void WriteToFile(ArrayOfData ActorList)
        {
            string strOutput = JsonUtility.ToJson(ActorList, true);
            File.WriteAllText(Application.dataPath + "/savegame.json", strOutput);
        }

        public static void ReadFromJson()
        {
            string fileText = File.ReadAllText(Application.dataPath + "/savegame.json");
            ArrayOfData ActorsFromJson = JsonUtility.FromJson<ArrayOfData>(fileText);
            MapLoader.ReloadState(ActorsFromJson.ActorList);
        }
    }
}
