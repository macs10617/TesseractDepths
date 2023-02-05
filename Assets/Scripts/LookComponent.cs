using UnityEngine;

public class LookComponent : MonoBehaviour
{
    [SerializeField] private float _mouseSensivity;
    [SerializeField] private Transform _player;

    private float _horizontalRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        _player.Rotate(Vector3.up * 90);
    }

    private void Update()
    {
        if (!InputManager.Instance.IsInputEnabled(MyInputType.Look)) return;

        Look();
    }

    void Look()
    {
        float mouseHorizontal = Input.GetAxis("Mouse X") * _mouseSensivity * Time.fixedDeltaTime;
        float mouseVertical = Input.GetAxis("Mouse Y") * _mouseSensivity * Time.fixedDeltaTime;
        _horizontalRotation -= mouseVertical;
        _horizontalRotation = Mathf.Clamp(_horizontalRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(_horizontalRotation, 0f, 0f);
        _player.Rotate(Vector3.up * mouseHorizontal);
    }
}