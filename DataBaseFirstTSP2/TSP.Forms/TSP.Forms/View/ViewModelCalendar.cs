using Syncfusion.SfCalendar.XForms;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace TSP.Forms.View
{
    public class ViewModelCalendar : Behavior<SfCalendar>
    {
        public CalendarEventCollection CalendarInlineEvents { get; set; } = new CalendarEventCollection();

        public ViewModelCalendar()
        { /**
            // Create events 
            CalendarInlineEvent event1 = new CalendarInlineEvent()
            {
                Subject = "Goto Meeting",
                StartTime = calendar.MoveToDate.AddDays(i).AddHours(9),
                EndTime = calendar.MoveToDate.AddDays(i).AddHours(10),
                Color = Color.Green
            };

            CalendarInlineEvent event2 = new CalendarInlineEvent()
            {
                StartTime = DateTime., 
                EndTime = DateTime.Today.AddHours(12),
                Subject = "Planning",
                Color = Color.Fuchsia
            };

            // Add events into a CalendarInlineEvents collection
            CalendarInlineEvents.Add(event1);
            CalendarInlineEvents.Add(event2); **/
        }

        SfCalendar calendar;
        protected override void OnAttachedTo(SfCalendar bindable)
        {
            calendar = bindable;
            calendar.MoveToDate = new DateTime(2020, 03, 8);
            calendar.MaximumEventIndicatorCount = 10;
            // create CalendarInlineEvents collection
            CalendarEventCollection calendarInlineEvents = new CalendarEventCollection();

            //// Create events 
            for (int i = 1; i <= 7; i=i+7)
            {
                calendarInlineEvents.Add(
                  new CalendarInlineEvent()
                  {
                      Subject = "Goto Meeting",
                      StartTime = calendar.MoveToDate.AddDays(i).AddHours(7),
                      EndTime = calendar.MoveToDate.AddDays(i).AddHours(19),
                      Color = Color.Green
                  });

                calendarInlineEvents.Add(
                  new CalendarInlineEvent()
                  {
                      Subject = "Goto Conference",
                      StartTime = calendar.MoveToDate.AddDays(i).AddHours(11),
                      EndTime = calendar.MoveToDate.AddDays(i).AddHours(12),
                      Color = Color.Blue
                  });

                calendarInlineEvents.Add(
                 new CalendarInlineEvent()
                 {
                     Subject = "Goto Lunch",
                     StartTime = calendar.MoveToDate.AddDays(i).AddHours(13),
                     EndTime = calendar.MoveToDate.AddDays(i).AddHours(14),
                     Color = Color.Fuchsia
                 });

                calendarInlineEvents.Add(
                new CalendarInlineEvent()
                {
                    Subject = "Goto Meeting",
                    StartTime = calendar.MoveToDate.AddDays(i).AddHours(15),
                    EndTime = calendar.MoveToDate.AddDays(i).AddHours(16),
                    Color = Color.Red
                });

                calendarInlineEvents.Add(
                new CalendarInlineEvent()
                {
                    Subject = "Goto Conference",
                    StartTime = calendar.MoveToDate.AddDays(i).AddHours(16),
                    EndTime = calendar.MoveToDate.AddDays(i).AddHours(17),
                    Color = Color.FromRgb(53, 122, 160)
                });
            }

            // Customize the DayHeader using MonthView Settings
            MonthViewSettings monthViewSettings = new MonthViewSettings();
            monthViewSettings.DayHeaderBackgroundColor = Color.FromRgb(53, 122, 160);
            monthViewSettings.DayHeaderTextColor = Color.White;
            calendar.MonthViewSettings = monthViewSettings;

            // Set CalendarInlineEvents collection as SfCalendar DataSource
            calendar.DataSource = calendarInlineEvents;

            base.OnAttachedTo(bindable);
        }

        protected override void OnDetachingFrom(SfCalendar bindable)
        {
            base.OnDetachingFrom(bindable);
        }
    }
}
