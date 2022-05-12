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
        public static int X;
        public static int Y;
        public static int Z;
        public static string ActorName;

        public static void GetEachActor()
        {
            List<Data> ActorList = new List<Data>();
            foreach (Actor actor in ActorManager.Singleton.GetAllActors())
            {
                X = actor.Position.x;
                Y = actor.Position.y;
                Z = actor.Position.z;
                ActorName = actor.name;

                Data data = new Data();
                ActorList.Add(data);
            }
            WriteToFile(ActorList);
        }

        [System.Serializable]
        public class Data
        {
            public int x = X;
            public int y = Y;
            public int z = Z;
            public string name = ActorName;
        }

        public static void WriteToFile(List<Data> ActorList)
        {
            string result = "";
            foreach (Data actor in ActorList)
            {
                string strOutput = JsonUtility.ToJson(actor);
                result += $"{strOutput}\n";
            }

            File.WriteAllText(Application.dataPath + "/savegame.txt", result);
        }
    }
}
