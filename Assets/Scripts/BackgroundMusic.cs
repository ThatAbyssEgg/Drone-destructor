using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    [DllImport("winmm.dll")]
    private static extern bool sndPlaySound(string IpszName, int dwFlags);

    // Update is called once per frame
    void Update()
    {
        if (sndPlaySound(@"D:\Unity\2D game example\VR test\Assets\SFX\" + GetSound(), 0x0001 | 0x0010)) { }
    }

    private string GetSound()
    {
        List<string> soundList = new List<string> { "Cyclop.wav", "Eye.wav", "HEARTLESS.wav" };

        return soundList[Random.Range(0, soundList.Count)];
    }
}
