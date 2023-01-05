using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Hand : MonoBehaviour
{
    public GameObject handPrefab;
    public InputDeviceCharacteristics inputDeviceCharacteristics;

    private InputDevice targetDevice;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        InitializeHand();
    }

    void InitializeHand()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(inputDeviceCharacteristics, devices);

        if (devices.Count > 0)
        {
            targetDevice = devices[0];

            GameObject spawnedHand = Instantiate(handPrefab, transform);
            animator = spawnedHand.GetComponent<Animator>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!targetDevice.isValid)
        {
            InitializeHand();
        }
        //else
        //{
        //    UpdateHand();
        //}
    }

    //void UpdateHand()
    //{
    //    if (targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue))
    //    {
    //        animator.SetFloat("Trigger", triggerValue);
    //    }
    //    else
    //    {
    //        animator.SetFloat("Trigger", 0);
    //    }

    //    if (targetDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue))
    //    {
    //        animator.SetFloat("Grip", gripValue);
    //    }
    //    else
    //    {
    //        animator.SetFloat("Grip", 0);
    //    }
    //}
}
