using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TrackManager : MonoBehaviour
{
    [SerializeField] private Transform trackEnd;

    [SerializeField] private Transform trackBegin;

    [SerializeField] private float moveSpeed = 0f;
    [SerializeField] private GameObject wallHolder = null;
    [SerializeField] private List<Material> colors = new List<Material>();

    private Vector3 trackEndPos = Vector3.zero;
    private Vector3 trackPos = Vector3.zero;
    private List<MeshRenderer> wallRenderers = new List<MeshRenderer>();

    // Start is called before the first frame update
    void Start()
    {
        trackEndPos = trackEnd.position;
        trackPos = transform.position;
        for(int i=0;i<wallHolder.transform.childCount;i++)
        {
            wallRenderers.Add(wallHolder.transform.GetChild(i).gameObject.GetComponent<MeshRenderer>());
            
        }
        colorChanger(); 
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-Vector3.forward * moveSpeed * Time.deltaTime);
        trackPos = transform.position;

        if (trackPos.z <= trackEndPos.z)
        {
            transform.position = new Vector3(0, 0, trackBegin.position.z);
        }
    }

    private void colorChanger()
    {
        List<Material> temp = new List<Material>();
        temp = colors;
        int index;
        foreach (MeshRenderer r in wallRenderers)
        {
            index = Random.Range(0, temp.Count);
            r.material = temp[index];
            r.gameObject.tag = "Wall";
            temp.RemoveAt(index);
        }

       GameObject gate = wallRenderers[Random.Range(0, wallRenderers.Count)].gameObject;
       gate.tag = "Gate";
       Player.instance.playerMeshRenderer.material = gate.GetComponent<MeshRenderer>().material;
    }
}
