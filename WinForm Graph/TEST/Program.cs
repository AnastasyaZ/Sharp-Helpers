using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Graph
{
    public static class NodeExtensions
    {
        public static IEnumerable<Node> DepthSearch_Correct(Node startNode)
        {
            var visited = new HashSet<Node>();
            var stack = new Stack<Node>();
            visited.Add(startNode);
            stack.Push(startNode);
            while (stack.Count != 0)
            {
                var node = stack.Pop();
                yield return node;
                foreach (var nextNode in node.IncidentNodes.Where(n => !visited.Contains(n)))
                {
                    visited.Add(nextNode);
                    stack.Push(nextNode);
                }
            }
        }

        public static IEnumerable<Node> BreadthSearch_Correct(Node startNode)
        {
            var visited = new HashSet<Node>();
            var queue = new Queue<Node>();
            visited.Add(startNode);
            queue.Enqueue(startNode);
            while (queue.Count != 0)
            {
                var node = queue.Dequeue();
                yield return node;
                foreach (var nextNode in node.IncidentNodes.Where(n => !visited.Contains(n)))
                {
                    visited.Add(nextNode);
                    queue.Enqueue(nextNode);
                }
            }
        }
    }

    class Program
    {
        #region findPath
        public static List<Node> FindPath(Node start, Node end)
        {
            var track = new Dictionary<Node, Node>();
            track[start] = null;
            var queue = new Queue<Node>();
            queue.Enqueue(start);

            while (queue.Count != 0)
            {
                var node = queue.Dequeue();
                foreach (var nextNode in node.IncidentNodes)
                {
                    if (track.ContainsKey(nextNode)) continue;
                    track[nextNode] = node;
                    queue.Enqueue(nextNode);
                }
                if (track.ContainsKey(end)) break;
            }

            var result = new List<Node>();
            var trackItem = end;
            while (trackItem != null)
            {
                result.Add(trackItem);
                trackItem = track[trackItem];
            }
            result.Reverse();
            return result;
        }
        #endregion findPath

        #region Kahn
        public static List<Node> KahnAlgorithm(Graph graph) 
        {
            var topSort = new List<Node>();
            var nodes = graph.Nodes.ToList();
            while (nodes.Count != 0)
            {
                var nodeToDelete = nodes
                    .Where(node => !node.IncidentEdges.Any(edge => edge.To == node))
                    .FirstOrDefault();

                if (nodeToDelete == null) return null;
                nodes.Remove(nodeToDelete);
                topSort.Add(nodeToDelete);
                foreach (var edge in nodeToDelete.IncidentEdges.ToList())
                    graph.Delete(edge);
            }
            return topSort;
        }
        #endregion Kahn

        #region Tarjan
        public enum State
        {
            White,
            Gray,
            Black
        }

        public static List<Node> TarjanAlgorithm(Graph graph)
        {
            var topSort = new List<Node>();
            var states = graph.Nodes.ToDictionary(node => node, node => State.White);
            while (true)
            {
                var nodeToSearch = states
                    .Where(z => z.Value == State.White)
                    .Select(z => z.Key)
                    .FirstOrDefault();
                if (nodeToSearch == null) break;

                if (!TarjanDepthSearch(nodeToSearch, states, topSort))
                    return null;
            }
            topSort.Reverse();
            return topSort;
        }

        public static bool TarjanDepthSearch(Node node, Dictionary<Node, State> states, List<Node> topSort)
        {
            if (states[node] == State.Gray) return false;
            if (states[node] == State.Black) return true;
            states[node] = State.Gray;

            var outgoingNodes = node.IncidentEdges
                .Where(edge => edge.From == node)
                .Select(edge => edge.To);
            foreach (var nextNode in outgoingNodes)
                if (!TarjanDepthSearch(nextNode, states, topSort)) return false;

            states[node] = State.Black;
            topSort.Add(node);
            return true;
        }
        #endregion Tarjan

        #region TarjanHasCycle
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
        #endregion TarjanHasCycle

        public static void Main()
        {
            #region findPath
            var graph = Graph.MakeGraph(
            0, 1,
            0, 2,
            1, 4,
            2, 3,
            3, 4
            );

            var path = FindPath(graph[0], graph[4]);

            Console.WriteLine(
                path
                .Select(v => v.ToString())
                .Aggregate((a, b) => a + " " + b));
            #endregion findPath

            #region Kahn
            var graph1 = Graph.MakeGraph(
            0, 1,
            0, 2,
            1, 2,
            1, 3,
            2, 3,
            2, 4,
            3, 4
            );

            var tsGraph = KahnAlgorithm(graph1);

            Console.WriteLine(tsGraph
                .Select(v => v.ToString())
                .Aggregate((sum, v) => sum + " " + v));
            #endregion Kahn

            #region TarjanHasCycle
            var graph2 = Graph.MakeGraph(0, 1);
            var hasCycle = HasCycle(graph2.Nodes.ToList());
            #endregion TarjanHasCycle
        }
    }
}
