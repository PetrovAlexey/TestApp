using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.TextService
{
	internal interface ITextService
	{
		IEnumerable<List<string>> ParseList(IList<string> textList);
	}
}
