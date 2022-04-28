using UnityEngine;

namespace DungeonCrawl.Core
{
    /// <summary>
    ///     Loads the initial map and can be used for keeping some important game variables
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        private void Start()
        {// map change condition here
            MapLoader.LoadMap(1);
            MapLoader.LoadMap(2);
        }
    }
}
