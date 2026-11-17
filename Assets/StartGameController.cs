using UnityEngine;
using UnityEngine.UIElements;
using Unity.Netcode;
using UnityEngine.SceneManagement;

public class StartGameController : MonoBehaviour
{
    public UIDocument ui;
    private Button startButton;
    public string sceneName;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startButton = ui.rootVisualElement.Q<Button>("StartGameButton");
        startButton.clicked += StartGame;
    }

    // Update is called once per frame
    void Update()
    {
        if (NetworkManager.Singleton.IsHost)
        {
            startButton.style.display = DisplayStyle.Flex;
        }
        else
        {
            startButton.style.display = DisplayStyle.None;
        }
        
    }
    void StartGame()
    {
        if (!NetworkManager.Singleton.IsHost)
        {
            return;
        }
        NetworkManager.Singleton.SceneManager.LoadScene(sceneName, LoadSceneMode.Single);


    }
}
