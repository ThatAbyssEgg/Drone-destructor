using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public float speed;
    public GameObject bulletObject;
    public Transform gunBarrel;

    [DllImport("winmm.dll")]
    private static extern bool sndPlaySound(string IpszName, int dwFlags);
    public void Fire()
    {
        sndPlaySound("D:\\Unity\\2D game example\\VR test\\Assets\\SFX\\" + GetSound(), 0x0001);
        GameObject spawnedBullet = Instantiate(bulletObject, gunBarrel.position, gunBarrel.rotation);
        spawnedBullet.GetComponent<Rigidbody>().velocity = speed * gunBarrel.forward;
        Destroy(spawnedBullet, 5f);
    }

    private string GetSound()
    {
        List<string> soundList = new List<string> { "EnergyShot1.wav", "EnergyShot2.wav" };

        return soundList[Random.Range(0, soundList.Count)];
    }
}
