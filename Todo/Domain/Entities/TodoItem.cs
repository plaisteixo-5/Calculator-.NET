using System;
using DomainShared.Entities;

namespace Domain.Entities
{
    public class TodoItem : Entity
    {
        public TodoItem(
            string title,
            bool done,
            DateTime date,
            string user)
        {
            Title = title;
            Done = false;
            Date = date;
            User = user;
        }

        public string Title { get; private set; }
        public bool Done { get; private set; }
        public DateTime Date { get; private set; }
        public string User { get; private set; }

        public void MarkAsUndone()
        {
            Done = false;
        }
        public void UpdateTitle(string title)
        {
            Title = title;
        }
    }
}