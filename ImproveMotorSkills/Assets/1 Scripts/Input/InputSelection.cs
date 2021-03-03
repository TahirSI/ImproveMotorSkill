using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSelection : MonoBehaviour
{
    public int GetRandNumber(int min, int max)
    {
        return Random.Range(min, max);
    }

    public KeyCode GetRandInout(int index)
    {
        KeyCode retunKeyCod = KeyCode.A;

        if (index == 0)       // A
        {
            retunKeyCod = KeyCode.A;
        }
        else if (index == 1)  // B
        {
            retunKeyCod = KeyCode.B;
        }
        else if (index == 2)  // C
        {
            retunKeyCod = KeyCode.C;
        }
        else if (index == 3)  // D
        {
            retunKeyCod = KeyCode.D;
        }
        else if (index == 4)  // E
        {
            retunKeyCod = KeyCode.E;
        }
        else if (index == 5) // F
        {
            retunKeyCod = KeyCode.F;
        }
        else if (index == 6)  // G
        {
            retunKeyCod = KeyCode.G;
        }
        else if (index == 7)  // H
        {
            retunKeyCod = KeyCode.H;
        }
        else if (index == 8)  // I
        {
            retunKeyCod = KeyCode.I;
        }
        else if (index == 9)  // J
        {
            retunKeyCod = KeyCode.J;
        }
        else if (index == 10) // K
        {
            retunKeyCod = KeyCode.K;
        }
        else if (index == 11) // L
        {
            retunKeyCod = KeyCode.L;
        }
        else if (index == 12) // M
        {
            retunKeyCod = KeyCode.M;
        }
        else if (index == 13) // N
        {
            retunKeyCod = KeyCode.N;
        }
        else if (index == 14) // O
        {
            retunKeyCod = KeyCode.O;
        }
        else if (index == 15) // P
        {
            retunKeyCod = KeyCode.P;
        }
        else if (index == 16) // Q
        {
            retunKeyCod = KeyCode.Q;
        }
        else if (index == 17) // R
        {
            retunKeyCod = KeyCode.R;
        }
        else if (index == 18) // S
        {
            retunKeyCod = KeyCode.S;
        }
        else if (index == 19) // T
        {
            retunKeyCod = KeyCode.T;
        }
        else if (index == 20) // U
        {
            retunKeyCod = KeyCode.U;
        }
        else if (index == 21) // V
        {
            retunKeyCod = KeyCode.V;
        }
        else if (index == 22) // W
        {
            retunKeyCod = KeyCode.W;
        }
        else if (index == 23) // X
        {
            retunKeyCod = KeyCode.X;
        }
        else if (index == 24) // Y
        {
            retunKeyCod = KeyCode.Y;
        }
        else if (index == 25) // Z
        {
            retunKeyCod = KeyCode.Z;
        }

        return retunKeyCod;
    }
}
