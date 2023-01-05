using System;
using UnityEngine;
using System.Runtime.InteropServices;
using VRShooterKit;
using TMPro;


public class DroneOnDeath : MonoBehaviour
{
    public TextMeshPro scoreboard;
    public Transform spawner;

    [DllImport("winmm.dll")] 
    private static extern bool sndPlaySound(string IpszName, int dwFlags);

    private DroneAI droneAI;
    private Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
        droneAI = GetComponent<DroneAI>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Update scoreboard
        int score = Convert.ToInt32(scoreboard.text);
        score += 50;
        scoreboard.text = score.ToString();

        // Destroy the bullet
        Destroy(collision.gameObject);
        
        // Play the destruction sound
        sndPlaySound(@"D:\Unity\2D game example\VR test\Assets\SFX\DroneBroken.wav", 0x0001);
        animator.SetTrigger("Destroy");

        // Create a new drone based on the spawner location
        Vector3 spawnLocation = spawner.position;
        Instantiate(gameObject, spawnLocation + new Vector3(UnityEngine.Random.Range(-5f, 5f), 0, UnityEngine.Random.Range(-5f, 5f)), Quaternion.identity);

        // Disable drone AI & delete the drone after the delay
        droneAI.enabled = false;
        Destroy(gameObject, 5f);
        Debug.Log("Object destroyed. Current score is " + scoreboard.text + ".");

    }
}
