using System;
using System.Collections.Generic;

namespace PEA_1
{
    class BranchAndBound
    {
        int t = 0;
        private int _totalCost;//total cost of visiting all cities
        private int _numberOfCities = Menu.cityQua;//number of cities in graph
        private int[,] _originalMatrix = Menu.citiesArray;//original cities matrix
        private int _weight = -1;

        List<int> resultPathList = new List<int>();//list for reasult path
        List<bool> visitedCities = new List<bool>(Menu.cityQua);//list of visited cities

        public List<int> Start()
        {
            for (int i = 0; i < _numberOfCities; i++)//this loop fill list with allready visited cities
            {
              visitedCities.Add(false);
              resultPathList.Add(0);
            }
            int[] tempPath = new int[_numberOfCities];//create tempPath array
            BaB(0, 0, 0,tempPath, 0);//here we start branch and bound function
            resultPathList.Insert(0, 0);//insert stat city to the result list
            return resultPathList;
        }
        public int GetCost() { return _totalCost; }
               
        private void BaB(int v0,int v,int w,int[] tempPath,int index)
        {
            int val;
            visitedCities[v] = true;
            if (Ifend())//Check if all nodes was visited
            {
                if (v!=v0)//Check if from last node there is route to first one
                {
                    if (_weight == -1)//Set new route weight
                    {
                        _weight = w + _originalMatrix[v, v0];
                        for (int i = 0; i < _numberOfCities; i++)
                            resultPathList[i] = tempPath[i];
                    }
                    else
                        if (_weight > w + _originalMatrix[v, v0])//Check if new weight is smaller than old one
                    {
                        _weight = w + _originalMatrix[v, v0];//Save currently the best path
                        for (int i = 0; i < _numberOfCities; i++)
                            resultPathList[i] = tempPath[i];
                    }
                }
                visitedCities[v] = false;
                return;//Return to search another route
            }
            else
            {
                for (int i = 0; i < _numberOfCities; i++)
                {
                    val = Bound(v) + w;
                    Console.WriteLine("v="+v+" val=" + val + " w=" + w+" t="+t);
                    if (v!=i && visitedCities[i] == false && (val < _weight || _weight == -1))//Check if from node v there is route to another node and if node value is smaller than weight
                    {
                        tempPath[index] = i;
                        Console.WriteLine("v0=" + v0 + " i=" + i + " weigth="+ w + _originalMatrix[v, i]+" index="+index);
                        BaB(v0, i, w + _originalMatrix[v,i], tempPath, index + 1);//If yes call function with new parameter
                    }
                    if (v == v0 && i == _numberOfCities - 1)//if actual city equals start city and actual i index equals the last city
                    {//End of algorithm
                        if (_weight > 0)
                        {
                            int j = v0;
                            _totalCost = _weight;
                        }
                        else
                        return;
                    }
                }
                visitedCities[v] = false;
                return;
            }
        }
        bool Ifend()//function checks that all cities have been visited. return true if yes.
        {
            for (int i = 0; i < _numberOfCities; i++)
            {
                if (visitedCities[i] == false)
                    return false;
            }
            return true;
        }
        int Bound(int v)
        {
            int min = 0, value = 0;
            for (int i = 0; i < _numberOfCities; i++)
            {
                if (visitedCities[i] == false || i == v)//if actual city was not visited or   we need to search this line of matrix
                {
                    for (int j = 0; j < _numberOfCities; j++)
                    {
                        if (i != j && visitedCities[j] == false)//if we're not trying to find way from A to A and we dont allready visited city number j we need to search for minimum in this column of matrix
                        {
                            if (min == 0)
                                min = _originalMatrix[i,j];
                            else
                                if (_originalMatrix[i,j] < min)
                                min = _originalMatrix[i,j];
                        }
                    }
                }
                value += min;
                min = 0;
            }
            return value;
        }       
    }
}