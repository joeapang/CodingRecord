using UnityEngine;
using System.Collections;

/// <summary>
/// 所有的音效管理
/// </summary>
public class AudioseBase : MonoBehaviour {

    public static AudioseBase instance;

    public AudioClip attack_miss;
    public AudioClip buff;
    public AudioClip button;
    public AudioClip heal;
    public AudioClip heal_all;
    public AudioClip skill_cast;
    public AudioClip skill_onehandQuick;
    public AudioClip slash_double;
    public AudioClip slash_normal;
    public AudioClip slash_normal2;
    public AudioClip hit_normal;
    public AudioClip sword_swing;
    public AudioClip weapon_swing;
    void Awake ( ) {
        instance = this;
    }
}
