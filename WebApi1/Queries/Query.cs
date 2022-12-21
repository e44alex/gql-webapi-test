using WebApi.Domain;

namespace WebApi1.Queries
{
    public class Query
    {
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Student> Students([Service] WebApiDbContext context) => context.Students;

        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Message> Messages([Service] WebApiDbContext context) => context.Messages;
    }
}
