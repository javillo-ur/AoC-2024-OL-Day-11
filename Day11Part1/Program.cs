﻿File.ReadAllLines("input.txt").Select(line => line.Trim().Split(" ").Select(t => long.Parse(t))).Select(list => (list, Enumerable.Range(0, 25).Aggregate((System.Collections.Immutable.ImmutableList.ToImmutableList(list), System.Collections.Immutable.ImmutableDictionary.Create<long, List<long>>()), (aux, el) => aux.Item1.Aggregate(aux, (curr, el) => curr.Item2.ContainsKey(el) ? (curr.Item1.RemoveAll(t => t == el), curr.Item2) : (el == 0 ? (curr.Item1.RemoveAll(t => t == 0).Add(1), curr.Item2.Add(0, [1])) : new List<long>(){el}.Select(t => t.ToString()).Select<string,List<long>>(t => t.Length % 2 == 0 ? ([long.Parse(t[.. (t.Length/2)]), long.Parse(t[(t.Length/2) ..])]) : [el*2024]).Select(t => (curr.Item1.RemoveAll(x => x == el).AddRange(t), curr.Item2.Add(el, t))).First()))))).Select(list => (list, Enumerable.Range(0, 25).Aggregate((list.Item2.Item1, System.Collections.Immutable.ImmutableDictionary.Create<(long,int),long>()), (aux, it) => (aux.Item1, aux.Item2.AddRange(list.Item2.Item2.Keys.Select(t => (t, it)).Select(t => new KeyValuePair<(long, int), long>(t, list.Item2.Item2[t.t].Sum(x => aux.Item2.ContainsKey((x, it-1)) ? aux.Item2[(x, it-1)] : 1L)))))))).ToList().ForEach(list => Console.WriteLine(list.list.list.Sum(x => list.Item2.Item2[(x, 24)])));