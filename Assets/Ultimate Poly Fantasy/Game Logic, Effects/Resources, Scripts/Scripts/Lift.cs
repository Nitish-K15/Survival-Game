using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AquariusMax.Demo
{
public class Lift : MonoBehaviour {

    public Transform start;
    public Transform target;
   

    public float speed;
    public bool _isActiv;
    public bool _isPlayer =true;
    



    private void Awake()
    {
       
    }

    void Update()
    {
        
            if (_isActiv && start.position != target.position)
            {

            float step = speed * Time.deltaTime;

            start.transform.position = Vector3.MoveTowards(transform.position, target.position, step);

            }
            if (start.position == target.position)
            {
                _isActiv = false;
            }

      
            
        

    }


    public void OnTriggerEnter(Collider other)
    {
        
            _isActiv = true;
            Debug.Log(_isActiv);
        
    }


    public void OnTriggerExit(Collider other)
    {
       

    }

    
}
}
