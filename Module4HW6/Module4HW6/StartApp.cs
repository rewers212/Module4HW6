using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Module4HW6.DataAccess;

namespace Module4HW6
{
    public class StartApp
    {
        ContextFactory optionalBuilder = new ContextFactory();
        public void FirstTask()
        {
            var q = new DateTime(1925, 2, 3);
            using (var dbContext = optionalBuilder.CreateDbContext(new string[0]))
            {
                var song = dbContext.SongArtist
                    .Where(a => a.ArtistId != null && a.SongId != null)
                    .Include(a => a.Artist)
                    .Include(a => a.Song)
                        .ThenInclude(a => a.Genre)
                    .Select(a => new
                    {
                        ArtistName = a.Artist.Name,
                        SongTitle = a.Song.Title,
                        Genge = a.Song.Genre.Title
                    })
                    .ToList();
            }
        }

        public void SecondTaks()
        {
            using (var dbContext = optionalBuilder.CreateDbContext(new string[0]))
            {
                var song = dbContext.Song
                    .Include(a => a.Genre)
                    .GroupBy(a => a.Genre.Title)
                    .Select(a => new
                    {
                        Genre = a.Key,
                        NumberOfSong = a.Count()
                    })
                    .ToList();
            }
        }
        public void ThirdTaks()
        {
            using (var dbContext = optionalBuilder.CreateDbContext(new string[0]))
            {
                var maxDateOfBirth = dbContext.Artist.Max(a => a.DateOfBirth);

                var song = dbContext.Song
                    .Select(a => new
                    {
                        SongTitle = a.Title,
                        ReleaseDate = a.ReleaseDate
                    })
                    .Where(a => a.ReleaseDate < maxDateOfBirth)
                    .ToList();

                
            }
        }
    }
}
