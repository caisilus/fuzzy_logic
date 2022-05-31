using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Input [v, a, r, l, b]
// Output [v, a]
public class AiHub
{
    public static float f1(int x)
    {
        if (x < 5){
            return 1f;
        }
        else if (x < 7){
            return 0.7f - 0.6f  * (x / 10f);
        }else{
            return 0f;
        }
    }
    public static float f2(int x)
    {
        if (x < -5){
            return 1f;
        }
        else if (x < 0){
            return  -2 * (x / 10f);
        }else{
            return 0f;
        }
    }
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

        F fun1 = f1;
        F fun2 = f2;
        FuzzySet closeLeft = new FuzzySet(0, 10, 10f, fun1);
        FuzzySet turnRightFast = new FuzzySet(-10, 10, 10f, fun2);

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
