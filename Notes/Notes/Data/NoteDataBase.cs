using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using Notes.Model;
using System.Threading.Tasks;
using System.Linq;
namespace Notes.Data
{
   public class NoteDataBase
    {
        readonly SQLiteAsyncConnection _DataBase;
        public NoteDataBase(string dbPath)
        {
            _DataBase = new SQLiteAsyncConnection(dbPath);
            _DataBase.CreateTableAsync<Note>().Wait();
        }
        public Task<List<Note>> GetNotesAsync()
        {
            return _DataBase.Table<Note>().ToListAsync();
        }

        public Task<Note> GetNotesAsync(int id)
        {
            return _DataBase.Table<Note>()
                .Where(i => i.ID == id)
                .FirstOrDefaultAsync();
        }
        public Task<int> SaveNoteAsync(Note note)
        {
            if (note.ID != 0)
            {
                return _DataBase.UpdateAsync(note);
            }
            else
            {
                return _DataBase.InsertAsync(note);
            }
        }
        public Task<int> DeleteNoteAsync(Note note)
        {
            return _DataBase.DeleteAsync(note);
        }
    }
}
