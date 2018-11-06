using System.IO;
using LocalDataAccess.Android;
using SQLite;

[assembly: Xamarin.Forms.Dependency(typeof(DatabaseConnection_Android))]
namespace LocalDataAccess.Android {
  public class DatabaseConnection_Android : IDatabaseConnection {
    public SQLiteConnection DbConnection() {
      var dbName = "CustomersDb.db3";
      string personalFolder =
     System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
      string libraryFolder = Path.Combine(personalFolder, "..", "Library");
      var path = Path.Combine(libraryFolder, dbName);
      if (!Directory.Exists(libraryFolder)) {
        Directory.CreateDirectory(libraryFolder);
      }
      if (!File.Exists(path)) {
        File.Create(path);
      }
      return new SQLiteConnection(path);
    }
  }
}