using System;
using System.IO;
using Xamarin.Forms;
using Notes.Model;

namespace Notes
{
    public partial class NoteEntryPage : ContentPage
    {
        public NoteEntryPage()
        {
            InitializeComponent();
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var note = (Note)BindingContext;
            note.Date = DateTime.Now;
            await App.DataBase.SaveNoteAsync(note);
            await Navigation.PopAsync();
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var note = (Note)BindingContext;
            await App.DataBase.DeleteNoteAsync(note);
            await Navigation.PopAsync();
        }
    }
    
}
