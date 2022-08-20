using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerEvents : MonoBehaviour
{
    #region Events
    public static UnityAction OnTouchpadUp = null;
    public static UnityAction OnTouchpadDown = null;
    public static UnityAction<OVRInput.Controller, GameObject> OnControllerSource = null;
    #endregion
    
    #region Anchors
    public GameObject m_LeftAnchor;
    public GameObject m_RightAnchor;
    public GameObject m_HeadAnchor;
    #endregion

    #region Input
    private Dictionary<OVRInput.Controller, GameObject> m_ControllerSets = null;
    private OVRInput.Controller m_InputSource = OVRInput.Controller.None;
    private OVRInput.Controller m_Controller = OVRInput.Controller.None;
    private bool m_InputActive = true;
    #endregion

    private void Awake()
    {
        OVRManager.HMDMounted += PlayerFound;
        OVRManager.HMDUnmounted += PlayerLost;

        m_ControllerSets = CreateControllerSets();
    }

    private void OnDestroy()
    {
        OVRManager.HMDMounted -= PlayerFound;
        OVRManager.HMDUnmounted -= PlayerLost;
    }

    private void Update()
    {
        // Check for active input
        if(!m_InputActive)
            return;
        // Check if a controller exists
        CheckForController();
        
        // Check for input source
        CheckInputSource();
        
        // Check for acutal input
        Input();
    }

    private void CheckForController()
    {
        OVRInput.Controller controllerCheck = m_Controller;
        
        // Right remote
        if (OVRInput.IsControllerConnected(OVRInput.Controller.RTrackedRemote))
            controllerCheck = OVRInput.Controller.RTrackedRemote;
        // Left remote
        if (OVRInput.IsControllerConnected(OVRInput.Controller.LTrackedRemote))
            controllerCheck = OVRInput.Controller.LTrackedRemote;
        
        // Update
        m_Controller = UpdateSource(controllerCheck, m_Controller);
    }

    private void CheckInputSource()
    {
        // Simplifying it more
        // Right remote
        // if (OVRInput.GetDown(OVRInput.Button.Any, OVRInput.Controller.RTrackedRemote))
        // {
        //     
        // }
        // Left remote
        // if (OVRInput.GetDown(OVRInput.Button.Any, OVRInput.Controller.LTrackedRemote))
        // {
        //     
        // }
        // Headset
        // Not needed it is for gearvr
        // As gearvr has Dpad and also return button
        // Leave it for now I don't want fuck my brain more, I mean reduce the complexity
        
        // Update
        m_InputSource = UpdateSource(OVRInput.GetActiveController(), m_InputSource);
    }

    private void Input()
    {
        // Touchpad Down
        if (OVRInput.GetDown(OVRInput.Button.PrimaryTouchpad))
        {
            if (OnTouchpadDown != null)
            {
                OnTouchpadDown();
            }
        }
        // TOuchpad Up
        if (OVRInput.GetUp(OVRInput.Button.PrimaryTouchpad))
        {
            if (OnTouchpadUp != null)
            {
                OnTouchpadUp();
            }
        }
    }

    private OVRInput.Controller UpdateSource(OVRInput.Controller check,OVRInput.Controller previous)
    {
        // If values are the same, return
        if (check==previous)
        {
            return previous;
        }
        // Get controller object
        GameObject controllerObject = null;
        m_ControllerSets.TryGetValue(check, out controllerObject);
        
        // Send out event
        if (OnControllerSource != null)
        {
            OnControllerSource(check, controllerObject);
        }
        
        // Return new value
        return check;
    }
    
    private void PlayerFound()
    {
        m_InputActive = true;
    }

    private void PlayerLost()
    {
        m_InputActive = false;
    }

    private Dictionary<OVRInput.Controller, GameObject> CreateControllerSets()
    {
        Dictionary<OVRInput.Controller, GameObject> newSets = new Dictionary<OVRInput.Controller, GameObject>()
        {
            { OVRInput.Controller.LTrackedRemote, m_LeftAnchor },
            { OVRInput.Controller.RTrackedRemote, m_RightAnchor }
        };
        return newSets;
    }
}
