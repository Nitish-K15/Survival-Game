using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace AquariusMax.Demo {
    public class LadderClimb : MonoBehaviour {





        
        [SerializeField]
        private bool _onLadder = false;
        [SerializeField]
        private float heightFactor = 3.2f;

        



        


        private void OnTriggerEnter(Collider _ladder)
        {
            if (_ladder.gameObject.tag == "Ladder")
            {
                DemoCharacter DC = GetComponent("DemoCharacter") as DemoCharacter;
                DC.enabled = false;
                _onLadder = !_onLadder;
            }

        
        }

        private void OnTriggerExit(Collider _ladder)
        {
            if (_ladder.gameObject.tag == "Ladder")
            {
                DemoCharacter DC = GetComponent("DemoCharacter") as DemoCharacter;
                DC.enabled = true;
                _onLadder = !_onLadder;
            }

            


        }

        private void Update()
        {
            if (_onLadder == true && Input.GetKey("w"))
            {
                DemoCharacter DC = GetComponent("DemoCharacter") as DemoCharacter;
                DC.transform.position += Vector3.up / heightFactor;
            }
        }
    }
}
