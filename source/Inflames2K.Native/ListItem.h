#pragma once

namespace Inflames2K
{
	template <typename T>
	struct ListItem
	{
		const T& Value;
		ListItem* Previous;
		ListItem* Next;

		ListItem(const T& value) : Value(value)
		{
			this->Previous = NULL;
			this->Next = NULL;
		}
	};
}