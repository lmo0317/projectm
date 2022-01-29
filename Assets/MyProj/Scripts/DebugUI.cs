using Invector.vCharacterController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugUI : MonoBehaviour
{
    // Start is called before the first frame update
    public vThirdPersonInput tpInput;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(10, 150, 300, 80), "Camera Change To CollectionState"))
        {
            Debug.Log("Clicked the button with text");
            tpInput.ChangeCameraState("Collection", true);
        }

        if (GUI.Button(new Rect(10, 300, 300, 80), "Camera Change To Default"))
        {
            Debug.Log("Clicked the button with text");
            tpInput.ChangeCameraState("Default", true);
        }
    }
}
