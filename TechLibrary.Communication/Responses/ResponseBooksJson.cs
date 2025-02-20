using TechLibrary.Communication.Responses;

namespace TechLibrary.Api.Filters
{
    public class ResponseBooksJson
    {
        public ResponsePaginationJson Pagination { get; set; } = default!;
        public List<ResponseBookJson> Books { get; set; } = [];
    }
}