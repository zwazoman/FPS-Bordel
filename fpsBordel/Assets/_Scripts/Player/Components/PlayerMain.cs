using Unity.Cinemachine;
using UnityEngine;

public class PlayerMain : MonoBehaviour
{
    #region Singleton
    private static PlayerMain instance;

    public static PlayerMain Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject go = new GameObject("Player Main");
                instance = go.AddComponent<PlayerMain>();
            }
            return instance;
        }
    }
    #endregion

    [Header("Scripts References")]

    [field : SerializeField]
    public PlayerMovement movement { get; private set; }

    [field : SerializeField]
    public PlayerInteraction interaction { get; private set; }

    [field : SerializeField]
    public PlayerInputs inputs { get; private set; }

    [field : SerializeField]
    public PlayerStats stats { get; private set; }

    [Header("Objects References")]

    [field: SerializeField]
    public CinemachineCamera fpsCam { get; private set; }

    [field : SerializeField]
    public CharacterController charController { get; private set; }

    [SerializeField] EntityData _playerData;

    private void Awake()
    {
        instance = this;

        if (movement == null)
            movement = GetComponent<PlayerMovement>();
        if(interaction == null)
            interaction = GetComponent<PlayerInteraction>();
        if(inputs == null)
            inputs = GetComponent<PlayerInputs>();
        if(stats == null)
            stats = GetComponent<PlayerStats>();


        if(fpsCam == null)
            fpsCam.GetComponentInChildren<CinemachineCamera>();
        if(charController == null)
            charController = GetComponent<CharacterController>();
    }


}
