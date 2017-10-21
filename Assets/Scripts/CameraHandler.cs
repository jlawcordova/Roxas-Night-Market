using UnityEngine;

/// <summary>
/// Handles the dragging of the camera.
/// </summary>
public class CameraHandler : MonoBehaviour
{
    [HideInInspector]
    public static Vector3 CameraPosition = new Vector3(0, 0, -10);

    public float DragSpeed;
    private Vector3 DragOrigin;

    public Vector3 LeftEnd;
    public Vector3 RightEnd;

    void Awake()
    {
        transform.position = CameraPosition;
    }

	// Use this for initialization
	void Start ()
    {
        LeftEnd = new Vector3(0.0f, 0, -10);
        RightEnd = new Vector3(12f * Progress.ProgressManager.PlaceSize, 0, -10);
    }

    // Update is called once per frame
    void Update()
    {
        // Get the initial position of the pointer when it is down.
        if (Input.GetMouseButtonDown(0))
        {
            DragOrigin = Input.mousePosition;
            return;
        }

        // Perform the movement to be made when dragging.
        if (Input.GetMouseButton(0))
        {
            Vector3 position = Camera.main.ScreenToViewportPoint(Input.mousePosition - DragOrigin);
            Vector3 move = new Vector3(position.x * DragSpeed, 0, 0);
            
            transform.Translate(move, Space.World);

            if (transform.position.x < LeftEnd.x)
            {
                transform.position = LeftEnd;
            }
            else if (transform.position.x > RightEnd.x)
            {
                transform.position = RightEnd;
            }

            CameraPosition = transform.position;
            DragOrigin = Input.mousePosition;
        }
	}
}
