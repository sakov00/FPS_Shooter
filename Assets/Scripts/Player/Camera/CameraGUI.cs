using UnityEngine;

public class CameraGUI : MonoBehaviour
{
    private new Camera camera;
    private GeneralPlayer player;

    private void Start()
    {
        camera = GetComponent<Camera>();
        player = transform.parent.GetComponent<GeneralPlayer>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void OnGUI()
    {
        int size = 15;
        float posX = camera.pixelWidth / 2;
        float posY = camera.pixelHeight / 2;
        GUI.Label(new Rect(posX, posY, size, size), "*");
        GUI.Label(new Rect(camera.pixelWidth - 50, camera.pixelHeight - 50, 50, 50), $"HP {player.HP}");
    }
}
