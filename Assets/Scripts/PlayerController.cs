using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    Vector2 prevTouchPos, touchPos, screenPos;

    void Awake()
    {
      
        PlayerInputActions playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
        
        playerInputActions.Player.TouchPosition.performed += GetTouchPos;
        playerInputActions.Player.TouchStart.canceled += ResetPrevTouch;
        
        

    }

    private void GetTouchPos(InputAction.CallbackContext context)
    {
        screenPos = Camera.main.WorldToScreenPoint(LevelManager.INSTANCE.currentLevel.transform.position);
        Vector2 firstLine, secondLine;
        touchPos = context.ReadValue<Vector2>();
        if (prevTouchPos==Vector2.zero)
        {
            Debug.Log("Prev zero");
            prevTouchPos = touchPos;
        }
        else
        {
           firstLine= screenPos - prevTouchPos;
            secondLine = screenPos - touchPos;
            float angle = Vector2.SignedAngle(firstLine, secondLine);
            Debug.Log("Rotate");
            LevelManager.INSTANCE.currentLevel.transform.Rotate(Vector3.back, angle);

            prevTouchPos = touchPos;
        }
 
    }
    private void ResetPrevTouch(InputAction.CallbackContext context)
    {
        Debug.Log("sdasd");
        prevTouchPos = Vector2.zero;
    }
   
   

    
}
