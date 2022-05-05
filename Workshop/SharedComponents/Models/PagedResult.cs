namespace SharedComponents.Models
{
	public class PagedResult<T>
		where T: class
	{
		public IEnumerable<T> Entries { get; set; } = Array.Empty<T>();
		public int TotalEntries { get; set; }
		public int PageSize { get; set; }
		public int StartIndex { get; set; }
	}
}
