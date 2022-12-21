using Microsoft.EntityFrameworkCore;
using WebApi.Domain;

namespace WebApi1.Queries
{
    public class Mutation
    {
        public async Task<Student> AddStudent([Service] WebApiDbContext context, Student student)
        {
            context.Students.Add(student);
            await context.SaveChangesAsync();

            return student;
        }

        public async Task<Message> AddMessage([Service] WebApiDbContext context, Message message)
        {
            context.Messages.Add(message);
            await context.SaveChangesAsync();

            return message;
        }

        public async Task ReadMessage([Service] WebApiDbContext context, int messageId)
        {
            await context.Messages.Where(message => message.Id == messageId && message.Read == false).ExecuteUpdateAsync(calls => calls.SetProperty(message => message.Read, true));
        }

        public async Task<Student?> DeleteStudent([Service] WebApiDbContext context, int studentId)
        {
            var student = await context.Students.Where(x => x.Id == studentId).FirstOrDefaultAsync();

            if (student != null)
            {
                context.Students.Remove(student);
                await context.SaveChangesAsync();
            }

            return student;
        }
    }
}