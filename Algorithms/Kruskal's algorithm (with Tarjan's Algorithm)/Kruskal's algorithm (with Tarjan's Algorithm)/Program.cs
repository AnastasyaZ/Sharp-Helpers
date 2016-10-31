using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kruskal_s_algorithm__with_Tarjan_s_Algorithm_
{
    public struct Edge
    {
        public int From;
        public int To;
        public int Weight;
    }

    public class Node
    {
        public int NodeNumber;
        public List<Node> IncidentNodes = new List<Node>();
    }

    class Program
    {
        public static IEnumerable<Edge> FindMinimumSpanningTree(IEnumerable<Edge> edges)
        {
            var tree = new List<Edge>();
            foreach (var edge in edges.OrderBy(x => x.Weight))
            {
                tree.Add(edge);
                if (HasCycle(tree))
                    tree.Remove(edge);
            }
            return tree;
        }


        public static bool HasCycle(List<Node> graph)
        {
            var visited = new HashSet<Node>();
            var finished = new HashSet<Node>();
            var stack = new Stack<Node>();
            visited.Add(graph.First());
            stack.Push(graph.First());
            while (stack.Count != 0)
            {
                var node = stack.Pop();
                foreach (var nextNode in node.IncidentNodes)
                {
                    if (finished.Contains(nextNode)) continue;
                    if (visited.Contains(nextNode)) return true;
                    visited.Add(nextNode);
                    stack.Push(nextNode);
                }
                finished.Add(node);
            }
            return false;
        }


        public static void Main()
        {
            // описание ребер разделены пробелами
            // дефисом разделены номера вершин ребра
            CheckHasCycle("0-1", false);
            CheckHasCycle("0-1 0-2", false);
            CheckHasCycle("0-1 0-2 1-2", true);
            CheckHasCycle("0-1 0-2 0-3", false);
            CheckHasCycle("0-1 0-2 0-3 1-3", true);
            RunSecretTests();
            Console.WriteLine("OK");
        }


class Edge
{
    public int v1, v2;
    public int weight;
}

public void algorithmByPrim(int numberV, List<Edge> E, List<Edge> MST)
{
    //неиспользованные ребра
    List<Edge> notUsedE = new List<Edge>(E);
    //использованные вершины
    List<int> usedV = new List<int>();
    //неиспользованные вершины
    List<int> notUsedV = new List<int>();
    for (int i = 0; i < numberV; i++)
        notUsedV.Add(i);
    //выбираем случайную начальную вершину
    Random rand = new Random();
    usedV.Add(rand.Next(0, numberV));
    notUsedV.RemoveAt(usedV[0]);
    while (notUsedV.Count > 0)
    {
        int minE = -1; //номер наименьшего ребра
        //поиск наименьшего ребра
        for (int i = 0; i < notUsedE.Count; i++)
        {
            if ((usedV.IndexOf(notUsedE[i].v1) != -1) && (notUsedV.IndexOf(notUsedE[i].v2) != -1) ||
                (usedV.IndexOf(notUsedE[i].v2) != -1) && (notUsedV.IndexOf(notUsedE[i].v1) != -1))
            {
                if (minE != -1)
                {
                    if (notUsedE[i].weight < notUsedE[minE].weight)
                        minE = i;
                }
                else
                    minE = i;
            }
        }
        //заносим новую вершину в список использованных и удаляем ее из списка неиспользованных
        if (usedV.IndexOf(notUsedE[minE].v1) != -1)
        {
            usedV.Add(notUsedE[minE].v2);
            notUsedV.Remove(notUsedE[minE].v2);
        }
        else
        {
            usedV.Add(notUsedE[minE].v1);
            notUsedV.Remove(notUsedE[minE].v1);
        }
        //заносим новое ребро в дерево и удаляем его из списка неиспользованных
        MST.Add(notUsedE[minE]);
        notUsedE.RemoveAt(minE);
    }
}

    }
}


