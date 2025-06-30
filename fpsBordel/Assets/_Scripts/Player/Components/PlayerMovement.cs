using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region PlayerMain Link
    [SerializeField] PlayerMain _main;
    #endregion

    [Header("Mouse Settings")]

    [SerializeField] float sensX = 1;
    [SerializeField] float sensY = 1;

    float xRot = 0;

    private void Awake()
    {
        if (_main == null)
            TryGetComponent(out _main);
    }

    public void Move(Vector2 moveVector)
    {
        Vector3 move = transform.right * moveVector.x + transform.forward * moveVector.y;

        _main.charController.Move(move * _main.stats.speed * Time.deltaTime);
    }

    public void Look(Vector2 mouseDelta)
    {
        float mouseX = mouseDelta.x * sensX * Time.deltaTime;
        float mouseY = mouseDelta.y * sensY * Time.deltaTime;


        xRot -= mouseY;
        xRot = Mathf.Clamp(xRot, -90, 90);

        _main.fpsCam.transform.localRotation = Quaternion.Euler(xRot, 0, 0);
        transform.Rotate(Vector3.up * mouseX);
    }

    public void Jump()
    {
        print("Saute");
    }
}
