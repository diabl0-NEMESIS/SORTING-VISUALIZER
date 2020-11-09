using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selection_sort : MonoBehaviour
{
    void selection_sorting(int [] list)
    {
        int min_value;
        int temp;

        for (int i = 0; i < list.Length; i++)
        {
            min_value = i;
             
            for( int j=i+1;j<list.Length;j++)
            { //comparing the cubes on the basis of height
                if (list[j] < list[min_value])
                {
                    min_value = j;

                     
                }

            }

            if(min_value != i)
            {
                temp = list[i];
                list[i] = list[min_value];
                list[min_value] = temp;


                //temp_position = list[i].transform.localPosition;
               // list[i].transform.localPosition = new Vector3(list[min_value].transform.localPosition.x, temp_position.y, temp_position.z);
               // list[min_value].transform.localPosition = new Vector3(temp_position.x, list[min_value].transform.localPosition.y, list[min_value].transform.localPosition.z);

            }

        }

    }


    void Start()
    {
        //initializing my list array with values in random order
        
        int[] list = new int[] {2,5,3,1,4};

        Debug.Log("initial : ");
       
        selection_sorting(list);



    }

  
    void Update() 
    {
        
    }
}
