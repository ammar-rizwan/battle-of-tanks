using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class EnemyFire : MonoBehaviour
{
    //public GameObject target1;
    public Transform t;
    public GameObject target;
    public int m_PlayerNumber = 2;
    public Rigidbody m_Shell;
    public Transform m_FireTransform;
    public Slider m_AimSlider;
    public AudioSource m_ShootingAudio;
    public AudioClip m_ChargingClip;
    public AudioClip m_FireClip;
    public float m_MinLaunchForce = 15f;
    public float m_MaxLaunchForce = 30f;
    public float m_MaxChargeTime = 0.75f;

    public GameObject tankRef;
    public GameObject shootArrow;

    private string m_FireButton;
    private float m_CurrentLaunchForce;
    private float m_ChargeSpeed;
    private bool m_Fired;
    public Joystick FireMovementJoyStick;
    public float m_TurnValue;
    public float speedF=3;

    private void OnEnable()
    {
        m_CurrentLaunchForce = m_MinLaunchForce;
        m_AimSlider.value = m_MinLaunchForce;
      

    }
    public void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }

    private void Start()
    {
        m_FireButton = "Fire" + m_PlayerNumber;

        m_ChargeSpeed = (m_MaxLaunchForce - m_MinLaunchForce) / m_MaxChargeTime;
        StartCoroutine(FireCheck());

    }
    IEnumerator FireCheck()
    {
        while (true)
        {
            float distance = Vector3.Distance(transform.position, target.transform.position);
            if (distance < 12.0f)
            {
                Fire();
            }
            yield return new WaitForSeconds(speedF);
            
        }

    }
    


    private void Fire()
    {
        // Instantiate and launch the shell.
        m_Fired = true;

        Rigidbody shellInstance = Instantiate(m_Shell, m_FireTransform.position, m_FireTransform.rotation) as Rigidbody;

        shellInstance.velocity = m_CurrentLaunchForce * m_FireTransform.forward;

        m_ShootingAudio.clip = m_FireClip;
        m_ShootingAudio.Play();

        m_CurrentLaunchForce = m_MinLaunchForce;
    }
}