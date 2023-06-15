using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class punchSound : StateMachineBehaviour
{
    public AudioClip[] musicClips;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Rastgele bir m�zik se�
        AudioClip randomClip = musicClips[Random.Range(0, musicClips.Length)];

        // Se�ilen m�zi�i oynat
        AudioSource.PlayClipAtPoint(randomClip, animator.transform.position);
    }
}
