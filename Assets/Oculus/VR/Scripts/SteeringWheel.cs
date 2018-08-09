using UnityEngine;
using UnityEngine.EventSystems;

public class SteeringWheel : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler {

    // Used for finding the image center point
    RectTransform rect;
    Vector2 centerPoint;

    // To find whether the wheel is held or not
    bool wheelBeingHeld = false;
    private float wheelPrevAngle = 0f;
    private float wheelAngle = 0f;

    float maxSteeringAngle = 200f;
    float wheelReleasedSpeed = 250f;

	void Start () {
        rect = getComponent<RectTransform>();
        getCenterPoint();
	}
	
	void Update () {

        if(!wheelBeingHeld && !Mathf.Approximately(0f, wheelAngle)) {
            float deltaAngle = wheelReleasedSpeed * Time.deltaTime;

            if(Math.Abs(deltaAngle) > Math.Abs(wheelAngle)) {
                wheelAngle = 0f;
            }
            else if (wheelAngle > 0f) {
                wheelAngle -= deltaAngle;
            }
            else {
                wheelAngle += deltaAngle;
            }
        }

        // Rotate wheel image
        rect.localEulerAngles = new Vector3(0, 0, -1) * wheelAngle;
	}

    // Calculate center of the image
    private void getCenterPoint() {
        // To get the position of the corners of the image in the world
        Vector3[] corners = new Vector3[4];
        rect.GetWorldCorners(corners);

        for (int i = 0; i < 4; i++) {
            corners[i] = RectTransformUtility.WorldToScreenPoint(null, corners[i]);
        }

        Vector3 bottomLeft = corners[0];
        Vector3 topRight = corners[2];
        float width = topRight.x - bottomLeft.x;
        float height = topRight.y - bottomLeft.y;

        Rect _rect = new Rect(bottomLeft.x, topRight.y, width, height);
        centerPoint = new Vector2(_rect.x + _rect.width * 0.5f, _rect.y - _rect.height * 0.5f);
    }
}
