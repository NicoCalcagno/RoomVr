using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
public class HandPresence : MonoBehaviour
{
    // Start is called before the first frame update
    public InputDeviceCharacteristics controllerCharacteristics;
    public List<GameObject> controllerPrefabs;
    public GameObject handPrefab;
    private InputDevice targetDevice;
    private Animator handAnimator;

    void Start()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics, devices);

        if(devices.Count > 0){
            targetDevice = devices[0];
        }
        handAnimator = handPrefab.GetComponent<Animator>();
    }

    void UpdateHandAnimator(){
        if(targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue)){
            handAnimator.SetFloat("Flex", triggerValue);
        }else{
            handAnimator.SetFloat("Flex", 0);
        }

        if(targetDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue)){
            handAnimator.SetFloat("Pinch", gripValue);
        }else{
            handAnimator.SetFloat("Pinch", 0);
        }
    }
    // Update is called once per frame
    void Update()
    {
        UpdateHandAnimator();
    }
}
