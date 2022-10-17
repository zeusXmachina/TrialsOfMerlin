using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.OpenXR.Input;

using UnityEngine.XR.Interaction.Toolkit;
using Unity.XR.CoreUtils;
namespace TOM.VRNavigation
{
    public class ContinuousMovement : MonoBehaviour
    {

        public float speed;
        public float rotSpeed;

        public XRNode inputSource;
        private Vector2 InputAxis;
        private CharacterController character;

        public XRNode rightSource;
        public Vector2 rightInputAxis;

        XROrigin xROrigin;
        // xr

        // Start is called before the first frame update
        void Start()
        {
            character = GetComponent<CharacterController>();
            xROrigin = GetComponent<XROrigin>();
        }

        // Update is called once per frame
        void Update()
        {
            InputDevice leftDevice = InputDevices.GetDeviceAtXRNode(inputSource);
            leftDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out InputAxis);

            InputDevice rightDevice = InputDevices.GetDeviceAtXRNode(rightSource);
            rightDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out rightInputAxis);
        }

        private void FixedUpdate()
        {

           Quaternion headYaw = Quaternion.Euler(0, xROrigin.Camera.transform.eulerAngles.y, 0);

           Vector3 direction = headYaw * new Vector3(InputAxis.x, 0f, InputAxis.y);
          // Vector3 direction = new Vector3(InputAxis.x,0f , InputAxis.y);
           character.Move(direction * Time.fixedDeltaTime * speed);


           transform.Rotate(new Vector3(0f, rightInputAxis.x * rotSpeed * Time.deltaTime, 0f));


        }




    }
}

