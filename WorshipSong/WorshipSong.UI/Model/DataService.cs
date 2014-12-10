using System;

namespace WorshipSong.UI.Model
{
    public class DataService : IDataService
    {
        public void GetData(Action<DataItem, Exception> callback)
        {
            // Use this to connect to the actual data service

            var item = new DataItem("Lorem ipsum dolor sit amet enim.\n\n Etiam ullamcorper. Suspendisse a pellentesque dui, non felis.\n Maecenas malesuada elit lectus felis, malesuada ultricies.");
            callback(item, null);
        }
    }
}