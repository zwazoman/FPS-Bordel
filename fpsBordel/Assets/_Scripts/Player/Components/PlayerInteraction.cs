using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    #region PlayerMain Link

    [SerializeField] PlayerMain _main;

    private void Awake()
    {
        if (_main == null)
            TryGetComponent(out _main);
    }
    #endregion

    private void Start()
    {
        _main.inputs.OnInteract += Interact;
    }

    void Interact()
    {

    }
}
