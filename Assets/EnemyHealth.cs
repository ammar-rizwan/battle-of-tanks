using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyHealth : MonoBehaviour
{
    public float m_StartingHealth = 100f;
    public Slider m_Slider;
    public Image m_FillImage;
    public Color m_FullHealthColor = Color.green;
    public Color m_ZeroHealthColor = Color.red;
    public GameObject m_ExplosionPrefab;
    public int liv = 3;
    private AudioSource m_ExplosionAudio;
    private ParticleSystem m_ExplosionParticles;
    private float m_CurrentHealth;
    private bool m_Dead;
    //public Text healthText;
    public TextMeshProUGUI healthText1;
    private void Awake()
    {
        m_ExplosionParticles = Instantiate(m_ExplosionPrefab).GetComponent<ParticleSystem>();
        m_ExplosionAudio = m_ExplosionParticles.GetComponent<AudioSource>();

        m_ExplosionParticles.gameObject.SetActive(false);
    }


    private void OnEnable()
    {
        m_CurrentHealth = m_StartingHealth;
        m_Dead = false;
        healthText1.text = liv.ToString();

        SetHealthUI();
    }
    private void re()
    {
        liv = liv - 1;
        m_CurrentHealth = m_StartingHealth;
        m_Dead = false;

        SetHealthUI();
    }


    public void TakeDamage(float amount)
    {
        // Adjust the tank's current health, update the UI based on the new health and check whether or not the tank is dead.
        m_CurrentHealth -= amount;

        SetHealthUI();
        Debug.Log("I am here");
        if (m_CurrentHealth <= 0f && !m_Dead)
        {
            if (liv > 0)
            {
                re();
            }
            else
            {
                liv = liv - 1;
                //healthText.text = "Lives" + liv.ToString();
                healthText1.text= liv.ToString();
                OnDeath();
            }

        }
    }


    private void SetHealthUI()
    {
        // Adjust the value and colour of the slider.
        m_Slider.value = m_CurrentHealth;

        m_FillImage.color = Color.Lerp(m_ZeroHealthColor, m_FullHealthColor, m_CurrentHealth / m_StartingHealth);
        //healthText.text = "Lives" + liv.ToString();
        healthText1.text = liv.ToString();
    }
    public void Start()
    {
        healthText1.text = liv.ToString();

    }

    private void OnDeath()
    {
        // Play the effects for the death of the tank and deactivate it.
        m_Dead = true;

        m_ExplosionParticles.transform.position = transform.position;
        m_ExplosionParticles.gameObject.SetActive(true);
        m_ExplosionParticles.Play();
        m_ExplosionAudio.Play();
        UIManager.RemainingEnemies--;
        UIManager.KillCounter++;
        Destroy(gameObject);
        
        //gameObject.SetActive(false);
    }
}