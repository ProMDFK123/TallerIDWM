namespace TallerIDWM.Src.RequestHelpers
{
    public class PaginationParams
    {
        private const int MaxPageSize = 50;

        public int PageNumber { get; set; } = 1; // <-- requerido por ToPagedList
        private int _pageSize = 8;

        public int PageSize // <-- requerido por ToPagedList
        {
            get => _pageSize;
            set => _pageSize = value > MaxPageSize ? MaxPageSize : value;
        }
    }
}
