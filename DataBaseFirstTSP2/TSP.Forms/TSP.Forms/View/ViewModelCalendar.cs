using Newtonsoft.Json;
using Syncfusion.SfCalendar.XForms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Text;
using TSP.Forms.Model;
using Xamarin.Forms;

namespace TSP.Forms.View
{
    public class ViewModelCalendar : Behavior<SfCalendar>
    {
        public CalendarEventCollection CalendarInlineEvents { get; set; } = new CalendarEventCollection();
        public ObservableCollection<PlanIndividual> PlanIndividualColleccion { get; set; }
        public int planGrupalId;
        public ObservableCollection<Tarea> TareasColleccion { get; set; }

        

        SfCalendar calendar;

        public ViewModelCalendar()
        {
            GetPlanIndividualApi();
            /**
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

        public void GetPlanIndividualApi()
        {

            var json = new WebClient().DownloadString("https://databasefirsttsp3.azurewebsites.net/api/planIndividual/3");
            var planIndividuals = JsonConvert.DeserializeObject<PlanIndividual>(json);

            /**var json2 = new WebClient().DownloadString("https://databasefirsttsp3.azurewebsites.net/api/EquipoDesarrollo/1");
            var equipoDesarrollo = JsonConvert.DeserializeObject<EquipoDesarrollo>(json2);

            if (equipoDesarrollo.EquipoDesarrolloId == plangrupals.EquipoDesarrolloId)
            {
                NombrePlanGrupal = plangrupals.Nombre;
                NombreEquipo = equipoDesarrollo.Nombre;
            }
            **/


            PlanIndividualColleccion = new ObservableCollection<PlanIndividual>()
            {
                new PlanIndividual(){
                    Nombre = planIndividuals.Nombre,
                    EquipoDesarrolloId = planIndividuals.EquipoDesarrolloId
                }


            };
            
            TareasColleccion = new ObservableCollection<Tarea>();
            foreach (Tarea tarea in planIndividuals.Tarea)
            {

                TareasColleccion.Add(tarea);
            }
        }


        /// <summary>
        /// ///////////////////////
        /// </summary>
       
        protected override void OnAttachedTo(SfCalendar bindable)
        {
            calendar = bindable;
            int SemanaPublicada = 1;
            calendar.MoveToDate = new DateTime(2020, 03, 8);
            calendar.MaximumEventIndicatorCount = 10;
            // create CalendarInlineEvents collection
            CalendarEventCollection calendarInlineEvents = new CalendarEventCollection();


            //// Create events 
            for (int i = 1; i <= TareasColleccion.Count*7; i=i+7)
            {
                foreach (Tarea itemTarea in TareasColleccion)
                {
                    if (itemTarea.SemanaTerminacionPlaneada == SemanaPublicada && itemTarea.PlanIndividualId == 3)
                    {
                        calendarInlineEvents.Add(
                        new CalendarInlineEvent()
                        {
                            Subject = itemTarea.Nombre,
                            StartTime = calendar.MoveToDate.AddDays(i).AddHours(7),
                            EndTime = calendar.MoveToDate.AddDays(i).AddHours(19),
                            Color = ObtenerColorRamdon()
                        }) ;
                    }
                }

                SemanaPublicada = SemanaPublicada + 1;


                /**
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
    **/
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

        public Color ObtenerColorRamdon()
        {
            Color[] colors = new Color[7];
            colors[0] = Color.Green;
            colors[1] = Color.Red;
            colors[2] = Color.Blue;
            colors[3] = Color.Fuchsia;
            colors[4] = Color.Purple;
            colors[5] = Color.Brown;
            colors[6] = Color.LightBlue;

            return colors[(new Random().Next(0,6))];
        }

        protected override void OnDetachingFrom(SfCalendar bindable)
        {
            base.OnDetachingFrom(bindable);
        }
    }
}
