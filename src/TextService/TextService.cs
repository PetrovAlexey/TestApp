using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1.TextService
{
	internal class TextService : ITextService
	{
		/// <summary>
		/// Lookup text list to find similarities
		/// </summary>
		/// <param name="textList">List of text</param>
		/// <returns></returns>
		public IEnumerable<List<string>> ParseList(IList<string> textList)
		{
			var hash = new Dictionary<string, List<string>>();

			foreach (var word in textList)
			{
				// Define unique word as char lookup
				var charLookup = word.ToLower().Where(char.IsLetterOrDigit).ToLookup(c => c);
				var hashSet = charLookup.OrderBy(c => c.Key).Aggregate(
					"",
					(current, c) => current + $"{charLookup[c.Key].Count()}{c.Key}");

				hash.TryGetValue(hashSet, out var list);
				if (list != null)
				{
					list.Add(word);
					hash[hashSet] = list;
				}
				else
				{
					hash.Add(hashSet, new List<string> { word });
				}
			}

			return hash.Select(collection => collection.Value).ToList();
		}
	}
}
