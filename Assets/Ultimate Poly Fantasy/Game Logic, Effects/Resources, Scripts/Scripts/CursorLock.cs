using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AquariusMax.Demo
{
    public class CursorLock : MonoBehaviour
    {

        bool isLocked = false;

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyUp(KeyCode.Escape))
            {
                isLocked = false;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                isLocked = true;
            }

            if (isLocked)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            else if (!isLocked)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
    }
}