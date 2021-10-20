using System.Collections.Generic;
using System.Linq;
using Gregslist.Data;
using Gregslist.Models;

namespace Gregslist.Service
{
  public class ArtistsService
  {
    private readonly FakeDb _db;
    public ArtistsService(FakeDb db)
    {
      _db = db;
    }

    public Artist CreateArtist(Artist artistData)
    {
      artistData.Id = _db.GenerateId();
      _db.Artists.Add(artistData);
      return artistData;
    }
    public List<Artist> Get()
    {
      return _db.Artists.Where(music => music.Removed == false).ToList();
    }
    public Artist Get(int artistId)
    {
      var artist = _db.Artists.Find(music => music.Id == artistId && music.Removed == false);
      if(artist == null)
      {
        throw new System.Exception("Invalid Id =(");
      }
      return artist;
    }
    public Artist Edit(int artistId, Artist artistData)
    {
      var artist = Get(artistId);
      artist.Name = artistData.Name ?? artist.Name;
      artist.Genre = artistData.Genre ?? artist.Genre;
      return artist;
    }
    public Artist Delete(int artistId)
    {
      var artist = Get(artistId);
      artist.Removed = true;
      return artist;
    }
  }
}