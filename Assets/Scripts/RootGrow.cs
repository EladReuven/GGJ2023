using UnityEngine;

public class RootGrow : MonoBehaviour
{
    [SerializeField] float scaleTime;


    Vector3 goalSize;

    float countdownTimer = 0;

    bool sprout = true;


    private void Awake()
    {
        gameObject.transform.localScale = Vector3.zero;
        goalSize = transform.localScale;
    }

    private void Update()
    {
        if (sprout)
        {
            countdownTimer += Time.deltaTime;
            // Enter growth logic
            float liner = ((countdownTimer - 0) / (scaleTime - 0));

            transform.localScale = new Vector3(liner, liner, liner);

            print(liner);


            if (countdownTimer >= scaleTime)
            {
                sprout = false;
            }
        }
    }
}
