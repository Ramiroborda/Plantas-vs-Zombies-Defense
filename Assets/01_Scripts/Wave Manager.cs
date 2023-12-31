using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class WaveManager : MonoBehaviour
{
    public List<WaveObject>waves = new List<WaveObject>();
    public bool isWaitingForNextWaves;
    public bool wavesFinish;
    public int currentWave;
    public Transform initPosition;

    public TextMeshProUGUI counterText;
    public GameObject buttonNextWave;
    void Start()
    {
        StartCoroutine(ProcesWave());
    }
    void Update()
    {
        CheckCounterAndShowButton();
        CheckCounterForNextWave();
    }
    private void CheckCounterForNextWave()
    {
        if (isWaitingForNextWaves && !wavesFinish)
        {

            waves[currentWave].counterToNextWave -= 1 * Time.deltaTime;
            counterText.text =waves[currentWave].counterToNextWave.ToString("00");
            if (waves[currentWave].counterToNextWave <= 0)
            {
                ChangeWave();
                Debug.Log("Set Next Wave");
            }
        }
    }
    public void ChangeWave()
    {
        if (wavesFinish)
            return;
        currentWave++;
        StartCoroutine(ProcesWave());
    }
    private IEnumerator ProcesWave()
    {
        if (wavesFinish)
            yield break;
        isWaitingForNextWaves = false;
        waves[currentWave].counterToNextWave = waves[currentWave].timeForNextWave;
        for (int i = 0; i < waves[currentWave].enemy.Count; i++)
        {
            var enemyGo = Instantiate(waves[currentWave].enemy[i], initPosition.position, initPosition.rotation);
            yield return new WaitForSeconds(waves[currentWave].timePerCretion);
        }
        isWaitingForNextWaves = true;
        if (currentWave >= waves.Count-1)
        {
            Debug.Log("Nivel terminado");
            wavesFinish = true;
        }
    }

    private void CheckCounterAndShowButton()
    {
        if (wavesFinish)
        {
            buttonNextWave.SetActive(isWaitingForNextWaves);
            counterText.gameObject.SetActive(isWaitingForNextWaves);
        }
    }
    // Start is called before the first frame update
    

    // Update is called once per frame
    
}
[System.Serializable]
public class WaveObject
{
    public float timePerCretion = 1;
    public float timeForNextWave = 10;
    [HideInInspector]
    public float counterToNextWave = 0;
    public List<Enemy>enemy = new List<Enemy>();
}