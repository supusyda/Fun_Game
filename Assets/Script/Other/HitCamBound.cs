
using UnityEngine;

public class HitCamBound
{
    // Start is called before the first frame update
    private float minX, maxX, minY, maxY;
    private float _width, _height;
    Vector3 bottomLeft, topRight;
    Vector3 previousCameraPosition;
    private Camera camera;
    private Transform _transform;
    private Rigidbody2D rb;

    public HitCamBound(Transform transform)
    {
        _transform = transform;
        rb = _transform.GetComponent<Rigidbody2D>();
        camera = Camera.main;
        _width = Screen.width;
        _height = Screen.height;
        previousCameraPosition = camera.transform.position;
        UpdateCurrentPos();

    }
    public void UpdateCurrentPos()
    {        // Update previous camera position

        bottomLeft = camera.ScreenToWorldPoint(new Vector3(0, 0, camera.nearClipPlane));
        topRight = camera.ScreenToWorldPoint(new Vector3(_width, _height, camera.nearClipPlane));

        minX = bottomLeft.x + .1f;
        maxX = topRight.x - .1f;
        minY = bottomLeft.y + .1f;
        maxY = topRight.y - .1f;
        Debug.Log("minX" + minX);
        Debug.Log("maxX" + maxX);
        Debug.Log("minY" + minY);
        Debug.Log("maxY" + maxY);
        UpdatePreviousCameraPosition();



    }
    public void AdjustForCameraMovement()
    {
        // Get the current camera position
        Vector3 currentCameraPosition = camera.transform.position;

        // Calculate the difference in camera movement
        Vector3 cameraDelta = currentCameraPosition - previousCameraPosition;

        // Apply the same movement to the bullet to keep it relative to the camera
        rb.MovePosition(rb.position + (Vector2)cameraDelta);

        // Update the last camera position to the current one
        UpdatePreviousCameraPosition();
    }
    public void UpdatePreviousCameraPosition()
    {
        previousCameraPosition = camera.transform.position;
    }
    public Vector3 GetCameraMovement()
    {
        return camera.transform.position - previousCameraPosition;

    }
    public bool IsHitBoundX()
    {
        return rb.position.x <= minX || rb.position.x >= maxX;
    }
    public bool IsHitBoundY()
    {
        return rb.position.y <= minY || rb.position.y >= maxY;
    }

}
