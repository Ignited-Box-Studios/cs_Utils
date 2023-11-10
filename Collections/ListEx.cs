﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.Collections
{
	public static class ListEx
	{
		public static IEnumerable<T> ToEnumerable<T>(this IList list)
		{
			for (int i = 0; i < list.Count; i++)
			{
				if (list[i] is not T _t) continue;
				yield return _t;
			}
		}

		public static bool TryPop<T>(this List<T> list, out T item)
		{
			if (list.Count == 0)
			{
				item = default;
				return false;
			}

			int lastIndex = list.Count - 1;
			item = list[lastIndex];
			list.RemoveAt(lastIndex);
			return true;
		}

		public static bool TryPop<T>(this List<T> list, Predicate<T> predicate, out T item)
		{
			for (int i = list.Count - 1; i >= 0; i--)
			{
				T _item = list[i];
				if (!predicate(_item)) continue; 
				
				item = _item;
				list.RemoveAt(i);
				return true;
			}

			item = default;
			return false;
		}
	}
}
