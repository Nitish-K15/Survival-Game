using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace AquariusMax.Demo
{

    [Serializable]
    public class InteractEvent : UnityEvent<GameObject> { }

    [RequireComponent(typeof(Renderer))]
    public class Interactable : MonoBehaviour
    {

        public Color highlightColor = Color.green;
        public Material highlightMaterial;

        Material materialInstance;

        bool isFocused = false;

        [SerializeField]
        InteractEvent interactEvent;

        public void OnFocus()
        {
            isFocused = true;
            AddFocusMaterial();
        }

        public void OnBlur()
        {
            isFocused = false;
            RemoveFocusMaterial();
        }

        public void OnInteract()
        {
            interactEvent.Invoke(gameObject);
        }

        void AddFocusMaterial()
        {
            if (highlightMaterial == null) { return; }

            Renderer renderer = GetComponent<Renderer>();
            // check if we already added it
            if (materialInstance != null)
            {
                for (var i = 0; i < renderer.materials.Length; i++)
                {
                    if (renderer.materials[i] == materialInstance)
                    {
                        return;
                    }
                }
            }

            Material[] newMats = new Material[renderer.materials.Length + 1];
            Array.Copy(renderer.materials, newMats, renderer.materials.Length);
            newMats[renderer.materials.Length] = highlightMaterial;

            renderer.materials = newMats;

            materialInstance = renderer.materials[renderer.materials.Length - 1];

            if (materialInstance.HasProperty("_OutlineColor"))
            {
                materialInstance.SetColor("_OutlineColor", highlightColor);
            }
        }

        void RemoveFocusMaterial()
        {
            if (materialInstance == null) { return; }

            Renderer renderer = GetComponent<Renderer>();
            bool found = false;
            for (var i = 0; i < renderer.materials.Length; i++)
            {
                if (renderer.materials[i] == materialInstance)
                {
                    found = true;
                    break;
                }
            }

            if (!found) { return; }

            Material[] mats = new Material[renderer.materials.Length - 1];
            int newIndex = 0;
            for (var i = 0; i < renderer.materials.Length; i++)
            {
                if (renderer.materials[i] != materialInstance)
                {
                    mats[newIndex] = renderer.materials[i];
                    newIndex++;
                }
            }

            renderer.materials = mats;
            materialInstance = null;
        }
    }
}