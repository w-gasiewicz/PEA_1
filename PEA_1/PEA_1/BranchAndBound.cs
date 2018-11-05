using System;
using System.Collections.Generic;

namespace PEA_1
{
    class BranchAndBound
    {
        private int _totalCost;//total cost of visiting all cities
        private int _numberOfCities = Menu.cityQua;//number of cities in graph
        private int[,] _originalMatrix = Menu.citiesArray;//original cities matrix
        private int _weight = -1;
        private int[] _resultPath;

        List<int> resultPathList = new List<int>();//list for reasult path
        List<bool> visitedCities = new List<bool>(Menu.cityQua);//list of visited cities

        public List<int> Start()
        {
            resultPathList.Add(0);//add first city to the result path
            _resultPath = new int[_numberOfCities];
            for (int i = 0; i < _numberOfCities; i++)//this loop fill list with allready visited cities
                visitedCities.Add(false);
            int[] tempPath = new int[_numberOfCities];
            BaB(0, 0, 0,tempPath, 0);
            for (int i = 0; i < _numberOfCities; i++)//copy result from array to list
                resultPathList.Add(_resultPath[i]);
            return resultPathList;
        }
        public int GetCost() { return _totalCost; }
               
        private void BaB(int v0,int v,int w,int[] tempPath,int index)
        {
            int val;
            visitedCities[v] = true;
            if (Ifend())//Check if all nodes was visited
            { 
                if (_originalMatrix[v,v0] > 0)//Check if from last node there is route to first one
                {
                    if (_weight == -1)//Set new route weight
                    {
                        _weight = w + _originalMatrix[v, v0];
                        for (int i = 0; i < _numberOfCities; i++)
                            _resultPath[i] = tempPath[i];
                    }
                    else
                        if (_weight > w + _originalMatrix[v, v0])//Check if new weight is smaller than old one
                    {
                        _weight = w + _originalMatrix[v, v0];//Save currently the best path
                        for (int i = 0; i < _numberOfCities; i++)
                            _resultPath[i] = tempPath[i];
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
                    if (_originalMatrix[v, i] > 0 && visitedCities[i] == false && (val < _weight || _weight == -1))//Check if from node v there is route to another node and if node value is smaller than weight
                    {
                        tempPath[index] = i;
                        BaB(v0, i, w + _originalMatrix[v,i], tempPath, index + 1);//If yes, call function with new parameter
                    }
                    if (v == v0 && i == _numberOfCities - 1)
                    {//End of algoruthm
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
                if (visitedCities[i] == false || i == v)
                {
                    for (int j = 0; j < _numberOfCities; j++)
                    {
                        if (i != j && visitedCities[j] == false)
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