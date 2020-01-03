using CollegeManagementSystem.Core;
using Microsoft.AspNet.SignalR;

namespace CollegeManagmentSystem.Infrastructure.Hubs
{
    public class SubjectsHub : Hub
    {
        public void Enrollments(StudentSubject studentSubject)

        {

            Clients.All.NewMessage(studentSubject);

        }
        public void Grades(StudentSubject studentSubject)

        {

            Clients.All.NewMessage(studentSubject);

        }
    }
}
