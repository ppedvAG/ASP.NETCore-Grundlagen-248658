namespace BusinessModel.Models
{
    public class PaginatedList<T> : List<T>
    {
        public int PageIndex { get; init; }

        public int TotalPages { get; set; }

        public bool HasPreviousPage => PageIndex > 1;

        public bool HasNextPage => PageIndex < TotalPages;

        private PaginatedList(IEnumerable<T> items)
            : base(items)
        {
        }

        public PaginatedList(IEnumerable<T> items, int count, int pageSize)
            : this(items)
        {
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        }

        /// <summary>
        /// Hilfsfunktion um spaeter das Domain-Modell in das ViewModel kollektiv umzuwandeln.
        /// Im Endeffekt delegiert diese Methode das Select an das Select von Linq und stellt sicher,
        /// dass wird den Datentyp PaginatedList<paramref name="T"/> beibehalten.
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="selector">Funktion um das Model zu konvertieren.</param>
        /// <returns></returns>
        public PaginatedList<TResult> Select<TResult>(Func<T, TResult> selector)
        {
            return new PaginatedList<TResult>(this.AsEnumerable().Select(selector))
            {
                PageIndex = PageIndex,
                TotalPages = TotalPages
            };
        }
    }
}
