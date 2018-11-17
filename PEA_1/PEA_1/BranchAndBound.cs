using System;
using System.Collections.Generic;

namespace PEA_1
{
    class BranchAndBound
    {
        int iter = 0;

        private int _totalCost;//total cost of visiting all cities
        private int _numberOfCities = Menu.cityQua;//number of cities in graph
        private int[,] _originalMatrix = Menu.citiesArray;//original cities matrix
        private int _weight = -1;//it will be the best route weight
        
        List<int> resultPathList = new List<int>();//list for reasult path
        List<bool> visitedCities = new List<bool>(Menu.cityQua);//list of visited cities

        public List<int> Start()
        {//in this function we start branch & bound algorithm
            for (int i = 0; i < _numberOfCities; i++)//this loop fill list with allready visited cities
            {
              visitedCities.Add(false);
              resultPathList.Add(0);
            }
            int[] tempPath = new int[_numberOfCities];//create tempPath array
            Branch(0, 0, 0,tempPath, 0);//here we start branch and bound function
            resultPathList.Insert(0, 0);//insert start city to the result list at the first place
            return resultPathList;
        }
        public int GetCost() { return _totalCost; }
               
        private void Branch(int startCity,int city,int w,int[] tempPath,int index)
        {//function search for new paths| startCity-city where we start, city-actual processed city,w-weight of actual route,tempPath-actual traveled route,index-tell us how much of route was traveled
            int val;
            visitedCities[city] = true;//we set actual city as visited
            if (Ifend())//Check if all cities was visited
            {
                if (city!=startCity)//Check if from last city there is route to first one
                {
                        if (_weight > w + _originalMatrix[city, startCity])//Check if new weight is smaller than old one
                    {
                        _weight = w + _originalMatrix[city, startCity]; Console.WriteLine(_weight);//Save currently the best path
                        for (int i = 0; i < _numberOfCities; i++)
                        {
                            resultPathList[i] = tempPath[i];
                           // Console.Write(resultPathList[i] + "->");
                        }
                    }
                    else if (_weight == -1)//Set new route weight
                    {
                        _weight = w + _originalMatrix[city, startCity]; Console.WriteLine(_weight);
                        for (int i = 0; i < _numberOfCities; i++)
                        {
                            resultPathList[i] = tempPath[i];
                           // Console.Write(resultPathList[i] + "->");
                        }                      
                    }
                   // Console.WriteLine();
                }
                visitedCities[city] = false;//when algorithm goes back we set city as not visited
                return;//Return to search another route
            }
            else//if some city was not visited
            {
                int lastval = 0,lastCity=Int32.MinValue;
                for (int i = 0; i < _numberOfCities; i++)
                {
                    if (lastCity == city)
                        val = lastval;
                    else
                    {
                        lastCity = city;
                        val = Bound(city) + w;//add path and potential path weight
                        lastval = val;
                    }

                    if (city!=i && visitedCities[i] == false && (val <= _weight || _weight == -1))//check if from actual city is road to another one
                    {
                        tempPath[index] = i;//we have another potential road
                        Branch(startCity, i, w + _originalMatrix[city,i], tempPath, index + 1);//If yes call function with new parameter
                    } 
                    if (city == startCity && i == _numberOfCities - 1)//if actual city equals start city and actual i index equals the last city
                    {//End of algorithm
                        if (_weight > 0)
                        {
                            _totalCost = _weight;
                        }
                        else 
                        return;
                    }
                }
                visitedCities[city] = false;
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
        int Bound(int v)//return sum of minimum ways which goes out from not visited cities and actual city
        {
            int value = 0;
            int min = Int32.MaxValue;

            for (int i = 0; i < _numberOfCities; i++)
            {
                if (!visitedCities[i] || i == v )//if actual city was not visited or i is actual city we need to search this line of matrix
                {
                    for (int j = 0; j < _numberOfCities; j++)
                    {
                        if ((visitedCities[v] && i==v) || (!visitedCities[j] && j != i) /*&& v!=j */)//if we're not trying to find way from A to A and we dont allready visited city number j we need to search for minimum in this column of matrix
                        {//if actual min value is smaller we use it
                            if (_originalMatrix[i, j] < min)
                                 min = _originalMatrix[i, j];
                        }
                    }
                }
                if (min != Int32.MaxValue)
                {
                    value += min;
                    if (value > _weight && _weight!=-1)
                        return Int32.MaxValue;
                    min = Int32.MaxValue;
                }
            }
            return value;
        }       
    }
}