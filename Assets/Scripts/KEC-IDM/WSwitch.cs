// using System;
// using UnityEngine;
// using UnityEngine.Events;
// public class WSwitch : MonoBehaviour
// {
//     public float m_Distance = 10.0f;
//     public LineRenderer m_LineRenderer = null;
//     public LayerMask m_EverythingMask;
//     public LayerMask m_InteractableMask;
//     public UnityAction<Vector3, GameObject> onPointerUpdate = null;
//     public GameObject reticle;
//
//     private Transform m_CurrentOrigin = null;
//     private GameObject m_CurrentObject = null;
//     private static Vector3 hitVector;
//     
//     //custom vars for tools
//     public GameObject GazePointer;
//     public GameObject GrabbedObject;
//     private WeaponActions wpnActions;
//     public GameObject Weapon;
//     public GameObject Teleporter;
//     public GameObject Grabhand;
//     public Transform GrabTransform;
//     public Transform ShotOrigin;
//
//
//     private void Awake()
//     {
//         PlayerEvents.OnControllerSource += UpdateOrigin;
//         PlayerEvents.OnTouchpadDown += ProcessTouchpadDown;
//         PlayerEvents.OnTouchpadUp += ProcessTouchpadUp;
//         PlayerEvents. += ProcessTriggerPulled;
//         PlayerEvents.OnTriggerRelease += ProcessTriggerRelease;
//
//         wpnActions = Weapon.GetComponent<WeaponActions>();
//         m_CurrentOrigin = ShotOrigin;
//         GazePointer.SetActive(false);
//     }
//
//     private void OnDestroy()
//     {
//         
//     }
//
//     void Start()
//     {
//         
//     }
//
//     // Update is called once per frame
//     void Update()
//     {
//         
//     }
// }
