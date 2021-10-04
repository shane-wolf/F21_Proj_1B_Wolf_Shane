using System.Linq;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Dice : MonoBehaviour
{
    public RawImage dice1;
    public RawImage dice2;
    public RawImage dice3;
    public RawImage dice4;
    public RawImage dice5;

    public Text totalTextLabel;
    public Text textLabel;
    public Button rollDiceButton;

    public Texture[] diceTextures = new Texture[8];

    private IEnumerator coroutine1;
    private IEnumerator coroutine2;
    private IEnumerator coroutine3;
    private IEnumerator coroutine4;
    private IEnumerator coroutine5;

    private int[] lastRolls = new int[5];


    private void Start()
    {
        rollDiceButton.onClick.AddListener(() => rollDiceButtonClicked());
    }


    private void rollDiceButtonClicked()
    {
        lastRolls = new int[5];

        coroutine1 = RollDiceAction(dice1);
        coroutine2 = RollDiceAction(dice2);
        coroutine3 = RollDiceAction(dice3);
        coroutine4 = RollDiceAction(dice4);
        coroutine5 = RollDiceAction(dice5);

        StartCoroutine(coroutine1);
        StartCoroutine(coroutine2);
        StartCoroutine(coroutine3);
        StartCoroutine(coroutine4);
        StartCoroutine(coroutine5);
    }

    private IEnumerator RollDiceAction(RawImage diceImage)
    {
        int randomSide = 0;

        for (int i = 0; i <= 15; i++)
        {
            randomSide = Random.Range(0, 8);

            diceImage.texture = diceTextures[randomSide];

            yield return new WaitForSeconds(0.05f);
        }

        int lastSide = randomSide + 1;

        if (getArrayLength(lastRolls) == 0){
            lastRolls[0] = lastSide;
        }
        else
        {
            lastRolls[getArrayLength(lastRolls)] = lastSide;
        }


        if (getArrayLength(lastRolls) == 5){

            lastRolls = lastRolls.OrderByDescending(c => c).ToArray();

            string rollsString = "";
            int topThree = 0;
            for (int i = 0; i < lastRolls.Length; i++)
            {
                if (i < 3){
                    topThree += lastRolls[i];
                }

                rollsString += lastRolls[i] + ", ";
            }

            rollsString = rollsString.Remove(rollsString.Length - 2, 1);

            rollsString += "     Total of top 3 = " + topThree + " + 2 modifiers = " + (topThree + 2);
            Debug.Log("rollsString:" + rollsString);
            textLabel.text = rollsString;

            totalTextLabel.text = "" + (topThree + 2);
        }


    }

    private int getArrayLength(int[] array)
    {
        int length = 0;
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] != 0)
            {
                length += 1;
            }
        }

        return length;
    }
 
}
