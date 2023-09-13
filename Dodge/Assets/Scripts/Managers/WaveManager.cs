using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class Wave
{
    public string spawnName;
    public float waitTime;
}
[Serializable]
public class WaveData
{
    public List<Wave> waves = new List<Wave>();
}

public class WaveManager : MonoBehaviour
{
    private Queue<Wave> _waves = new Queue<Wave>();
    private Wave nowWaveData;
    private GameObject nowSpawn;
    private float nowTime;
    private bool _allSpawn;
    // Start is called before the first frame update
    void Start()
    {
        TextAsset textAsset =  Managers.Resource.Load<TextAsset>($"Data/WaveData");
        WaveData data = JsonUtility.FromJson<WaveData>(textAsset.text);

        foreach(Wave wave in data.waves)
        {
            _waves.Enqueue(wave);
        }
        nowWaveData = _waves.Dequeue();
    }

    // Update is called once per frame
    void Update()
    {
        if (_allSpawn)
            return;

        if(nowSpawn == null)
        {
            nowTime += Time.deltaTime;
            if(nowTime > nowWaveData.waitTime)
            {
                nowSpawn = Managers.Resource.Instantiate(nowWaveData.spawnName);
                nowSpawn.GetComponent<Spawn>()._waveManager = this.gameObject;
                if (_waves.Count == 0)
                {
                    _allSpawn = true;
                    return;
                }
                nowWaveData = _waves.Dequeue();
                nowTime = 0;
            }
            
        }
    }

    public void ResetNowSpawn()
    {
        nowSpawn = null;
    }
}
