using UnityEngine;
using UnityEngine.UI;

public class TankShooting : MonoBehaviour
{
    public int m_PlayerNumber = 2;       
    public Rigidbody m_Shell;            
    public Transform m_FireTransform;    
    public Slider m_AimSlider;           
    public AudioSource m_ShootingAudio;  
    public AudioClip m_ChargingClip;     
    public AudioClip m_FireClip;         
    public float m_MinLaunchForce = 5f; 
    public float m_MaxLaunchForce = 15f; 
    public float m_MaxChargeTime = 0.75f;

    public GameObject tankRef;
    public GameObject shootArrow;


    private string m_FireButton;         
    private float m_CurrentLaunchForce;  
    private float m_ChargeSpeed;         
    private bool m_Fired;                

    public Joystick FireMovementJoyStick;
    public float m_TurnValue;   

private Vector3 originalPositionArrow ;
private Quaternion originalRotationArrow;
private Vector3 originalPositionShell ;
private Quaternion originalRotationShell;



    
    // public float test;

    private void OnEnable()
    {
        m_CurrentLaunchForce = m_MinLaunchForce;
        m_AimSlider.value = m_MinLaunchForce;

    }


    private void Start()
    {
        m_FireButton = "Fire" + m_PlayerNumber;

        m_ChargeSpeed = (m_MaxLaunchForce - m_MinLaunchForce) / m_MaxChargeTime;
    originalRotationArrow = shootArrow.transform.localRotation;
    originalPositionArrow = shootArrow.transform.localPosition;
    originalRotationShell = m_FireTransform.localRotation;
    originalPositionShell = m_FireTransform.localPosition;
    

    }


    private void Update()
    {
        // Track the current state of the fire button and make decisions based on the current launch force.
      
		m_AimSlider.value = m_MinLaunchForce;

        m_TurnValue = FireMovementJoyStick.Horizontal*100;

        
        if(m_TurnValue>10 || m_TurnValue<-10){
        m_FireTransform.RotateAround(tankRef.transform.position , Vector3.up, m_TurnValue * Time.deltaTime);
        m_AimSlider.transform.RotateAround(tankRef.transform.position , Vector3.up, m_TurnValue * Time.deltaTime);
        shootArrow.transform.RotateAround(tankRef.transform.position , Vector3.up, m_TurnValue * Time.deltaTime);

        }
    //     else{
    //     shootArrow.transform.localRotation = Quaternion.Slerp(shootArrow.transform.localRotation, originalRotationArrow,  Time.deltaTime);
    //     shootArrow.transform.localPosition = Vector3.Lerp(shootArrow.transform.localPosition, originalPositionArrow,  Time.deltaTime);
    //     m_FireTransform.localRotation =  Quaternion.Slerp(m_FireTransform.localRotation, originalRotationShell,  Time.deltaTime);
    //     m_FireTransform.localPosition =  Vector3.Lerp(m_FireTransform.localPosition, originalPositionShell,  Time.deltaTime);


    // }
    }


    public void Fire()
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