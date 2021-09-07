using System.Collections.Generic;
using Balta.NotificationContext;

namespace Balta.ContentContext
{
    public class CareerItem : Base
    {
        public CareerItem(int sequence, string title, string description, Course course)
        {
            if (course == null) AddNotification(new Notification("Course", "Curso Inválido"));
            Sequence = sequence;
            Title = title;
            Description = description;
            Course = course;
        }
        public int Sequence { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Course Course { get; set; }
    }
}