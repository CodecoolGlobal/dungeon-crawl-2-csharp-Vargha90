using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

namespace DungeonCrawl.Core
{
    public class Menu : MonoBehaviour
    {
        public GameObject mainMenu;

        public GameObject newGameButton, nothingButton, quitButton;

        // Start is called before the first frame update
        void Start()
        {
            // clear selected object
            EventSystem.current.SetSelectedGameObject(null);
            // set a new selected object
            EventSystem.current.SetSelectedGameObject(newGameButton);
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void StartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        public void Quit()
        {
            Application.Quit();
        }
    }
}