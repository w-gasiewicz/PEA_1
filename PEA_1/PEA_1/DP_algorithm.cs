using System;
using System.Collections.Generic;

namespace PEA_1
{
    class DP_algorithm
    {
        int[,] distances,parents;
        int VISITED_ALL_MASK = (1 << Menu.cityQua) - 1;
        List<int[]> testParents = new List<int[]>();

        int test = 0,c=0,i=0;
        int setSize = 0;
        public List<int> selectedCities = new List<int>();
        List<Path> pathList = new List<Path>();
        Path p = new Path();

        #region private variables
        private int totalCost=Int32.MaxValue;
        private List<int> _visitedCities=new List<int>();
        private int _numberOfCities=Menu.cityQua;
        private List<int> _citiesToVisit = new List<int>(Menu.cityQua);
        private List<int> _cities = new List<int>(Menu.cityQua);
        private int[,] _matrix=Menu.citiesArray;
        private int[,] _allreadyVisited=new int[1,Menu.cityQua-1];
        #endregion
        
        #region private functions and classes
        private class Node
        {
            public int Value { get; set; }
            public Node[] ChildNodes { get; set; }
            public bool Selected { get; set; }
        }
        private class Path
        {
            public int Cost;
            public int StartCity;
            public List<int> CitiesVisited=new List<int>(Menu.cityQua);
            public int EndCity;
            public Path RootPath;
        }
        private void FillCitiesToVisit()
        {
            for (int i = 0; i < _numberOfCities; i++)
            {
                _citiesToVisit.Add(i); _cities.Add(i);
            }
        }
        private int SearchBestWay(int startVertex, List<int> set, Node root)
        {
            if (set.Count == 0)
            { 
                root.ChildNodes = new Node[1] { new Node { Value = _cities[0], Selected = true } };
                return _matrix[startVertex, 0];
            }

            int totalCost = Int32.MaxValue;
            int i = 0;
            int selectedIdx = i;
            root.ChildNodes = new Node[set.Count];
            string way = "";
            foreach (var destination in set)
            {
                c++;
                root.ChildNodes[i] = new Node { Value = destination };               

                int costOfVistingCurrentNode = _matrix[startVertex, destination];

                way += root.Value.ToString() + "->"+root.ChildNodes[i].Value.ToString()+ " koszt="+costOfVistingCurrentNode;
                Console.WriteLine(way);
                test++;
                var newSet = new List<int>(set);
                newSet.Remove(destination);

                int costOfVisitingOtherNodes = SearchBestWay(destination, newSet, root.ChildNodes[i]);
                int currentCost = costOfVistingCurrentNode + costOfVisitingOtherNodes;

                way = "koszt sciezki=" + currentCost + Environment.NewLine;
                Console.WriteLine(way);

                if (totalCost > currentCost)
                {
                    totalCost = currentCost;
                    selectedIdx = i;
                }
                i++;
            }
            root.ChildNodes[selectedIdx].Selected = true;

            return totalCost;

        }
        private void ReadFromRestLevels()
        {
            int start = 0, end = 0;
            List<int> originalCitiesVisited = new List<int>();

                for (int i = 0; i < _numberOfCities-1; i++)
                {
                    p = pathList[i];
                    originalCitiesVisited = p.CitiesVisited;
                    start = p.EndCity;
                    for (int j = 0; j < _citiesToVisit.Count; j++)
                    {
                        if (_citiesToVisit[j] != start)
                        {
                            end = _citiesToVisit[j];
                            Path newPath = new Path();
                            newPath.Cost = _matrix[start, end] + p.Cost;

                        for (int k = 0; k < originalCitiesVisited.Count; k++)
                            newPath.CitiesVisited.Add(originalCitiesVisited[k]);
                        
                        newPath.CitiesVisited.Add(end);
                            newPath.RootPath=p;
                            newPath.EndCity = end;
                            newPath.StartCity = p.StartCity;
                            pathList.Add(newPath);
                        }
                    }
                }
                for(int i=0;i<_numberOfCities-1;i++)
            {
                int city = _citiesToVisit[i];

            }
        }
        private void PathsRecurency(int startCity,int endCity,List<int> citeisToGoThrough)
        {
            foreach(var v in pathList)
            {
                if(pathList[i].EndCity==startCity && pathList[i].CitiesVisited==citeisToGoThrough)
                {
                    Path np = new Path();
                    np.Cost = pathList[i].Cost + _matrix[startCity, endCity];
                }
            }
        }
        private void ReadFromFirstLevel(int startVertex,int endVertex)
        {
                if (endVertex <= _citiesToVisit[_citiesToVisit.Count - 1])
                {
                    p.StartCity = startVertex;
                    p.CitiesVisited.Add(0);
                    p.EndCity = endVertex;
                    p.CitiesVisited.Add(endVertex);
                    int cost = _matrix[startVertex, endVertex];
                    p.Cost = cost;
                    pathList.Add(p);
               
                    p = new Path();
                    endVertex++;
                    ReadFromFirstLevel(startVertex, endVertex);
                }
                else{ReadFromRestLevels(); }   
        }
       
        private void ChooseSelectedCities(Node node)
        {
            test++;
            if (node.ChildNodes == null) { return; }

            foreach (var child in node.ChildNodes)
            {
                if (child.Selected)
                {
                    selectedCities.Add(child.Value);
                    ChooseSelectedCities(child);
                }
            }
        }

        private void PrepareArrays(int numberOfSubsets, int numberOfMidpathCities)
        {
            distances = new int[numberOfSubsets, numberOfMidpathCities];
            parents= new int[numberOfSubsets, numberOfMidpathCities];

            for (int i = 0; i <  numberOfSubsets; i++)
            {
                for (int j = 0; j < numberOfMidpathCities; j++)
                {
                    distances[i,j] = Int32.MinValue;
                }
            }
        }
        /*  private int Algorithm(int mask, int pos)
          {
              if(mask==VISITED_ALL_MASK)
              {
                  return _matrix[pos, 0];
              }
              if(distances[mask,pos]!=Int32.MinValue)
              {
                  return distances[mask, pos];
              }

              for (int i = 0; i < _numberOfCities;i++)
              {
                  test++;
                  Console.WriteLine(test+" mask"+mask+" pos"+pos);
                  int leftshift = 1 << i;
                  int result = mask & leftshift;
                  if(result==0)
                  {
                      int newCost = _matrix[pos, i] + Algorithm(mask|(1<<i),i);
                      totalCost = Math.Min(totalCost, newCost);
                  }
              }
              return distances[mask,pos]= totalCost;
          }*/
          private void GetResults(int startCity, int finalCity,int numberOfMidpathCities)
        {
            int currentSubset = (1 << numberOfMidpathCities) - 1;
            int currentCity = finalCity;
            while (currentCity != startCity)
            {            
                selectedCities.Add(currentCity);
                currentSubset = SubsetWithoutCity(currentSubset, currentCity);

                currentCity = parents[currentSubset,currentCity];
              //  if (selectedCities.Count == _numberOfCities + 1)
                //    break;
            }

            selectedCities.Add(startCity);

        }
        private int SubProblem(int numberOFMidpathCities, int subset, int destCity)
        {
            Console.WriteLine("numberofmidpathcities " + numberOFMidpathCities + " subset withoutCity " + subset + " finalCity " + destCity);
            if (distances[subset, destCity] != Int32.MinValue)
            {
                // If the sub problem was solved before do not solve it again - just return the result
                return distances[subset, destCity];
            }
            else
            {
                // Otherwise find the city that visited before destCity will give the best path
                int minDistance = Int32.MaxValue;
                int minParent = Int32.MinValue;

                for (int preDestCity = 0; preDestCity < numberOFMidpathCities; preDestCity++)
                {
                    if (isCityInSubset(subset, preDestCity))
                    {
                        int subsetWithoutPreDestCity = SubsetWithoutCity(subset, preDestCity);
                        int distance = SubProblem(numberOFMidpathCities, subsetWithoutPreDestCity, preDestCity) + _matrix[preDestCity, destCity];

                        if (distance < minDistance)
                        {
                            minDistance = distance;
                            minParent = preDestCity;
                        }
                    }
                }
                distances[subset,destCity] = minDistance;
                parents[subset,destCity] = minParent;

                return minDistance;
            }
        }
        static bool isCityInSubset(int subset, int city) { return (subset & (1 << city)) != 0; }
        static int SubsetWithoutCity(int subset, int city) { return subset & ~(1 << city); }
        #endregion

        #region public functions
        public List<int> Held_Karp()
        {
            int startCity = _numberOfCities - 1;
                        // number of cities excluding the start one
            int numberOfMidpathCities = _numberOfCities - 1;
                        // total number of midpath city subsets
            int numberOfSubsets = 1 << numberOfMidpathCities;

            PrepareArrays(numberOfSubsets,numberOfMidpathCities);

            for (int i = 0; i < numberOfMidpathCities; i++)
            {
                distances[0,i] = _matrix[startCity, i];
                parents[0,i] = startCity;
            }
            
            int minFinalCity = Int32.MinValue;
            int allMidpathCities = 1 << numberOfMidpathCities -1;

            // final city is the city which will be visited before comming back to start city
            for (int finalCity = 0; finalCity < numberOfMidpathCities; finalCity++)
            {
                int distance = SubProblem(numberOfMidpathCities, SubsetWithoutCity(allMidpathCities, finalCity), finalCity) + _matrix[finalCity, startCity];
                if (distance < totalCost)
                {
                    totalCost = distance;
                    minFinalCity = finalCity;
                }
            }
          // GetResults( startCity, minFinalCity, numberOfMidpathCities);

            FillCitiesToVisit();
            int actualCity = _citiesToVisit[0];
            _citiesToVisit.RemoveAt(0);

            //Console.WriteLine("TotalCost maski=" + totalCost);

               Node actualNode = new Node();
              // totalCost= SearchBestWay(actualCity,_citiesToVisit,actualNode);
             ReadFromFirstLevel(actualCity, _citiesToVisit[0]);

            selectedCities.Add(_cities[0]);
               ChooseSelectedCities(actualNode);
            
           // totalCost=Algorithm(1, 0);
            return selectedCities;
        }
        public int GetTotalCost()
        {
            return totalCost;
        }
        #endregion
    }
}
