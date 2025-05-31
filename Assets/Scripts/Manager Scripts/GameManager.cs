using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public event Action<Database> DatabaseInitialized;

    [Header("Testing")]
    [SerializeField] private bool menuInitialization = false;
    [SerializeField] private CharacterDataSO testCharacterData;

    [Header("Database")]
    [SerializeField] private Database database;

    private AsyncOperation loadOperation;
    private AsyncOperation unloadOperation;

    private void Start()
    {
        if (menuInitialization)
        {
            StartCoroutine(InitializeMenuScene());
        }
        else if (testCharacterData != null)
        {
            StartCoroutine(StartGame(testCharacterData));
        }
        else
        {
            Debug.LogError("No character data provided for testing. Please assign a CharacterDataSO in the inspector.");
        }
    }

    public IEnumerator InitializeMenuScene()
    {
        //Load Transition
        UIManager.instance.ShowTransitionPanel();

        loadOperation = SceneManager.LoadSceneAsync("MainMenu", LoadSceneMode.Additive);

        while (!loadOperation.isDone)
        {
            yield return null;
        }
        yield return new WaitForEndOfFrame();

        //Unload Transition
        UIManager.instance.HideTransitionPanel();
        loadOperation = null;

        DatabaseInitialized?.Invoke(database);
    }

    public IEnumerator StartGame(CharacterDataSO characterData)
    {
        if (characterData == null)
        {
            Debug.LogError("Character data is null. Cannot select character.");
        }
        else
        {
            for (int i = 0; i < SceneManager.sceneCount; i++)
            {
                if (SceneManager.GetSceneAt(i).name.Equals("MainMenu"))
                {
                    //Load Transition
                    UIManager.instance.ShowTransitionPanel();

                    unloadOperation = SceneManager.UnloadSceneAsync("MainMenu");
                    while (!unloadOperation.isDone)
                    {
                        yield return null;
                    }
                    yield return new WaitForEndOfFrame();

                    //Unload Transition
                    UIManager.instance.HideTransitionPanel();
                    unloadOperation = null;

                    break;
                }
            }

            CharacterManager.instance.CharacterInitialized(characterData);
            StatManager.instance.ApplyCharacterData(characterData);
        }

    }
}
