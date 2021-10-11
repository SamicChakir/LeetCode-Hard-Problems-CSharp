using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LeetCodeHardProblems
{
    public static class MinimumWindowSubstring
    {
        public static string MinWindow(string s, string t)
        {
            if (s.Length < t.Length) return "";
            var occsinT = OccsPerString(t);
            int i = 0;
            while (i < s.Length && !occsinT.ContainsKey(s[i]))
            {
                i++;
            }
            if (i == s.Length) return "";
            s = s.Substring(i);
            int j = s.Length - 1;
            while (j >= 0 && !occsinT.ContainsKey(s[j]))
            {
                j--;
            }
            s = s.Substring(0, j + 1);
            if (s.Length < t.Length) return "";

            var index = 0;
            var size = s.Length;
            var scoreToComplete = occsinT.Sum(d => d.Value);

            //looking for first sequence 
            var currentScore = scoreToComplete;
            var currenDictionaryTracking = new Dictionary<Char, int>(occsinT);
            var firstAppearanceIndex = index;
            while (currentScore > 0 && index < size)
            {
                var curChar = s[index];
                if (currenDictionaryTracking.ContainsKey(curChar))
                {
                    if (currenDictionaryTracking[curChar] > 0)
                    {
                        currenDictionaryTracking[curChar] -= 1;
                        currentScore -= 1;
                    }
                    else
                    {
                        currenDictionaryTracking[curChar] -= 1;
                    }
                }
                index++;
            }
            if (currentScore != 0) return "";
            index--;
            //we have found a substring between 0 and index , we search of a still valid 
            var foundBestleftBound = false;
            var leftIndex = 0;
            while (!foundBestleftBound && leftIndex <= index )
            {
                var curChar = s[leftIndex];
                if (currenDictionaryTracking.ContainsKey(curChar))
                {
                    if (currenDictionaryTracking[curChar] == 0)
                    {
                        foundBestleftBound = true;
                    }
                    else
                    {
                        currenDictionaryTracking[curChar] += 1;
                        leftIndex++;
                    }
                }
                else
                {
                    leftIndex++;
                }


            }

            if (index == size - 1) return s.Substring(leftIndex, index - leftIndex + 1);
            var bestRightIndex = index;
            var bestLeftIndex = leftIndex;
            var rightIndex = index;
            var substringScore = 0;
            while ( rightIndex < size - 1)
            {
                // we will look at substring between leftIndex +1 and rightIndex +1 
                var previousLeft = s[leftIndex];
                var newRight = s[rightIndex + 1];
                if (currenDictionaryTracking.ContainsKey(previousLeft))
                {
                    currenDictionaryTracking[previousLeft] += 1;
                    if (currenDictionaryTracking[previousLeft] > 0)
                    {
                        currentScore += 1;
                    }

                }
                if(currenDictionaryTracking.ContainsKey(newRight))
                {
                    currenDictionaryTracking[newRight] -= 1;
                    if (currenDictionaryTracking[newRight] >= 0)
                    {
                        currentScore -= 1;
                    }
                }
                leftIndex++;
                rightIndex++;
                if ( currentScore == 0)
                {
                    //this is a valid substring try to see if we can move the leftindex to have a small substring 
                    var foundBestleftBoundBis = false;
                    while (!foundBestleftBoundBis && leftIndex < rightIndex+1)
                    {
                        var curChar = s[leftIndex];
                        if (currenDictionaryTracking.ContainsKey(curChar))
                        {
                            if (currenDictionaryTracking[curChar] == 0)
                            {
                                foundBestleftBoundBis = true;
                            }
                            else
                            {
                                currenDictionaryTracking[curChar] += 1;
                                leftIndex++;
                            }
                        }
                        else
                        {
                            leftIndex++;
                        }


                    }
                    bestLeftIndex = leftIndex;
                    bestRightIndex = rightIndex;
                }
                
            }
            if (currentScore == 0)
            {
                //this is a valid substring try to see if we can move the leftindex to have a small substring 
                var foundBestleftBoundBis = false;
                while (!foundBestleftBoundBis && leftIndex < rightIndex + 1)
                {
                    var curChar = s[leftIndex];
                    if (currenDictionaryTracking.ContainsKey(curChar))
                    {
                        if (currenDictionaryTracking[curChar] == 0)
                        {
                            foundBestleftBoundBis = true;
                        }
                        else
                        {
                            currenDictionaryTracking[curChar] += 1;
                            leftIndex++;
                        }
                    }
                    else
                    {
                        leftIndex++;
                    }


                }
                bestLeftIndex = leftIndex;
                bestRightIndex = rightIndex;
            }

            return s.Substring(bestLeftIndex,bestRightIndex - bestLeftIndex +1 );
        }
        public static Dictionary<Char, int> OccsPerString(string t)
        {
            var occs = new Dictionary<Char, int>();

            foreach (var c in t)
            {
                if (occs.ContainsKey(c)) occs[c] += 1;
                else occs[c] = 1;
            }
            return occs;
        }


    }
}
