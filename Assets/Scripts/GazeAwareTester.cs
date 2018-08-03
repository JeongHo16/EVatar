﻿using System.Collections;
using System.Collections.Generic;
using Tobii.Gaming;
using UnityEngine;
//using UnityEngine.UI;

namespace EyeHelpers
{
    public class GazeAwareTester : MonoBehaviour
    {
        public Color normalColor = Color.white;
        public Color focusedColor = Color.red;

        public GazeAware gazeAware;
        public Renderer targetRenderer;
        //public InputField inputField;

        private bool hasFocus = false;
        private Timer typingTimer = new Timer();
        private float typingTime = 2f;        

        void Awake()
        {
            if (gazeAware == null)
                gazeAware = GetComponent<GazeAware>();

            if (targetRenderer == null)
                targetRenderer = GetComponent<Renderer>();
        }

        void Update()
        {
            //UpdateState();
            EyeTyping();
        }

        //void UpdateState()
        //{
        //    if (gazeAware.HasGazeFocus != hasFocus)
        //    {
        //        hasFocus = gazeAware.HasGazeFocus;
        //        ChangeColor(hasFocus);
        //    }
        //}

        void EyeTyping()
        {
            if (gazeAware.HasGazeFocus)
            {
                typingTimer.Update(Time.deltaTime);
                if (typingTimer.HasPastSince(typingTime))
                {
                    ChangeColor(gazeAware.HasGazeFocus);
                    //inputField.text += targetRenderer.name;
                    //Debug.Log(targetRenderer.name + "Typing!!!");
                }
            }
            else
                ChangeColor(gazeAware.HasGazeFocus);
        }

        void ChangeColor(bool state)
        {
            if (state) targetRenderer.material.color = focusedColor;
            else targetRenderer.material.color = normalColor;
        }

        //void IsGazing()
        //{
            
        //}
    }
}