using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public int massiveLength, summ = 0;
    public int[] isGroundInt;
    public bool[] isGroundBool;
    public GameObject[] grounds;

    public void Awake()
    {
        massiveLength = isGroundInt.Length;
        for (int i = 0; i <= (massiveLength - 1); i++)
        {
            isGroundInt[i] = Mathf.RoundToInt(Random.Range(0, 2));
            if (isGroundInt[i] == 1)
                isGroundBool[i] = true;
            else isGroundBool[i] = false;
            summ += isGroundInt[i];
        }
    }

    private void Start()
    {
        if(summ == massiveLength)
        {
            isGroundBool[Mathf.RoundToInt(Random.Range(0, massiveLength))] = false;
        }
        else if (summ == 0)
        {
            isGroundBool[Mathf.RoundToInt(Random.Range(0, massiveLength))] = true;
        }

        for (int i = 0; i < massiveLength; i++)
        {
            grounds[i].SetActive(isGroundBool[i]);
        }
    }
}
