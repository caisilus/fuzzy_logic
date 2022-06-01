using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Input [v, a, r, l, b]
// Output [v, a]
public class AiHub
{
    public static float f1(float x)
    {
        if (x < 0.5f){
            return 1f;
        }
        else if (x < 0.7f){
            return 0.7f - 0.6f  * x;
        }else{
            return 0f;
        }
    }
    public static float f2(float x)
    {
        if (x < -0.5f){
            return 1f;
        }
        else if (x < 0f){
            return  -2 * x;
        }else{
            return 0f;
        }
    }

    public static float f3(float x)
    {
        if (x < 0f){
            return 0f;
        }
        else if (x < 0.5f){
            return  2 * x;
        }else{
            return 1f;
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
        F fun3 = f3;
        FuzzySet closeLeft = new FuzzySet(0, 1, 10.0f, fun1);
        FuzzySet closeRight = new FuzzySet(0, 1, 10.0f, fun1);
        FuzzySet turnRightFast = new FuzzySet(-1, 1, 20.0f, fun2);
        FuzzySet turnLeftFast = new FuzzySet(-1, 1, 20.0f, fun3);

        Debug.Log(turnRightFast);
        Debug.Log(closeLeft);

        FuzzyRule rule1 = new FuzzyRule(new FuzzySet[]{closeLeft}, turnRightFast, 1, new int[]{3});
        FuzzyRule rule2 = new FuzzyRule(new FuzzySet[]{closeRight}, turnLeftFast, 1, new int[]{2});
        FuzzyAI ai0 = new FuzzyAI(new FuzzyRule[]{rule1, rule2}, 2);
        currentAI = ai0;
    }

    public FuzzyAI getAI()
    {
        return this.currentAI;
    }
}
