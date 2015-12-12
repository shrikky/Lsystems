using UnityEngine;
using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

public class LSystemManager : MonoBehaviour
{
    public struct State
    {
        public GameObject obj;
        public Vector3 position;
        public float dir;
    }

    public int maxDepth = 4;
    public string axiom = "0";

    private State state;
    public Stack<State> states = new Stack<State>();
    public State currentState;


    private Dictionary<char, string> rules = new Dictionary<char, string>();
    public GameObject preFab;
    public static LSystemManager getInstance;
    public Vector3 currentPos = new Vector3(0, 0, 0);
    private bool isUpdated;
    private int count;


    void Awake()
    {
        getInstance = this;
        rules.Add('1' , "11");
        rules.Add('0', "1[0]0");
        for(int i =0;i<maxDepth;i++)
        axiom = Expand(axiom);
       StartCoroutine(ApplyRules(axiom));
    }
   
    string Expand(string input)
    {
        StringBuilder s = new StringBuilder();
        foreach (char c in input) {
            if (LSystemManager.getInstance.rules.ContainsKey(c)){
                s.Append(LSystemManager.getInstance.rules[c]);
            }
            else {
                s.Append(c);
            }
        }
        return s.ToString();
    }
    public IEnumerator ApplyRules(string input)
    {
        GameObject go;
        currentState.obj = GameObject.Find("root");
        currentState.position = currentState.obj.transform.position;

        foreach (char c in input)
        {
            switch (c)
            {
                case '0':
                    go = Instantiate(preFab) as GameObject;
                    go.transform.SetParent(currentState.obj.transform);
                    go.transform.rotation = Quaternion.Euler(currentState.dir, 0, 0);
                    go.transform.position = currentState.position +  go.transform.up * 10f;
                    go.name = c.ToString() + count.ToString();
                    currentState.obj = go;
                    currentState.position = go.transform.position;
                    count++;
                    yield return new WaitForSeconds(0.5f);
                    break;
                case '1':
                    
                    go = Instantiate(preFab) as GameObject;
                    go.transform.SetParent(currentState.obj.transform);
                    go.transform.rotation = Quaternion.Euler(currentState.dir, 0, 0);
                    go.transform.position = currentState.position +  go.transform.up * 10f;
                    go.name = c.ToString() + count.ToString();
                    currentState.obj = go;
                    currentState.position = go.transform.position;
                    count++;
                    yield return new WaitForSeconds(0.5f);
                    break;
                case '[': // Push position and angle, Then rotate by 45

                    states.Push(currentState);
                    currentState.dir -= 45f;
                    currentState.position = currentState.obj.transform.position;

                    isUpdated = true;
                    yield return new WaitForSeconds(0.5f);
                    break;
                case ']':
                    // Pop position and angle, turn right by 45
                    currentState = states.Pop();
                    currentState.dir += 45f;
                    isUpdated = true;
                    yield return new WaitForSeconds(0.5f);
                    break;

                default:
                    break;
                 
            }
        }

        Debug.Log(input);
        axiom = input;
    }
}
