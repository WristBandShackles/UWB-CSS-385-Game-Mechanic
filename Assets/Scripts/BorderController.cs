using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BorderController : MonoBehaviour
{
    private CameraSupport cameraSupport;

    private GameObject floor;
    private GameObject wall1;
    private GameObject wall2;

    private Bounds worldBounds;

    // Start is called before the first frame update
    void Start()
    {
        cameraSupport = Camera.main.GetComponent<CameraSupport>();
        floor = GameObject.Find("Floor");
        wall1 = GameObject.Find("Wall (1)");
        wall2 = GameObject.Find("Wall (2)");
    }

    // Update is called once per frame
    void Update()
    {
        cameraSupport.CalculateWorldBound();
        worldBounds = cameraSupport.GetWorldBounds();

        Vector3 xScalingVec = new Vector3(worldBounds.max.x * 2, 1, 1);
        Vector3 yScalingVec = new Vector3(1, worldBounds.max.y * 2, 1);
        floor.transform.localScale = xScalingVec;
        wall1.transform.localScale = yScalingVec;
        wall2.transform.localScale = yScalingVec;

        Vector3 floorPos = new Vector3( 0, worldBounds.min.y, 0);
        Vector3 wall1Pos = new Vector3(worldBounds.max.x, 0, 0);
        Vector3 wall2Pos = new Vector3(worldBounds.min.x, 0, 0);

        floor.transform.position = floorPos;
        wall1.transform.position = wall1Pos;
        wall2.transform.position = wall2Pos;
    }
}
