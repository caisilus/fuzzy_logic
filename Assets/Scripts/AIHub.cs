using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Input [v, a, r, l, b]
// Output [v, a]
public class AiHub
{
    private FuzzyAI currentAI;
    public AiHub()
    {
        Dictionary<float, float> d1 = new Dictionary<float, float>();
        for (int i = 0; i <= 10; i++)
        {
            if (i < 5){
                d1[i / 10f] = 1f;
            }
            else if (i < 7){
                d1[i / 10f] =  0.7f - 0.6f  * (i / 10f);
            }else{
                d1[i / 10f] = 0f;
            }
        }

        Dictionary<float, float> d2 = new Dictionary<float, float>();
        for (int i = -10; i <= 10; i++)
        {
            if (i < -5){
                d2[i / 10f] = 1f;
            }
            else if (i < 0){
                d2[i / 10f] =  -2 * (i / 10f);
            }else{
                d2[i / 10f] = 0f;
            }
        }

        FuzzySet closeLeft = new FuzzySet(d1);
        FuzzySet turnRightFast = new FuzzySet(d2);

        Debug.Log(turnRightFast);

        FuzzyRule rule1 = new FuzzyRule(new FuzzySet[]{closeLeft}, turnRightFast, 1, new int[]{3});
        FuzzyAI ai0 = new FuzzyAI(new FuzzyRule[]{rule1}, 2);
        currentAI = ai0;
    }

    public FuzzyAI getAI()
    {
        return this.currentAI;
    }
}
