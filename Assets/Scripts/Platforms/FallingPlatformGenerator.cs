using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatformGenerator : MonoBehaviour
{
    public int massiveLength, summ = 0;
    [HideInInspector] public int[] isGroundInt, isFallingGroundInt;
    [HideInInspector] public bool[] isGroundBool, isFallingGroundBoos;
    public GameObject[] grounds, fallingGrounds;
    public bool haveGround = false;

    public void Awake()
    {
        massiveLength = isGroundInt.Length;
        if (haveGround == false)
        {
            for (int i = 0; i <= (massiveLength - 1); i++)
            {
                isGroundInt[i] = Mathf.RoundToInt(Random.Range(0, 2));
                if (isGroundInt[i] == 1 && haveGround == false)
                {
                    isGroundBool[i] = true;
                    haveGround = true;
                }
                else isGroundBool[i] = false;
            }
        }

        if (haveGround == true)
        {
            for(int j = 0; j <= (massiveLength - 1); j++)
            {
                if(isGroundInt[j] == 0)
                {
                    isFallingGroundInt[j] = Mathf.RoundToInt(Random.Range(0, 2));
                }
                if(isFallingGroundInt[j] == 1)
                {
                    isFallingGroundBoos[j] = true;
                }
                else isFallingGroundBoos[j] = false;
            }
        }


    }

    private void Start()
    {
        if(haveGround == true)
        {
            for (int i = 0; i <= (massiveLength - 1); i++)
            {
                grounds[i].SetActive(isGroundBool[i]);
                fallingGrounds[i].SetActive(isFallingGroundBoos[i]);
            }
        }
        else
        {
            grounds[Mathf.RoundToInt(Random.Range(-0.49f, massiveLength - 1))].SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
