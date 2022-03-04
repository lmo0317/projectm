using Invector.vCharacterController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugUI : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    private vThirdPersonController _thirdPersonController;

    void Start()
    {
        _thirdPersonController = player.GetComponent<vThirdPersonController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnGUI()
    {
        var style = new GUIStyle(GUI.skin.button);
        style.normal.textColor = Color.red;
        style.fontSize = 36;

        if (GUILayout.Button("Left", style))
        {
            Debug.Log("Hello!");
            _thirdPersonController.JumpLeft();
        }

        if (GUILayout.Button("Right", style))
        {
            Debug.Log("Hello!");
            _thirdPersonController.JumpRight();
        }
    }
}
