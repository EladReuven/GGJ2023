using DG.Tweening;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class rootMovement : MonoBehaviour
{

    public float xUnits = 6.0f;
    public float yUnits = 2.5f;

    [SerializeField] GameObject rootBase;
    [SerializeField] GameObject[] LeftRoots;
    [SerializeField] GameObject[] RightRoots;

    private void Start()
    {
        gameObject.transform.position = rootBase.transform.position;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            AudioManager.instance.PlaySound("rootgrowing");
            int x = Random.Range(0, RightRoots.Length);
            Instantiate(RightRoots[x], transform.position, RightRoots[x].transform.rotation);
            transform.DOMove(transform.position + RightRoots[x].GetComponentsInChildren<Transform>()[1].position, 1);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            AudioManager.instance.PlaySound("rootgrowing");
            int x = Random.Range(0, RightRoots.Length);
            Instantiate(LeftRoots[x], transform.position, LeftRoots[x].transform.rotation);
            transform.DOMove(transform.position + LeftRoots[x].GetComponentsInChildren<Transform>()[1].position, 1);
        }
    }
}





