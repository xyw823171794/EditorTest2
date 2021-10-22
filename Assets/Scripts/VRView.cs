using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Battlehub.RTEditor;

public class VRView : MonoBehaviour
{
    private Transform targetCamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (targetCamera == null)
        {
            var obj = Transform.FindObjectOfType(typeof(GameView));
            if (obj != null)
            {
                var camera = (obj as GameView).Camera;
                if (camera != null)
                {
                    targetCamera = camera.transform;
                }
            }
        }
        else
        {
            //transform.SetPositionAndRotation(targetCamera.position, targetCamera.rotation);
            transform.position = targetCamera.position;
        }
    }
}
