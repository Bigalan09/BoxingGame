using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Boxer player1 = BoxerFactory.Instance.CreateBoxer();
        Boxer player2 = BoxerFactory.Instance.CreateBoxer();
        Boxer player3 = BoxerFactory.Instance.CreateBoxer();
        Boxer player4 = BoxerFactory.Instance.CreateBoxer();

        Debug.Log(player1);
        Debug.Log(player2);
        Debug.Log(player3);
        Debug.Log(player4);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
