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
        if (_waves.Count == 0)
            return;

        if(nowSpawn == null)
        {
            nowTime += Time.deltaTime;
            if(nowTime > nowWaveData.waitTime)
            {
                nowSpawn = Managers.Resource.Instantiate(nowWaveData.spawnName);
                nowWaveData = _waves.Dequeue();
            }
            
        }
    }
}
