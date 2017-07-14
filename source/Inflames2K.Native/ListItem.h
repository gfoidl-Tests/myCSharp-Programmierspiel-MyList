#pragma once

namespace Inflames2K
{
	template <typename T>
	struct ListItem
	{
		T Value;
		ListItem* Previous;
		ListItem* Next;

		ListItem(const T& value)
		{
			this->Value = value;
		}
	};
}