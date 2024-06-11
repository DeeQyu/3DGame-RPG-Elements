using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    public Animator npcAnimator;

    void Update()
    {
        // You can add other NPC-specific logic here if needed.

        // Play idle animation for the NPC
        npcAnimator.SetBool("Idle", true);
    }
}