using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : Item_Base
{
    [SerializeField] private float _spawnDelay;
    private float _spawnCoolTime = 0;
    [SerializeField] private bool _instantCreate;

    private Queue<string> _names = new Queue<string>();
    private Queue<Vector3> _vecs = new Queue<Vector3>();
    private Queue<Quaternion> _quats = new Queue<Quaternion>();

    private void Awake()
    {
        int childCount = transform.childCount;

        while(transform.childCount > 0)
        {
            Transform t = transform.GetChild(0);
            int index = name.LastIndexOf(' ');

            _names.Enqueue(t.name.Substring(0, index));
            _vecs.Enqueue(t.position);
            _quats.Enqueue(t.rotation);

            Managers.Resource.Destroy(t.gameObject);
        }
    }
    private void Update()
    {
        if(_names.Count == 0)
        {
            Managers.Resource.Destroy(this.gameObject);
            return;
        }

        if (!_instantCreate)
        {
            _spawnCoolTime += Time.deltaTime;
            if (_spawnDelay < _spawnCoolTime)
            {
                _spawnCoolTime = 0;
                Create();
            }
        }
        else
        {
            while(_names.Count != 0)
            {
                Create();
            }
        }
    }

    protected virtual void Create()
    {
        Managers.Resource.Instantiate(_names.Dequeue() , _vecs.Dequeue() , _quats.Dequeue());
    }
}
