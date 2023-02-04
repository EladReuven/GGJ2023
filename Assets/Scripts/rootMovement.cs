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
    [SerializeField] PlatformGenerator platformGenerator;

    public RootState RootMovementState { get; private set; }

    KeyCode lastKey;

    float timeElapsed;
    float growTime = 1f;

    bool init = false;

    private void Start()
    {
        gameObject.transform.position = rootBase.transform.position;
    }

    void Update()
    {
        if (!init)
        {
            init = true;
            platformGenerator.GeneratePlatformsInitial();
        }
        switch (RootMovementState)
        {
            case RootState.Idle:
                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    AudioManager.instance.PlaySound("rootgrowing");
                    int x = Random.Range(0, RightRoots.Length);
                    Instantiate(RightRoots[x], transform.position, RightRoots[x].transform.rotation);
                    Vector3 newVector = RightRoots[x].GetComponentsInChildren<Transform>()[1].position;
                    Vector3 newestVector = new Vector3((transform.position.x - newVector.x), newVector.y + transform.position.y, newVector.z + transform.position.z);
                    transform.DOMove(newestVector, 1);
                    print(RightRoots[x].GetComponentsInChildren<Transform>()[1].name);
                    RootMovementState = RootState.Grow;
                }
                else if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    AudioManager.instance.PlaySound("rootgrowing");
                    int x = Random.Range(0, LeftRoots.Length);
                    Instantiate(LeftRoots[x], transform.position, LeftRoots[x].transform.rotation);
                    transform.DOMove(transform.position + LeftRoots[x].GetComponentsInChildren<Transform>()[1].position, 1);
                    RootMovementState = RootState.Grow;
                }
                break;
            case RootState.Grow:
                RootMovementState = RootState.IsGrowing;
                timeElapsed += Time.deltaTime;
                break;
            case RootState.IsGrowing:
                timeElapsed += Time.deltaTime;
                if (timeElapsed >= growTime)
                {
                    // Generate new Tiles
                    timeElapsed = 0;
                    platformGenerator.GeneratePlatforms(new Vector3(transform.position.x,platformGenerator.lastTransform.y,0),false);
                    RootMovementState = RootState.Idle;
                }
                break;
        }
    }

}
public enum RootState { Idle, Grow, IsGrowing }
