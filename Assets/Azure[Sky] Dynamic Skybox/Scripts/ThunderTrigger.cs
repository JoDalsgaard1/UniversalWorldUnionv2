using UnityEngine;
using UnityEngine.AzureSky;

public class ThunderTrigger : MonoBehaviour
{
    public AzureEffectsController effectsController; // Drag the sky prefab here!
    public float minTimeToPlay = 2.0f;
    public float maxTimeToPlay = 30.0f;

    private float m_counter = 0.0f;    // Change it temporary to public to see it working in the Inspector
    private float m_timeToPlay = 0.0f; // Change it temporary to public to see it working in the Inspector
    private int m_thunderID = 0;
    private bool thunderAllowed = false;
    [SerializeField] private Collider playerCollider;
    private Collider myCollider;
    [SerializeField] private GameObject noRainWeatherZone;


    // Start is called before the first frame update
    void Start()
    {
        m_timeToPlay = Random.Range(minTimeToPlay, maxTimeToPlay);
        myCollider = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider playerCollider)
    {
        thunderAllowed = true;
        noRainWeatherZone.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        m_counter += Time.deltaTime;
        //Debug.Log("running!");

        // If reach the time to play the effect
        if (m_counter >= m_timeToPlay && thunderAllowed)
        {
                // Select a random "Thunder Effect" from the "Thunder" list
                m_thunderID = Random.Range(0, effectsController.thunderSettingsList.Count);

                // Instantiate the thunder effect
                effectsController.InstantiateThunderEffect(m_thunderID);

            // Reset the counter
            m_counter = 0.0f;
            m_timeToPlay = Random.Range(minTimeToPlay, maxTimeToPlay);
        }
    }
}