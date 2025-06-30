using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton
    private static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject go = new GameObject("Game Manager");
                instance = go.AddComponent<GameManager>();
            }
            return instance;
        }
    }
    #endregion

    private void Awake()
    {
        DontDestroyOnLoad(this);

        Cursor.lockState = CursorLockMode.Locked;
    }
}
