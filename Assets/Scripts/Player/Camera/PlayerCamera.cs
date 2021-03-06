using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public float sensitivityHor = 6.0f;
    public float sensitivityVert = 6.0f;

    private float minimumVert = -80.0f;
    private float maximumVert = 80.0f;
    
    private float _rotationX = 0;
    private float _rotationY = 0;

    private void Update()
    {
        _rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
        _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);
        _rotationY += Input.GetAxis("Mouse X") * sensitivityHor;
        transform.localEulerAngles = new Vector3(_rotationX, _rotationY, 0);
    }
}
